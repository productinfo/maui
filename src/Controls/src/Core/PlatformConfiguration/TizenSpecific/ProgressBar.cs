
namespace Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific
{
	using FormsElement = Maui.Controls.ProgressBar;

	/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/ProgressBar.xml" path="Type[@FullName='Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific.ProgressBar']/Docs/*" />
	public static class ProgressBar
	{
		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/ProgressBar.xml" path="//Member[@MemberName='ProgressBarPulsingStatusProperty']/Docs/*" />
		public static readonly BindableProperty ProgressBarPulsingStatusProperty =
			BindableProperty.Create("ProgressBarPulsingStatus", typeof(bool),
			typeof(FormsElement), false);

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/ProgressBar.xml" path="//Member[@MemberName='GetPulsingStatus'][1]/Docs/*" />
		public static bool GetPulsingStatus(BindableObject element)
		{
			return (bool)element.GetValue(ProgressBarPulsingStatusProperty);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/ProgressBar.xml" path="//Member[@MemberName='SetPulsingStatus'][1]/Docs/*" />
		public static void SetPulsingStatus(BindableObject element, bool isPulsing)
		{
			string style = VisualElement.GetStyle(element);
			if (style == ProgressBarStyle.Pending)
			{
				element.SetValue(ProgressBarPulsingStatusProperty, isPulsing);
			}
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/ProgressBar.xml" path="//Member[@MemberName='GetPulsingStatus'][2]/Docs/*" />
		public static bool GetPulsingStatus(this IPlatformElementConfiguration<Tizen, FormsElement> config)
		{
			return GetPulsingStatus(config.Element);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/ProgressBar.xml" path="//Member[@MemberName='SetPulsingStatus'][2]/Docs/*" />
		public static IPlatformElementConfiguration<Tizen, FormsElement> SetPulsingStatus(this IPlatformElementConfiguration<Tizen, FormsElement> config, bool isPulsing)
		{
			SetPulsingStatus(config.Element, isPulsing);
			return config;
		}
	}
}
