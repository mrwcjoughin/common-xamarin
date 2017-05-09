using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using common.xamarin.Core.Interfaces;
using common.xamarin.Core.ViewModels;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class MenuView : ContentView, INavigationView
	{
		public MenuView ()
        {
			this.Resources = SessionContext.Resources;

			InitializeComponent();

            this.BindingContext = SessionContext.CurrentMenuViewModel;
        }

		public common.xamarin.Core.ViewModels.BaseViewModel BaseViewModel
		{
			get
			{
				return (common.xamarin.Core.ViewModels.BaseViewModel)this.BindingContext;
			}
		}

        public MenuViewModel MenuViewModel
        {
            get
            {
                return (MenuViewModel)this.BindingContext;
            }
        }

//        public void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
//        {
//            if (args.SelectedItem != null)
//            {
//                this.MenuViewModel.ItemTapped();
//            }
//        }

        //		public void OnAdminItemSelected(object sender, SelectedItemChangedEventArgs args)
        //		{
        //			if (args.SelectedItem != null)
        //			{
        //				this.MenuViewModel.AdminItemTapped ();
        //			}
        //		}
	}
}