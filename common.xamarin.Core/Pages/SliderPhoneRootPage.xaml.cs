using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using common.xamarin.Core.Enums;
using common.xamarin.Core.Interfaces;
//using common.xamarin.Core.Messages;
using common.xamarin.Core.Helpers;
using common.xamarin.Core.ViewModels;
using MvvmCross.Core.Navigation;

namespace common.xamarin.Core.Pages
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class SliderPhoneRootPage : MasterDetailPage, INavigationPage, INavigationPresenter, IMasterDetailHandler
    {
        #region Fields

        private INavigationItem _navigationItem;
        private INavigationItem _previousNavigationItem = null;

        #endregion Fields

        public SliderPhoneRootPage (IMvxNavigationService navigation)
        {
			this.Resources = SessionContext.Resources;

			InitializeComponent();

            Xamarin.Forms.NavigationPage.SetHasNavigationBar (this, false);

            if (SessionContext.CurrentNativeNavigationHandler != null)
            {
                SessionContext.CurrentNativeNavigationHandler.HideNativeNavigationBar();
            }

            SessionContext.CurrentNavigationHandler.CurrentNavigationPresenter = this;

            SessionContext.CurrentNavigationHandler.CurrentRootViewModel = new RootViewModel(navigation);

            this.BindingContext = SessionContext.CurrentNavigationHandler.CurrentRootViewModel;

            SessionContext.CurrentNavigationHandler.CurrentMasterDetailPage = this;
            SessionContext.CurrentNavigationHandler.CurrentMasterDetailHandler = this;

            Xamarin.Forms.NavigationPage.SetHasNavigationBar (menuPage, false);
            Xamarin.Forms.NavigationPage.SetHasNavigationBar (detailPage, false);

            //MessagingCenter.Subscribe<INavigationPage, Alert>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.Alert.ToString(), (page, alert) =>
            //{
            //  this.DisplayAlert(alert.Title, alert.Message, alert.OkButtonText);
            //});

            //MessagingCenter.Subscribe<INavigationPage, Alert>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.Exception.ToString(), (page, alert) =>
            //{
            //  this.DisplayAlert(alert.Title, alert.Message, alert.OkButtonText);
            //});

            //UpdateView();

            //MessagingCenter.Subscribe<INavigationPage, ChangeViewMessage>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.ChangeView.ToString(), (page, changeViewMessage) =>
            //{
            //  if (!_isLoading)
            //  {
            //      try
            //      {
            //          _isLoading = true;

            //          UpdateView();
            //      }
            //      finally
            //      {
            //          _isLoading = false;
            //      }
            //  }
            //});
      

            this.IsPresentedChanged += (object sender, EventArgs e) => {
                Task.Run(async () =>
                    {
                        await RefreshMenu();
                    });
                
            };


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
				return (common.xamarin.Core.ViewModels.BaseViewModel)this.BindingContext;
			}
		}

        #endregion Properties

        #region Methods

        public bool Init(INavigationItem navigationItem)
        {
//			if ((_navigationItem != null) && (_navigationItem.NavigationView != "common.xamarin.Core.Views.Menu"))
//            {
//                _previousNavigationItem = _navigationItem;
//            }

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
        //  /*
        //  if ((frame.Content == null) || (!frame.Content.GetType().Equals(SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView.GetType())))
        //  {
        //      frame.Content = null;
        //      frame.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
        //  }
        //  */
        //  //content.Children.Clear();
        //  //content.Children.Add(SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView);

        //  if (content.Content == null)
        //  {
        //      content.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
        //  }
        //  else if (!(content.Content.GetType().Name.Equals(SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView.GetType().Name)))
        //  {
        //      if (SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView.ParentView != null)
        //      {
        //          SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView.Parent = null;
        //      }

        //      try
        //      {
        //          //content.Content = null;
        //          content.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
        //      }
        //      catch(Exception ex)
        //      {
        //          if (!ex.ToString().Contains("Element is already the child of another element"))
        //          {
        //              throw ex;
        //          }
        //          //else
        //          //{
        //          //  content.Content = null;
        //          //  content.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
        //          //}
        //      }
        //  }
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

                    Xamarin.Forms.NavigationPage.SetHasNavigationBar (this, false);

                    if (SessionContext.CurrentNativeNavigationHandler != null)
                    {
                        SessionContext.CurrentNativeNavigationHandler.HideNativeNavigationBar();
                    }

                    Xamarin.Forms.NavigationPage.SetHasNavigationBar (menuPage, false);
                    Xamarin.Forms.NavigationPage.SetHasNavigationBar (detailPage, false);

//					if (_navigationItem.NavigationView == "common.xamarin.Core.Views.Menu")
//                    {
//                        //this.IsPresented = !this.IsPresented;
//                        _navigationItem = _previousNavigationItem;
//                    }
//                    else
//                    {
//                        contentGrid.ForceLayout();
//
//                        if (contentGrid.Children.Count > 0)
//                        {
//                            contentGrid.Children.Clear();
//
//                            contentGrid.ForceLayout();
//                        }
//
//                        contentGrid.BindingContext = null;
//
//                        contentGrid.Children.Add(SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView);
//
//                        contentGrid.ForceLayout();

                        contentView.ForceLayout();

                        if (contentView.Content != null)
                        {
                            contentView.Content = null;

                            contentView.ForceLayout();
                        }

                        contentView.BindingContext = null;

                        contentView.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;

                        contentView.ForceLayout();
//                    }

                    //Xamarin.Forms.NavigationPage.SetHasNavigationBar (menuPage, false);
                    //Xamarin.Forms.NavigationPage.SetHasNavigationBar (detailPage, false);
                }
                finally
                {
                    _isLoading = false;
                }
            }
        }

        public async Task RefreshMenu()
        {
            await menuView.MenuViewModel.Refresh();
        }

        #endregion Methods
    

    }
}