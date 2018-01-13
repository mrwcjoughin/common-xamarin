﻿using System;

using Xamarin.Forms;

using common.xamarin.Core.Interfaces;
using common.xamarin.Core.Views;
using MvvmCross.Core.Navigation;
//using common.xamarin.Core.Messages;

namespace common.xamarin.Core.ViewModels
{
	public class RootViewModel : BaseViewModel
	{
		private Xamarin.Forms.ContentView _currentView = null;
		
		public RootViewModel (IMvxNavigationService navigation)
            : base (navigation)
		{
			//this.PageBackgroundColor = Public.GetPageBackgroundColor();
            _currentView = new DefaultView();
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
                    SetProperty(ref _currentView, value);
				    //OnPropertyChanged ("CurrentView");

                    //MessagingCenter.Send<INavigationPage, ChangeViewMessage>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.ChangeView.ToString(), new ChangeViewMessage(this));
					SessionContext.CurrentNavigationHandler.CurrentNavigationPresenter.UpdateView();
                }
			}
		}

		#region Methods

		public override void UpdateValidation (string specificFieldName = null)
		{
			//Nothing to do here in this ViewModel
		}

		#endregion Methods
	}
}