using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class SearchBarView : ContentView
	{
		public SearchBarView ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent ();
		}
	}
}