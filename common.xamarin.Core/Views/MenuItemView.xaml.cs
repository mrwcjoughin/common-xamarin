using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class MenuItemView : ContentView
    {
        public MenuItemView ()
        {
			this.Resources = SessionContext.Resources;

			InitializeComponent ();
        }
    }
}