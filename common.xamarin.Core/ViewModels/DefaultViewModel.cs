using System;
using MvvmCross.Core.Navigation;

namespace common.xamarin.Core.ViewModels
{
	public class DefaultViewModel : BaseViewModel
	{
        #region Constructors

        public DefaultViewModel(IMvxNavigationService navigation)
            : base (navigation)
		{
			this.IsLoading = true;
		}

		#endregion Constructors

		#region Methods

		public override void UpdateValidation (string specificFieldName = null)
		{
			//Nothing to do here in this ViewModel
		}

		#endregion Methods
	}
}