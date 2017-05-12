using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using XLabs;

using MvvmCross.Core.ViewModels;

namespace common.xamarin.Core.ViewModels
{
	public abstract class BaseViewModel : MvxViewModel, INotifyPropertyChanged
	{
		#region Private Fields

		public virtual event PropertyChangedEventHandler PropertyChanged;

		private bool _isLoading;
		private bool _isBusyFetching;
		//private string _modelName;

		//private MvxCommand _doneCommand;
		private IMvxAsyncCommand _backCommand;

		//private Color _pageBackgroundColor = Public.GetPageBackgroundColor();

		#endregion Private Fields

		#region Constructors

		public BaseViewModel ()
		{
			
		}

		#endregion Constructors

		#region Properties

		public bool IsLoading
		{
			get
			{ 
				return _isLoading; 
			}
			set
			{
				SetProperty(ref _isLoading, value);
				NotifyAllBusySecurityRelatedPropertiesChanged ();
				BusyMessage = _isLoading ? "Refreshing..." : string.Empty;
			}
		}

		public virtual bool IsEnabled
		{
			get
			{ 
				return !IsBusy;
			}
		}

		public bool IsBusy
		{
			get
			{ 
				return IsLoading || IsBusyFetching; 
			}
		}

		public string BusyMessage
		{ 
			get; 
			set; 
		}

		//Pull to Refresh things
		public bool IsBusyFetching
		{
			get
			{ 
				return _isBusyFetching; 
			}
			set
			{
				SetProperty(ref _isBusyFetching, value);
				NotifyAllBusySecurityRelatedPropertiesChanged ();
			}
		}

		public virtual bool IsNotBusy
		{
			get
			{
				return !IsBusy;
			}
		}

		public virtual bool IsNewButtonVisible
		{
			get
			{
				return false;
			}
		}

		public IMvxAsyncCommand BackCommand
		{
			get
			{
				_backCommand = _backCommand ?? new MvxAsyncCommand (NavigateBack);
				return _backCommand;
			}
		}

		public virtual bool IsDoneButtonVisible
		{
			get
			{
				return false;
			}
		}

		public GridLength NavigationBarHeight
		{
			get
			{
				return Public.GetNavigationBarHeight ();
			}
		}

		public GridLength SelectedTextHeight
		{
			get
			{
				return Public.GetSelectedTextHeight ();
			}
		}

		public GridLength SearchBarHeight
		{
			get
			{
				return Public.GetSearchBarHeight ();
			}
		}

		public GridLength PageHeight
		{
			get
			{
				return Public.GetPageHeight ();
			}
		}

		public GridLength ViewHeight
		{
			get
			{
				return Public.GetViewHeight ();
			}
		}

		public GridLength SingleGridLengthHeight
		{
			get
			{
				return Public.GetSingleGridLengthHeight ();
			}
		}

		public double SingleGridHeight
		{
			get
			{
				return Public.GetSingleGridHeight ();
			}
		}

		//public double FavouriteGridWidth
		//{
		//    get
		//    {
		//        return Public.GetFavouriteGridWidth();
		//    }
		//}

		public double FavouriteGridWidth
		{
			get
			{
				return Public.GetFavouriteGridWidth();
			}
		}

		public GridLength FavouriteGridLengthWidth
		{
			get
			{
				return Public.GetFavouriteGridLengthWidth ();
			}
		}

		public GridLength MultipleGridHeight
		{
			get
			{
				return Public.GetMultipleGridHeight ();
			}
		}

		public GridLength LoopMessagesGridHeight
		{
			get
			{
				return Public.GetLoopMessagesGridHeight ();
			}
		}

		public GridLength LoopMessagesListViewGridHeight
		{
			get
			{
				return Public.GetLoopMessagesListViewGridHeight ();
			}
		}

		public double FavouriteGridHeight
		{
			get
			{
				return Public.GetFavouriteGridHeight ();
			}
		}

		public GridLength FavouriteGridLengthHeight
		{
			get
			{
				return Public.GetFavouriteGridLengthHeight();
			}
		}

		public string SearchPlaceholderText
		{
			get
			{
				return SessionContext.CurrentTranslationProvider.GetTranslatedString ("Search");
			}
		}

		#endregion Properties

		#region Methods

		public virtual async Task Init()
		{
			
		}

		public virtual void OnPropertyChanged (string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if ((handler != null))
			{
				handler (this, new PropertyChangedEventArgs (propertyName));
			}

			if ((propertyName != "IsBusy") && (propertyName != "IsBusyFetching") && (propertyName != "IsLoading") && (propertyName != "IsEnabled") && (propertyName != "IsNotBusy") ) 
			{
				if (!IsBusy)
				{
					Save ().ConfigureAwait (false);
				}
			}
		}

		public async virtual Task Refresh()
		{
			
		}

		public async virtual Task Save()
		{

		}

		private bool _isNavigatingBack = false;
		public virtual async Task NavigateBack ()
		{
			if (!_isNavigatingBack)
			{
				_isNavigatingBack = true;
				//await SessionContext.CurrentNavigationHandler.CurrentNavigationPage./*Navigation.*/PopModalAsync(true);
				SessionContext.CurrentNavigationHandler.Back ();
				_isNavigatingBack = false;
			}
		}

		private void NotifyAllBusySecurityRelatedPropertiesChanged ()
		{
			OnPropertyChanged ("IsBusy");
			OnPropertyChanged ("IsBusyFetching");
			OnPropertyChanged ("IsLoading");
			OnPropertyChanged ("IsEnabled");
			OnPropertyChanged ("IsNotBusy");
		}

		public abstract void UpdateValidation(string specificFieldName = null);

		#endregion
	}
}