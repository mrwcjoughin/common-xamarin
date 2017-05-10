using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using common.xamarin.Core.Interfaces;
using common.xamarin.Core.Helpers;

namespace common.xamarin.Core.Pages
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class DefaultPage : ContentPage, INavigationPage
	{
		private INavigationItem _navigationItem;
        private INavigationItem _previousNavigationItem = null;

		public DefaultPage ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent();
		}

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
	}
}