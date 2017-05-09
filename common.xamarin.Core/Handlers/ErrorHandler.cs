using System;

using Xamarin.Forms;

using common.xamarin.Core.Interfaces;
using common.xamarin.Core.Language;
using common.xamarin.Core.Helpers;

namespace common.xamarin.Core
{
	public static class ErrorHandler
	{
		public static Action<Exception> SendToRaygun { get; set; }

		public static void HandleError(Exception exception)
		{
			HandleError(null, exception);
		}

		public static void HandleError(string message, Exception exception)
		{
            //if (exception.GetBaseException().GetType().Name.Equals("UnauthorisedException"))
            //{
            //    return;
            //}

//#if DEBUG
//			try
//			{
//				MvxTrace.Trace((message ?? string.Empty) + (exception == null ? string.Empty : " " + exception.Message + "\r\n" + exception.StackTrace));
//			}
//			// ReSharper disable once EmptyGeneralCatchClause
//			catch { }
//
			//try
			//{
   //         	//MessagingCenter.Send<INavigationPage, Alert>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.Exception.ToString(), new Alert((message ?? string.Empty) + (exception == null ? string.Empty : " " + exception.Message + "\r\n" + exception.StackTrace), null, SessionContext.CurrentTranslationProvider.GetTranslatedString("GenericErrorOccurred, SessionContext.CurrentTranslationProvider.GetTranslatedString("Ok));
			//	SessionContext.CurrentNavigationHandler.CurrentPage.DisplayAlert(new Alert((message ?? string.Empty) + (exception == null ? string.Empty : " " + exception.Message + "\r\n" + exception.StackTrace), null, SessionContext.CurrentTranslationProvider.GetTranslatedString("GenericErrorOccurred, SessionContext.CurrentTranslationProvider.GetTranslatedString("Ok));
			//}
			//// ReSharper disable once EmptyGeneralCatchClause
			//catch 
   //         { 
   //             //Do Nothing Intentially
   //         }
            
//#endif

			try
			{
#if !DEBUG
                if (SendToRaygun != null)
                {
					SendToRaygun(exception);
                }
#endif
#if DEBUG
				SessionContext.CurrentNavigationHandler.CurrentPage.DisplayAlert(new Alert((message ?? string.Empty) + (exception == null ? string.Empty : " " + exception.Message + "\r\n" + exception.StackTrace), null, SessionContext.CurrentTranslationProvider.GetTranslatedString("RaygunExceptionMessage"), SessionContext.CurrentTranslationProvider.GetTranslatedString("Ok")));
#endif
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception ex) 
            {
//#if DEBUG
				//MessagingCenter.Send<INavigationPage, Alert>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.Exception.ToString(), new Alert((message ?? string.Empty) + (ex == null ? string.Empty : " " + ex.Message + "\r\n" + exception.StackTrace), null, SessionContext.CurrentTranslationProvider.GetTranslatedString("RaygunExceptionMessage, SessionContext.CurrentTranslationProvider.GetTranslatedString("Ok));
					SessionContext.CurrentNavigationHandler.CurrentPage.DisplayAlert(new Alert((message ?? string.Empty) + (ex == null ? string.Empty : " " + ex.Message + "\r\n" + ex.StackTrace), null, SessionContext.CurrentTranslationProvider.GetTranslatedString("RaygunExceptionMessage"), SessionContext.CurrentTranslationProvider.GetTranslatedString("Ok")));
//#endif
            }
		}
	}
}