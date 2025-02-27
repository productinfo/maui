﻿using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using UIKit;
using WebKit;
using Microsoft.Extensions.Logging;

namespace Microsoft.Maui.Platform
{
	public class MauiWKWebView : WKWebView, IWebViewDelegate
	{
		static WKProcessPool? SharedPool;

		string? _pendingUrl;
		readonly WeakReference<WebViewHandler> _handler;

		public MauiWKWebView(WebViewHandler handler)
			: this(RectangleF.Empty, handler)
		{
		}

		public MauiWKWebView(CGRect frame, WebViewHandler handler)
			: this(frame, handler, CreateConfiguration())
		{
		}

		public MauiWKWebView(CGRect frame, WebViewHandler handler, WKWebViewConfiguration configuration)
			: base(frame, configuration)
		{
			_ = handler ?? throw new ArgumentNullException("handler");
			_handler = new WeakReference<WebViewHandler>(handler);

			BackgroundColor = UIColor.Clear;
			AutosizesSubviews = true;

			NavigationDelegate = new MauiWebViewNavigationDelegate(handler);
		}

		public string? CurrentUrl =>
			Url?.AbsoluteUrl?.ToString();

		public override void MovedToWindow()
		{
			base.MovedToWindow();

			if (!string.IsNullOrWhiteSpace(_pendingUrl))
			{
				var closure = _pendingUrl;
				_pendingUrl = null;

				// I realize this looks like the worst hack ever but iOS 11 and cookies are super quirky
				// and this is the only way I could figure out how to get iOS 11 to inject a cookie 
				// the first time a WkWebView is used in your app. This only has to run the first time a WkWebView is used 
				// anywhere in the application. All subsequents uses of WkWebView won't hit this hack
				// Even if it's a WkWebView on a new page.
				// read through this thread https://developer.apple.com/forums/thread/99674
				// Or Bing "WkWebView and Cookies" to see the myriad of hacks that exist
				// Most of them all came down to different variations of synching the cookies before or after the
				// WebView is added to the controller. This is the only one I was able to make work
				// I think if we could delay adding the WebView to the Controller until after ViewWillAppear fires that might also work
				// But we're not really setup for that
				// If you'd like to try your hand at cleaning this up then UI Test Issue12134 and Issue3262 are your final bosses
				InvokeOnMainThread(async () =>
				{
					await Task.Delay(500);
					if (_handler.TryGetTarget(out var handler))
						await handler.FirstLoadUrlAsync(closure);
				});
			}
		}

		[Export("webView:didFinishNavigation:")]
		public async void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
		{
			var url = CurrentUrl;

			if (url == null || url == $"file://{NSBundle.MainBundle.BundlePath}/")
				return;

			if (_handler.TryGetTarget(out var handler))
				await handler.ProcessNavigatedAsync(url);
		}

		public void LoadHtml(string? html, string? baseUrl)
		{
			if (html != null)
				LoadHtmlString(html, baseUrl == null ? new NSUrl(NSBundle.MainBundle.BundlePath, true) : new NSUrl(baseUrl, true));
		}

		public void LoadUrl(string? url)
		{
			try
			{
				var uri = new Uri(url ?? string.Empty);
				var safeHostUri = new Uri($"{uri.Scheme}://{uri.Authority}", UriKind.Absolute);
				var safeRelativeUri = new Uri($"{uri.PathAndQuery}{uri.Fragment}", UriKind.Relative);
				NSUrlRequest request = new NSUrlRequest(new NSUrl(new Uri(safeHostUri, safeRelativeUri).AbsoluteUri));

				LoadRequest(request);
			}
			catch (UriFormatException formatException)
			{
				// If we got a format exception trying to parse the URI, it might be because
				// someone is passing in a local bundled file page. If we can find a better way
				// to detect that scenario, we should use it; until then, we'll fall back to 
				// local file loading here and see if that works:
				if (!string.IsNullOrEmpty(url))
				{
					if (!LoadFile(url))
					{
						if (_handler.TryGetTarget(out var handler))
							handler.MauiContext?.CreateLogger<MauiWKWebView>()?.LogWarning(nameof(MauiWKWebView), $"Unable to Load Url {url}: {formatException}");
					}
				}
			}
			catch (Exception exc)
			{
				if (_handler.TryGetTarget(out var handler))
					handler.MauiContext?.CreateLogger<MauiWKWebView>()?.LogWarning(nameof(MauiWKWebView), $"Unable to Load Url {url}: {exc}");
			}
		}

		// https://developer.apple.com/forums/thread/99674
		// WKWebView and making sure cookies synchronize is really quirky
		// The main workaround I've found for ensuring that cookies synchronize 
		// is to share the Process Pool between all WkWebView instances.
		// It also has to be shared at the point you call init
		public static WKWebViewConfiguration CreateConfiguration()
		{
			var config = new WKWebViewConfiguration();

			if (SharedPool == null)
				SharedPool = config.ProcessPool;
			else
				config.ProcessPool = SharedPool;

			return config;
		}

		bool LoadFile(string url)
		{
			try
			{
				var file = Path.GetFileNameWithoutExtension(url);
				var ext = Path.GetExtension(url);

				var nsUrl = NSBundle.MainBundle.GetUrlForResource(file, ext);

				if (nsUrl == null)
				{
					return false;
				}

				LoadFileUrl(nsUrl, nsUrl);

				return true;
			}
			catch (Exception ex)
			{
				if (_handler.TryGetTarget(out var handler))
					handler.MauiContext?.CreateLogger<MauiWKWebView>()?.LogWarning(nameof(MauiWKWebView), $"Could not load {url} as local file: {ex}");
			}

			return false;
		}
	}
}