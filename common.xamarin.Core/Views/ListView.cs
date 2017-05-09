using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public class ListView : Xamarin.Forms.ListView
    {
        #region Fields

        public static readonly BindableProperty MinHeightProperty = BindableProperty.Create("MinHeight", typeof(double), typeof(ListView), 0d);

        #endregion Fields

        #region Properties

        public double MinHeight
        {
            get
            {
                return (double)GetValue(MinHeightProperty);
            }
            set
            {
                SetValue(MinHeightProperty, value);
            }
        }

        #endregion Properties

		public void Test()
		{
			//this.ScrollTo(null, ScrollToPosition.End,false)
		}
    }
}