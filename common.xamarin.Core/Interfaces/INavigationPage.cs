using System;
using System.Threading.Tasks;

using common.xamarin.Core.Enums;
using common.xamarin.Core.Helpers;
using common.xamarin.Core.ViewModels;

namespace common.xamarin.Core.Interfaces
{
	public interface INavigationPage
	{
        INavigationItem NavigationItem
        {
            get;
        }

        INavigationItem PreviousNavigationItem
        {
            get;
        }

		bool Init(INavigationItem navigationItem);

		Task DisplayAlert(Alert alert);
	}
}

