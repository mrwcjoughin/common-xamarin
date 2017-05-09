using System;

using Xamarin.Forms;

using common.xamarin.Core.Interfaces;
using common.xamarin.Core.Views;
//using common.xamarin.Core.Messages;

namespace common.xamarin.Core.ViewModels
{
	public class RootViewModel : BaseViewModel
	{
		private Xamarin.Forms.ContentView _currentView = new DefaultView();
		
		public RootViewModel ()
		{
			//this.PageBackgroundColor = Public.GetPageBackgroundColor();
		}

		public Xamarin.Forms.ContentView CurrentView
		{
			get
			{
				return _currentView;
			}
			set
			{
                if ((_currentView != value) || (!_currentView.Content.GetType().Equals(value.GetType())))
                { 
                    _currentView = value;

				    OnPropertyChanged ("CurrentView");

                    //MessagingCenter.Send<INavigationPage, ChangeViewMessage>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.ChangeView.ToString(), new ChangeViewMessage(this));
					SessionContext.CurrentNavigationHandler.CurrentNavigationPresenter.UpdateView();
                }
			}
		}
	}
}

