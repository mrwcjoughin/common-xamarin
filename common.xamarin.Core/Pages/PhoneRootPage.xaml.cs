using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using common.xamarin.Core.Enums;
using common.xamarin.Core.Interfaces;
using common.xamarin.Core.Helpers;
using common.xamarin.Core.ViewModels;
using MvvmCross.Core.Navigation;

namespace common.xamarin.Core.Pages
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class PhoneRootPage : ContentPage, INavigationPage, INavigationPresenter
	{
		#region Fields

		private INavigationItem _navigationItem;
        private INavigationItem _previousNavigationItem = null;

		#endregion Fields

		public PhoneRootPage (IMvxNavigationService navigation)
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent();

			SessionContext.CurrentNavigationHandler.CurrentNavigationPresenter = this;

            SessionContext.CurrentNavigationHandler.CurrentRootViewModel = new RootViewModel(navigation);

            this.BindingContext = SessionContext.CurrentNavigationHandler.CurrentRootViewModel;

			//SessionContext.CurrentNavigationHandler.CurrentMasterDetailPage = this;

			//MessagingCenter.Subscribe<INavigationPage, Alert>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.Alert.ToString(), (page, alert) =>
			//{
			//	this.DisplayAlert(alert.Title, alert.Message, alert.OkButtonText);
			//});

			//MessagingCenter.Subscribe<INavigationPage, Alert>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.Exception.ToString(), (page, alert) =>
			//{
			//	this.DisplayAlert(alert.Title, alert.Message, alert.OkButtonText);
			//});

            //UpdateView();

			//MessagingCenter.Subscribe<INavigationPage, ChangeViewMessage>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.ChangeView.ToString(), (page, changeViewMessage) =>
			//{
			//	if (!_isLoading)
			//	{
			//		try
			//		{
			//			_isLoading = true;

			//			UpdateView();
			//		}
			//		finally
			//		{
			//			_isLoading = false;
			//		}
			//	}
			//});
		}

		#region Properties

		public INavigationItem NavigationItem
		{
			get
			{
				return _navigationItem;
			}
		}

        public INavigationItem PreviousNavigationItem
        {
            get
            {
                return _previousNavigationItem;
            }
        }

		public common.xamarin.Core.ViewModels.BaseViewModel BaseViewModel
		{
			get
			{
				return null;
			}
		}

		#endregion Properties

		#region Methods

		public bool Init(INavigationItem navigationItem)
		{
            if (_navigationItem != null)
            {
                _previousNavigationItem = _navigationItem;
            }

            _navigationItem = navigationItem;

			return true;
		}

		public async Task DisplayAlert(Alert alert)
		{
            Device.BeginInvokeOnMainThread(async () =>
            {
                await this.DisplayAlert(alert.Title, alert.Message, alert.OkButtonText);
            });
		}

		/*Using ContentView as the current view container*/
		//private void UpdateView()
		//{
		//	/*
		//	if ((frame.Content == null) || (!frame.Content.GetType().Equals(SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView.GetType())))
		//	{
		//		frame.Content = null;
		//		frame.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
		//	}
		//	*/
		//	//content.Children.Clear();
		//	//content.Children.Add(SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView);

		//	if (content.Content == null)
		//	{
		//		content.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
		//	}
		//	else if (!(content.Content.GetType().Name.Equals(SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView.GetType().Name)))
		//	{
		//		if (SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView.ParentView != null)
		//		{
		//			SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView.Parent = null;
		//		}

		//		try
		//		{
		//			//content.Content = null;
		//			content.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
		//		}
		//		catch(Exception ex)
		//		{
		//			if (!ex.ToString().Contains("Element is already the child of another element"))
		//			{
		//				throw ex;
		//			}
		//			//else
		//			//{
		//			//	content.Content = null;
		//			//	content.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
		//			//}
		//		}
		//	}
		//}

		private bool _isLoading = false;

		/*Using Grid as the current view container*/
		public void UpdateView()
        {
			if (!_isLoading)
			{
				try
				{
					_isLoading = true;

					contentGrid.ForceLayout();

					if (contentGrid.Children.Count > 0)
					{
						contentGrid.Children.Clear();

						contentGrid.ForceLayout();
					}

					contentGrid.Children.Add(SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView);
				}
				finally
				{
					_isLoading = false;
				}
			}
        }

		#endregion Methods
	}
}