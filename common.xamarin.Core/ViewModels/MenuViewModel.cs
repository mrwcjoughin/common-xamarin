using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
//using XLabs;

using common.xamarin.Core.Helpers;
using common.xamarin.Core.Interfaces;
using common.xamarin.Core.Navigation;
using MvvmCross.Core.Navigation;

namespace common.xamarin.Core.ViewModels
{
	public class MenuViewModel : BaseViewModel
	{
        private string _menuName = null;
        private string _adminMenuName = null;
        private List<MenuOptionItem> _menuOptionItems = new List<MenuOptionItem>();
//		private List<MenuOptionItem> _adminMenuOptionItems = new List<MenuOptionItem>();
//		private MenuOptionItem _selectedMenuOptionItem = null;
//		private MenuOptionItem _selectedAdminMenuOptionItem = null;
//		private readonly MvxCommand _itemTappedCommand;
//		private readonly MvxCommand _adminItemTappedCommand;
//		private ObservableCollection<MenuOptionItemGroup> _ = new ObservableCollection<MenuOptionItemGroup>();
        

		public MenuViewModel(IMvxNavigationService navigation)
            : base(navigation)
		{
			//TODO: Get menu items generically
//            _menuOptionItems.Add(new common.xamarin.Core.Helpers.MapMenuOptionItem());
//            _menuOptionItems.Add(new common.xamarin.Core.Helpers.AllFavouritesMenuOptionItem());
//            _menuOptionItems.Add(new common.xamarin.Core.Helpers.FavouriteAssetsMenuOptionItem());
//            _menuOptionItems.Add(new common.xamarin.Core.Helpers.FavouriteDriversMenuOptionItem());

			//TODO: Get admin menu items generically
//            _adminMenuOptionItems.Add(new common.xamarin.Core.Helpers.SelectionsMenuOptionItem());
//            _adminMenuOptionItems.Add(new common.xamarin.Core.Helpers.SettingsMenuOptionItem());
//            _adminMenuOptionItems.Add(new common.xamarin.Core.Helpers.LogoutMenuOptionItem());

			//OnPropertyChanged ("MenuOptionItems");

			//OnPropertyChanged ("AdminMenuOptionItems");
		}

        public string MenuName
        {
            get
            {
                if (_menuName == null)
                {
					_menuName = SessionContext.CurrentTranslationProvider.GetTranslatedString("MenuName");
                }

                return _menuName;
            }
        }

        public string AdminMenuName
        {
            get
            {
                if (_adminMenuName == null)
                {
					_adminMenuName = SessionContext.CurrentTranslationProvider.GetTranslatedString("AdminMenuName");
                }

                return _adminMenuName;
            }
        }

        public List<MenuOptionItem> MenuOptionItems
		{
			get
			{
                return _menuOptionItems;
			}
		}

//		public List<MenuOptionItem> AdminMenuOptionItems
//		{
//			get
//			{
//				return _adminMenuOptionItems;
//			}
//		}

        public async override Task Refresh()
        {
            await base.Refresh ();

            //OnPropertyChanged ("MenuName");
            //OnPropertyChanged ("AdminMenuName");
        }

//		public MenuOptionItem SelectedMenuOptionItem
//		{
//			get
//			{
//				return _selectedMenuOptionItem;
//			}
//			set
//			{
//				_selectedMenuOptionItem = value;
//				OnPropertyChanged ("SelectedMenuOptionItem");
//				ItemTapped ();
//			}
//		}

//		public MenuOptionItem SelectedAdminMenuOptionItem
//		{
//			get
//			{
//				return _selectedAdminMenuOptionItem;
//			}
//			set
//			{
//				_selectedAdminMenuOptionItem = value;
//				OnPropertyChanged ("SelectedAdminMenuOptionItem");
//				AdminItemTapped ();
//			}
//		}

//		public MvxCommand ItemTappedCommand
//		{
//			get
//			{
//				return _itemTappedCommand;
//			}
//		}

//		public MvxCommand AdminItemTappedCommand
//		{
//			get
//			{
//				return _adminItemTappedCommand;
//			}
//		}

//		public void ItemTapped()
//		{
//			try
//			{
//				if (SelectedMenuOptionItem != null)
//				{
//					SessionContext.CurrentNavigationHandler.Navigate(new NavigationItem(this.SelectedMenuOptionItem.NavigationPage, this.SelectedMenuOptionItem.NavigationView));
//					SelectedMenuOptionItem = null;
//				}
//			}
//			catch(Exception ex)
//			{
//				//MessagingCenter.Send<INavigationPage, Alert>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.Alert.ToString(), new Alert(ex.Message, null, SessionContext.LanguageResolver.GetTranslatedString("LoginErrorTitle, SessionContext.LanguageResolver.GetTranslatedString("Ok));
//				SessionContext.CurrentNavigationHandler.CurrentPage.DisplayAlert(new Alert(ex.Message, null, SessionContext.LanguageResolver.GetTranslatedString("LoginErrorTitle, SessionContext.LanguageResolver.GetTranslatedString("Ok));
//			}
//		}

//		public void AdminItemTapped()
//		{
//			try
//			{
//				if (SelectedAdminMenuOptionItem != null)
//				{
//					if (SelectedAdminMenuOptionItem.NavigationPage == common.xamarin.Core.Enums.NavigationPage.Login)
//                    {
//                        SessionContext.CurrentUserSettings.AutoLogin = false;
//                    }
//
//                    SessionContext.CurrentNavigationHandler.Navigate(new NavigationItem (this.SelectedAdminMenuOptionItem.NavigationPage, this.SelectedAdminMenuOptionItem.NavigationView));
//					SelectedAdminMenuOptionItem = null;
//				}
//			}
//			catch(Exception ex)
//			{
//				MessagingCenter.Send<INavigationPage, Alert>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.Alert.ToString(), new Alert(ex.Message, null, SessionContext.LanguageResolver.GetTranslatedString("LoginErrorTitle, SessionContext.LanguageResolver.GetTranslatedString("Ok));
//			}
//		}

		public override void UpdateValidation (string specificFieldName = null)
		{
			//Nothing to do here in this ViewModel
		}
	}
}