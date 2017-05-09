using System;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;
using XLabs;

using common.xamarin.Core.Interfaces;
//using common.xamarin.Core.Language;

namespace common.xamarin.Core.Navigation
{
    #region Abstract Class

    public  abstract class MenuOptionItem
	{
		public virtual INavigationPage NavigationPage
		{
			get;
//            set;
		}

		public virtual INavigationView NavigationView
		{
			get;
//            set;
		}

		public virtual string Title 
		{
			get 
			{ 
				var n = GetType().Name; return n.Substring(0, n.Length - 10); 
			} 
		}

		public virtual int Count 
		{ 
			get; 
			set; 
		}

		public virtual bool Selected 
		{ 
			get; 
			set; 
		}

		private Xamarin.Forms.ImageSource _iconImageSource = null;
		public virtual Xamarin.Forms.ImageSource IconImageSource
		{
			get
			{
				if (_iconImageSource == null)
				{
					_iconImageSource = Xamarin.Forms.ImageSource.FromFile(Public.ImagesFolderPath + Title.ToLower().TrimEnd('s') + ".png");
				}

				return _iconImageSource;
			}
		}
		
        public virtual string GroupName
        {
            get
            {
                return "Default";
            }
        }

        private RelayCommand _selectCommand;
        public ICommand SelectCommand
        {
            get
            {
                _selectCommand = _selectCommand ?? new RelayCommand(Select);
                return _selectCommand;
            }
        }

        public void Select()
        {
            try
            {
                //SessionContext.CurrentNavigationHandler.Navigate(new NavigationItem(NavigationPage, NavigationView));
            }
            finally
            {
                //IsLoading = false;
            }
        }
    }

    #endregion Abstract Class
}