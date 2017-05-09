using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class SingleSelectListView : ContentView
	{
		public SingleSelectListView ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent ();
		}
    }
}