using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Platform.Device;
//using XLabs.Platform.Services.Geolocation;

using common.xamarin.Core;
using common.xamarin.Core.Interfaces;
//using common.xamarin.Core.Services.Contracts;
using common.xamarin.Core.Language;
using common.xamarin.Core.Helpers;
using common.xamarin.Core.ViewModels;
using MvvmCross.Core.ViewModels;

//using common.xamarin.Core.DTO;

namespace common.xamarin.Core
{
	public static class SessionContext
	{
		#region Private Variables

		private static IMvxApplication _app;
		private static ResourceDictionary _resources;
		private static INavigationHandler _currentNavigationHandler;
		private static IEmailHandler _currentEmailHandler;
		private static IUserSettings _userSettings;
		private static IAuthenticationManager _authenticationManager;
		private static IApplicationConfigurationService _applicationConfigurationService;
		private static IDataContext _dataContext;
		private static IAppStartRouter _appStartRouter;
		private static IPlatformCapabilities _platformCapabilities;
        private static IDevice _device;
        private static INativeNavigationHandler _nativeNavigationHandler;
		private static MenuViewModel _menuViewModel;
        //		private static ISettings _settings;
		private static TranslationProviderBase _translationProvider;
		private static string _documentsFolder = string.Empty;

		#endregion Private Variables

        #region Constructors

        //      static SessionContext ()
        //{

        //}

        #endregion Constructors

        #region Properties

		public static IMvxApplication App
		{
			get
			{
				return _app;
			}
			set
			{
				_app = value;
			}
		}

		public static ResourceDictionary Resources
		{
			get
			{
				return _resources;
			}
			set
			{
				_resources = value;
			}
		}

		public static string ApplicationName
		{
			get;
			set;
		}

        public static bool IsLoggedIn
        {
            get;
            set;
        }

		public static string UserName
		{
			get;
			set;
		}

		public static string Password
		{
			get;
			set;
		}

		public static string WebServiceURL
		{
			get
			{
				return "http://52.201.129.218:8080/api/";
			}
		}

		public static INavigationHandler CurrentNavigationHandler
		{
			get
			{
				return _currentNavigationHandler;
			}
			set
			{
				_currentNavigationHandler = value;
			}
		}

		public static IEmailHandler CurrentEmailHandler
		{
			get
			{
				return _currentEmailHandler;
			}
			set
			{
				_currentEmailHandler = value;
			}
		}

		public static IUserSettings CurrentUserSettings
		{
			get
			{
				return _userSettings;
			}
			set
			{
				_userSettings = value;
			}
		}

		public static IAuthenticationManager CurrentAuthenticationManager
		{
			get
			{
				return _authenticationManager;
			}
			set
			{
				_authenticationManager = value;
			}
		}

		public static IApplicationConfigurationService CurrentApplicationConfigurationService
		{
			get
			{
				return _applicationConfigurationService;
			}
			set
			{
				_applicationConfigurationService = value;
			}
		}

		public static IDataContext CurrentDataContext
		{
			get
			{
				return _dataContext;
			}
			set
			{
				_dataContext = value;
			}
		}

		public static IAppStartRouter CurrentAppStartRouter
		{
			get
			{
				return _appStartRouter;
			}
			set
			{
				_appStartRouter = value;
			}
		}

//		public static IMixFleetMobileApiClient CurrentMixFleetMobileApiClient
//		{
//			get
//			{
//				return _mixFleetMobileApiClient;
//			}
//			set
//			{
//				_mixFleetMobileApiClient = value;
//			}
//		}

//		public static IUserManager CurrentUserManager
//		{
//			get
//			{
//				return _userManager;
//			}
//			set
//			{
//				_userManager = value;
//			}
//		}

		public static IPlatformCapabilities CurrentPlatformCapabilities
		{
			get
			{
				return _platformCapabilities;
			}
			set
			{
				_platformCapabilities = value;
			}
		}

        public static IDevice CurrentDevice
		{
			get
			{
				return _device;
			}
			set
			{
                _device = value;
			}
		}

//		public static INativeMapHandler CurrentNativeMapHandler
//        {
//            get
//            {
//                return _nativeMapHandler;
//            }
//            set
//            {
//                _nativeMapHandler = value;
//            }
//        }
//
//		public static IXamarinFormsMapHandler CurrentXamarinFormsMapHandler
//        { 
//			get
//			{
//				return _xamarinFormsMapHandler;
//			}
//			set
//			{
//				_xamarinFormsMapHandler = value;
//			}
//		}

        public static INativeNavigationHandler CurrentNativeNavigationHandler
        {
            get
            {
                return _nativeNavigationHandler;
            }
            set
            {
                _nativeNavigationHandler = value;
            }
        }

//        private static IGeolocator _geolocator = null;
//        public async static Task<XLabs.Platform.Services.Geolocation.Position> GetMyPosition()
//        {
//            if (_geolocator == null)
//            {
//                _geolocator = DependencyService.Get<IGeolocator>();
//            }
//
//            return await _geolocator.GetPositionAsync(6000);
//        }

//		public static ILanguageResolver LanguageResolver
//		{
//			get
//			{
//				return _languageResolver;
//			}
//			set
//			{
//				_languageResolver = value;
//			}
//		}

