using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using common.xamarin.Core.Interfaces;
using common.xamarin.Core.ViewModels;
using MvvmCross.Core.Navigation;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class DefaultView : Xamarin.Forms.ContentView //, INavigationView
	{
		public DefaultView ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent();
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