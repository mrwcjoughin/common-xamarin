using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class NavigationBarView : ContentView
	{
		public NavigationBarView ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent ();
		}
	}
}