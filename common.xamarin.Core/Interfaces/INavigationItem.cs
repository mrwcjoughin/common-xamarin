using System;

using common.xamarin.Core.Enums;

namespace common.xamarin.Core.Interfaces
{
	public interface INavigationItem
	{
        INavigationPage NavigationPage
		{
			get;
			set;
		}

		INavigationView NavigationView
        {
            get;
            set;
        }

		object Payload
		{
			get;
			set;
		}
	}
}