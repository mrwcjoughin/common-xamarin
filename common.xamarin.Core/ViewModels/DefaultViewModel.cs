using System;

namespace common.xamarin.Core.ViewModels
{
	public class DefaultViewModel : BaseViewModel
	{
		#region Constructors

		public DefaultViewModel ()
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