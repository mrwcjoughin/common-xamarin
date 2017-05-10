using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using common.xamarin.Core.Interfaces;
using common.xamarin.Core.Helpers;
using common.xamarin.Core.ViewModels;

namespace common.xamarin.Core.Pages
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class TermsPage : ContentPage, INavigationPage
    {
        private INavigationItem _navigationItem = null;
        private INavigationItem _previousNavigationItem = null;

        public TermsPage()
        {
			this.Resources = SessionContext.Resources;

			InitializeComponent();

            this.BindingContext = new TermsViewModel();
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

		public bool Init(INavigationItem navigationItem)
		{
            if (_navigationItem != null)
            {
                _previousNavigationItem = _navigationItem;
            }

            _navigationItem = navigationItem;

			return true;
		}

		public common.xamarin.Core.ViewModels.BaseViewModel BaseViewModel
		{
			get
			{
				return (common.xamarin.Core.ViewModels.BaseViewModel)this.BindingContext;
			}
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