		public static TranslationProviderBase CurrentTranslationProvider
		{
			get
			{
				return _translationProvider;
			}
			set
			{
				_translationProvider = value;
			}
		}

		public static bool WasOnLoginView
		{
			get;
			set;
		}

		public static MenuViewModel CurrentMenuViewModel
        {
            get
            {
				return _menuViewModel;
            }
            set
            {
				_menuViewModel = value;
            }
        }

        //public static ISettings CurrentSettings
        //{
        //    get
        //    {
        //        return _settings;
        //    }
        //    set
        //    {
        //        _settings = value;
        //    }
        //}

//        public static async Task<ObservableCollection<SettingViewModel>> GetSettingViewModels()
//        {
//            var serverUrls = await ServerUrls.GetCollection();
//            string servername = serverUrls.Where(s => s.Value == SessionContext.CurrentUserSettings.Server).Select(s => s.Key).FirstOrDefault();
//
//            string mapRefreshRateName = new MapRefreshRate(SessionContext.CurrentUserSettings.RefreshMap).Name;
//
//            return new ObservableCollection<SettingViewModel>
//			{
//				new SettingViewModel()
//				{
//					Key = Public.ServerIdentifier,
//                    Name = SessionContext.LanguageResolver.GetTranslatedString("Server,
//                    SettingValue = servername
//				},
//				new SettingViewModel()
//				{
//					Key = Public.MeasurementIdentifier,
//                    Name = SessionContext.LanguageResolver.GetTranslatedString("MeasurementType,
//                    SettingValue = SessionContext.LanguageResolver.GetTranslatedString("GetTheString(SessionContext.CurrentUserSettings.MeasurementType.ToString())
//				},
//				new SettingViewModel()
//				{
//					Key = Public.MapRefreshIdentifier,
//                    Name = SessionContext.LanguageResolver.GetTranslatedString("MapRefreshRate,
//                    SettingValue = mapRefreshRateName
//				},
//				new SettingViewModel()
//				{
//					Key = Public.AutoLoginIdentifier,
//                    Name = SessionContext.LanguageResolver.GetTranslatedString("AutoLogin,
//                    SettingValue = (SessionContext.CurrentUserSettings.AutoLogin ? SessionContext.LanguageResolver.GetTranslatedString("Yes : SessionContext.LanguageResolver.GetTranslatedString("No),
//                    IsChecked = SessionContext.CurrentUserSettings.AutoLogin
//				}
//			};
//        }

//        public static async Task UpdateSettingsOnServer()
//        {
//            string updateProfileResult = string.Empty;
//            try
//            {
//                var result = await _userManager.UpdateUserProfile(_userSettings.UserProfile);
//                updateProfileResult = result == null ? SessionContext.LanguageResolver.GetTranslatedString("UserProfileUpdatedUnSuccessfully : SessionContext.LanguageResolver.GetTranslatedString("UserProfileUpdatedSuccessfully;
//            }
//            catch (Exception ex)
//            {
//                ErrorHandler.HandleError("SettingsViewModel failed to update settings!", ex);
//                updateProfileResult = SessionContext.LanguageResolver.GetTranslatedString("UserProfileUpdatedUnSuccessfully;
//            }
//            finally
//            {
//                //Mvx.Resolve<IUserInteraction>().Alert(updateProfileResult);
//                //MessagingCenter.Send<INavigationPage, Alert>(SessionContext.CurrentNavigationHandler.CurrentPage, Public.MessagingType.Alert.ToString(), new Alert(updateProfileResult.ToString(), null, updateProfileResult, SessionContext.LanguageResolver.GetTranslatedString("Ok));
//                SessionContext.CurrentNavigationHandler.CurrentPage.DisplayAlert(new Alert(updateProfileResult.ToString(), null, "", SessionContext.LanguageResolver.GetTranslatedString("Ok)).ConfigureAwait(false);
//            }
//        }

		public static string DocumentsFolder
		{
			get
			{
				return _documentsFolder;
			}
			set
			{
				_documentsFolder = value;
			}
		}

        #endregion Properties

        #region Methods

        public static void Init()
        {
            //SessionContext.CurrentDataContext = new DataContext();
            //SessionContext.CurrentUserSettings = new UserSettings();
            //SessionContext.CurrentMixFleetMobileApiClient = ApiDataService.Instance();
            //SessionContext.CurrentUserManager = new UserManager();
            //SessionContext.CurrentAuthenticationManager = new SimpleAuthenticationManager();

			//TODO : put in application specific project
//            if (SessionContext.CurrentNavigationHandler == null)
//            {
//                SessionContext.CurrentNavigationHandler = new NavigationHandler();
//            }
        }

        #endregion Methods
    }
}