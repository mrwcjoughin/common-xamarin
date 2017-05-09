using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using common.xamarin.Core.Interfaces;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class TermsView : ContentView, INavigationView
	{
        public TermsView()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent ();
		}

		public common.xamarin.Core.ViewModels.BaseViewModel BaseViewModel
		{
			get
			{
				return (common.xamarin.Core.ViewModels.BaseViewModel)this.BindingContext;
			}
		}
	}
}