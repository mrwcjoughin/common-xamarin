using System;

using common.xamarin.Core.Interfaces;
using common.xamarin.Core.ViewModels;

namespace common.xamarin.Core.Interfaces
{
	public interface INavigationHandler
	{
		#region Properties

		INavigationPresenter CurrentNavigationPresenter
		{
			get;
			set;
		}

		INavigationPage CurrentPage
		{
			get;
		}

        Xamarin.Forms.INavigation CurrentNavigationPage
		{
			get;
		}

		Xamarin.Forms.MasterDetailPage CurrentMasterDetailPage
		{
			get;
			set;
		}

        IMasterDetailHandler CurrentMasterDetailHandler
        {
            get;
            set;
        }

        Xamarin.Forms.ContentView CurrentContentView
		{
			get;
			set;
		}

		RootViewModel CurrentRootViewModel
		{
			get;
			set;
		}

		#endregion Properties

		#region Methods

		bool Navigate(INavigationItem navigationItem);

		//bool Navigate(List<INavigationItem> navigationItems");

		//bool CloseCurrentDocumentPanel(bool immediateClose = false);

		//bool CloseCurrentDialog(bool immediateClose = false);

		bool Save();

		//bool ShowWaitDialog();

		//bool DisposeWaitDialog();

		//bool SetFocusToNavigationItem(INavigationItem navigationItem");

		bool Refresh(/*bool refreshAllTabs = false*/);

		//bool UpdateNavigationItem(INavigationItem navigationItem, bool updateEntireNavigationItem = false);

		bool Close();

		bool Back();

		bool NavigateToLoginPage();

		#endregion Methods
	}
}

