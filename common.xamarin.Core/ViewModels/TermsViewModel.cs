using System.Windows.Input;

//using Cirrious.MvvmCross.ViewModels;
using XLabs;

using common.xamarin.Core.Enums;
using common.xamarin.Core.Language;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;

namespace common.xamarin.Core.ViewModels
{
    public class TermsViewModel : BaseViewModel
    {
        #region Constructors

        public TermsViewModel(IMvxNavigationService navigation)
            : base(navigation)
        {

        }

		#endregion Constructors

		#region Properties

		public string TitleText
        {
            get
            {
				return SessionContext.CurrentTranslationProvider.GetTranslatedString("TermsAndConditionsTitle");
            }
        }

//        public string TermsAndConditionsText
//        {
//            get
//            {
//				return SessionContext.CurrentTranslationProvider.GetTranslatedString("TermsAndConditionsText");
//            }
//        }

        public string TermsOk
        {
            get
            {
				return SessionContext.CurrentTranslationProvider.GetTranslatedString("Ok");
            }
        }

		public string TermsPDF
		{
			get
			{
				return @"TermsAndConditions.pdf";
			}
		}

        #endregion Properties

        #region Methods

        public override async Task NavigateBack ()
        {
			SessionContext.CurrentNavigationHandler.NavigateToLoginPage ();
        }

		public override void UpdateValidation (string specificFieldName = null)
		{
			//Nothing to do here in this ViewModel
		}

        #endregion Methods
    }
}

