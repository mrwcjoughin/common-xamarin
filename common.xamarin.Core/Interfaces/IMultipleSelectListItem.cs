using System;

namespace common.xamarin.Core.Interfaces
{
	public interface IMultipleSelectListItem
	{
		string ListName
		{
			get;
		}

		string ListName2
		{
			get;
		}

		string ListName3
		{
			get;
		}

		string ListName4
		{
			get;
		}

		bool Selected
		{
			get;
			set;
		}

        string ImageUrl
        {
            get;
            set;
        }
	}
}

