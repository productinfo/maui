namespace Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific
{
	using FormsElement = Maui.Controls.ListView;

	/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="Type[@FullName='Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.ListView']/Docs/*" />
	public static class ListView
	{
		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='SeparatorStyleProperty']/Docs/*" />
		public static readonly BindableProperty SeparatorStyleProperty = BindableProperty.Create(nameof(SeparatorStyle), typeof(SeparatorStyle), typeof(FormsElement), SeparatorStyle.Default);

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='GetSeparatorStyle'][1]/Docs/*" />
		public static SeparatorStyle GetSeparatorStyle(BindableObject element)
		{
			return (SeparatorStyle)element.GetValue(SeparatorStyleProperty);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='SetSeparatorStyle'][1]/Docs/*" />
		public static void SetSeparatorStyle(BindableObject element, SeparatorStyle value)
		{
			element.SetValue(SeparatorStyleProperty, value);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='GetSeparatorStyle'][2]/Docs/*" />
		public static SeparatorStyle GetSeparatorStyle(this IPlatformElementConfiguration<iOS, FormsElement> config)
		{
			return GetSeparatorStyle(config.Element);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='SetSeparatorStyle'][2]/Docs/*" />
		public static IPlatformElementConfiguration<iOS, FormsElement> SetSeparatorStyle(this IPlatformElementConfiguration<iOS, FormsElement> config, SeparatorStyle value)
		{
			SetSeparatorStyle(config.Element, value);
			return config;
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='GroupHeaderStyleProperty']/Docs/*" />
		public static readonly BindableProperty GroupHeaderStyleProperty = BindableProperty.Create(nameof(GroupHeaderStyle), typeof(GroupHeaderStyle), typeof(FormsElement), GroupHeaderStyle.Plain);

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='GetGroupHeaderStyle'][1]/Docs/*" />
		public static GroupHeaderStyle GetGroupHeaderStyle(BindableObject element)
		{
			return (GroupHeaderStyle)element.GetValue(GroupHeaderStyleProperty);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='SetGroupHeaderStyle'][1]/Docs/*" />
		public static void SetGroupHeaderStyle(BindableObject element, GroupHeaderStyle value)
		{
			element.SetValue(GroupHeaderStyleProperty, value);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='GetGroupHeaderStyle'][2]/Docs/*" />
		public static GroupHeaderStyle GetGroupHeaderStyle(this IPlatformElementConfiguration<iOS, FormsElement> config)
		{
			return GetGroupHeaderStyle(config.Element);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='SetGroupHeaderStyle'][2]/Docs/*" />
		public static IPlatformElementConfiguration<iOS, FormsElement> SetGroupHeaderStyle(this IPlatformElementConfiguration<iOS, FormsElement> config, GroupHeaderStyle value)
		{
			SetGroupHeaderStyle(config.Element, value);
			return config;
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='RowAnimationsEnabledProperty']/Docs/*" />
		public static readonly BindableProperty RowAnimationsEnabledProperty = BindableProperty.Create(nameof(RowAnimationsEnabled), typeof(bool), typeof(ListView), true);

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='GetRowAnimationsEnabled']/Docs/*" />
		public static bool GetRowAnimationsEnabled(BindableObject element)
		{
			return (bool)element.GetValue(RowAnimationsEnabledProperty);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='SetRowAnimationsEnabled'][1]/Docs/*" />
		public static void SetRowAnimationsEnabled(BindableObject element, bool value)
		{
			element.SetValue(RowAnimationsEnabledProperty, value);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='SetRowAnimationsEnabled'][2]/Docs/*" />
		public static IPlatformElementConfiguration<iOS, FormsElement> SetRowAnimationsEnabled(this IPlatformElementConfiguration<iOS, FormsElement> config, bool value)
		{
			SetRowAnimationsEnabled(config.Element, value);
			return config;
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific/ListView.xml" path="//Member[@MemberName='RowAnimationsEnabled']/Docs/*" />
		public static bool RowAnimationsEnabled(this IPlatformElementConfiguration<iOS, FormsElement> config)
		{
			return GetRowAnimationsEnabled(config.Element);
		}
	}
}
