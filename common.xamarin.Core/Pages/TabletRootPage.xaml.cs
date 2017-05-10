using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using common.xamarin.Core.Enums;
using common.xamarin.Core.Interfaces;
using common.xamarin.Core.Helpers;
using common.xamarin.Core.Messages;
using common.xamarin.Core.ViewModels;

namespace common.xamarin.Core.Pages
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class TabletRootPage : ContentPage, INavigationPage
	{
		#region Fields

		private INavigationItem _navigationItem;
        private INavigationItem _previousNavigationItem = null;

		#endregion Fields

		#region Constructors

		public TabletRootPage ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent();

			SessionContext.CurrentNavigationHandler.CurrentRootViewModel = new RootViewModel ();

			this.BindingContext = SessionContext.CurrentNavigationHandler.CurrentRootViewModel;

            MessagingCenter.Subscribe<INavigationPage, ChangeViewMessage>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.ChangeView.ToString(), (page, changeViewMessage) =>
            {
                UpdateView();
            });
		}

		#endregion Constructors

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

        private void UpdateView()
        {
            if (content.Content != SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView)
            {
				content.Content = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
            }
//			content.Children.Clear();
//			ContentView contentView = SessionContext.CurrentNavigationHandler.CurrentRootViewModel.CurrentView;
//			contentView.HorizontalOptions = LayoutOptions.FillAndExpand;
//			contentView.VerticalOptions = LayoutOptions.FillAndExpand;
//			content.Children.Add(contentView);
        }

		#endregion Methods
	}
}