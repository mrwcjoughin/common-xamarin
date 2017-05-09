using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.CognitoIdentity;

//using SQLite;
using Xamarin.Forms;
using XLabs.Platform.Services.Media;

using common.xamarin.Core;
using common.xamarin.Core.Interfaces;
using common.xamarin.Core.Enums;
using common.xamarin.Core.Helpers;

namespace common.xamarin.Core
{
	public static class Public
    {
        #region Consts

        public const string ServerIdentifier = "ServerIdentifier";
        public const string MeasurementIdentifier = "MeasurementIdentifier";
        public const string MapRefreshIdentifier = "MapRefreshIdentifier";
        public const string AutoLoginIdentifier = "AutoLoginIdentifier";

        #endregion Consts

        #region Enums

        public enum MessagingType
        {
            //Alert,
            //Exception,
//            SelectionsChange,
            MapFollow,
            MapRefresh,
            SettingChanged,
//            RefreshFavourite,
//            ToggleFlyoutMenu,
            ChangeView,
            EventsChange,
            //MapPopupViewTop,
            //MapPopupViewBottom,
            //ShareInfo,
            //MapChangeMapType,
            //MapUpdateZoom,
//            SelectServer,
//            SelectAsset,
//            SelectAssetWithoutChangingIsSelected,
//            SelectSite,
//            SelectSiteWithoutChangingIsSelected,
//            SelectDriver,
//            SelectDriverWithoutChangingIsSelected,
//            SelectEvent,
//            SelectEventWithoutChangingIsSelected,
//            UpdatedSelectedCount,
//            SelectAllEvents
        }

        #endregion Enums

        #region Private Variables

		private static Xamarin.Forms.Color _aliensBlueColor = Xamarin.Forms.Color.Default;
        //private static readonly List<UriImageSourceCache> _uriImageSourceCacheList = new List<UriImageSourceCache> ();
        //private static object _uriImageSourceCacheListLock = new object ();


        #endregion Private Variables

        #region Public Properties

        //public static List<UriImageSourceCache> UriImageSourceCacheList
        //{
        //    get
        //    {
        //        return _uriImageSourceCacheList;
        //    }
        //}

        //private static readonly List<long> _followedList = new List<long> ();

        //public static List<long> FollowedList
        //{
        //    get
        //    {
        //        return _followedList;
        //    }
        //}

        private static string _imagesFolder = null;

        public static string ImagesFolderPath
        {
            get
            {
                if (_imagesFolder == null)
                {
                    Device.OnPlatform (iOS: () => _imagesFolder = "Images/", Android: () => _imagesFolder = "", WinPhone: () => _imagesFolder = "Resources/Images/");
                }

                return _imagesFolder;
            }
        }

        public static Xamarin.Forms.Color aliensBlueColor
        {
            get
            {
				if (_aliensBlueColor == Xamarin.Forms.Color.Default)
                {
					_aliensBlueColor = Xamarin.Forms.Color.FromHex ("#00AEEF");
                }

				return _aliensBlueColor;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public static Xamarin.Forms.Color GetPageBackgroundColor ()
        {
            Xamarin.Forms.Color result = Xamarin.Forms.Color.White;

            Device.OnPlatform (iOS: () => result = Xamarin.Forms.Color.White, Android: () => result = Xamarin.Forms.Color.White, WinPhone: () => result = Xamarin.Forms.Color.Black);

            return result;
        }

        public static GridLength GetNavigationBarHeight ()
        {
            GridLength result = 0;

            Device.OnPlatform (iOS: () => result = 40, Android: () => result = 40, WinPhone: () => result = 70);

            return result;
        }

        public static GridLength GetSelectedTextHeight ()
        {
            GridLength result = 0;

            Device.OnPlatform (iOS: () => result = 30, Android: () => result = 30, WinPhone: () => result = 35);

            return result;
        }

        public static GridLength GetSearchBarHeight ()
        {
            GridLength result = 0;

            Device.OnPlatform (iOS: () => result = 31, Android: () => result = 31, WinPhone: () => result = 51);

            return result;
        }

		public static GridLength GetPageHeight ()
        {
            GridLength result = 0;

            if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
            {
                Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.Height - 20), 
				                   Android: () => result = SessionContext.CurrentDevice.Display.Height, 
				                   WinPhone: () => result = SessionContext.CurrentDevice.Display.Height);
            }
            else
            {
                Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - 20), 
				                   Android: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display))), 
				                   WinPhone: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display))));
            }

            return result;
        }

		public static GridLength GetViewHeight ()
		{
			GridLength result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
			{
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.Height - 20 - 40),
								   Android: () => result = SessionContext.CurrentDevice.Display.Height,
								   WinPhone: () => result = SessionContext.CurrentDevice.Display.Height);
			}
			else
			{
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display)) - 20 - 40),
								   Android: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display))),
								   WinPhone: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display))));
			}

			return result;
		}

		public static double GetSingleGridHeight ()
        {
            double result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
            {
				Device.OnPlatform (iOS: () => result = SessionContext.CurrentDevice.Display.Height, 
				                   Android: () => result = (SessionContext.CurrentDevice.Display.Height - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - 25), 
				                   WinPhone: () => result = SessionContext.CurrentDevice.Display.Height);
            }
            else
            {
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display))), 
				                   Android: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - 25), 
				                   WinPhone: () => result = SessionContext.CurrentDevice.Display.Height);
            }

            return result;
        }

		public static GridLength GetSingleGridLengthHeight ()
		{
			GridLength result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
			{
				Device.OnPlatform (iOS: () => result = SessionContext.CurrentDevice.Display.Height, Android: () => result = (SessionContext.CurrentDevice.Display.Height - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - 25), WinPhone: () => result = GridLength.Auto);
			}
			else
			{
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display))), Android: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - 25), WinPhone: () => result = GridLength.Auto);
			}

			return result;
		}

		public static GridLength GetMultipleGridHeight ()
        {
            GridLength result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
            {
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.Height - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - GetSelectedTextHeight ().Value - 60), 
								   Android: () => result = (SessionContext.CurrentDevice.Display.Height - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - GetSelectedTextHeight ().Value - 85), 
								   WinPhone: () => result = GridLength.Auto);
            }
            else
            {
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - GetSelectedTextHeight ().Value - 60), 
								   Android: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - GetSelectedTextHeight ().Value - 85), 
								   WinPhone: () => result = GridLength.Auto);
            }

            return result;
        }

		public static GridLength GetLoopMessagesGridHeight ()
		{
			GridLength result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
			{
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.Height - 20 - 40 - 12 - 30 - 30),
								   Android: () => result = SessionContext.CurrentDevice.Display.Height,
								   WinPhone: () => result = SessionContext.CurrentDevice.Display.Height);
			}
			else
			{
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display)) - 20 - 40 - 12 - 30 - 30),
								   Android: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display))),
								   WinPhone: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display))));
			}

			return result;
		}

		public static GridLength GetLoopMessagesListViewGridHeight ()
		{
			GridLength result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
			{
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.Height - 20 - 40 - 12 - 30 - 30 - 72),
								   Android: () => result = SessionContext.CurrentDevice.Display.Height,
								   WinPhone: () => result = SessionContext.CurrentDevice.Display.Height);
			}
			else
			{
				Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display)) - 20 - 40 - 12 - 30 - 30 - 72),
								   Android: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display))),
								   WinPhone: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches (SessionContext.CurrentDevice.Display))));
			}

			return result;
		}

		public static double GetFavouriteGridWidth()
        {
            double result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
            {
                Device.OnPlatform(iOS: () => result = SessionContext.CurrentDevice.Display.Width, 
				                  Android: () => result = SessionContext.CurrentDevice.Display.Width,
				                  WinPhone: () => result = SessionContext.CurrentDevice.Display.Width);
            }
            else
            {
                Device.OnPlatform(iOS: () => result = (SessionContext.CurrentDevice.Display.WidthRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenWidthInches (SessionContext.CurrentDevice.Display))), 
				                  Android: () => result = (SessionContext.CurrentDevice.Display.WidthRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenWidthInches(SessionContext.CurrentDevice.Display))), 
				                  WinPhone: () => result = (SessionContext.CurrentDevice.Display.WidthRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenWidthInches(SessionContext.CurrentDevice.Display))));
            }

            return result;
        }

		public static GridLength GetFavouriteGridLengthWidth ()
		{
			GridLength result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
			{
				Device.OnPlatform (iOS: () => result = GridLength.Auto, Android: () => result = (SessionContext.CurrentDevice.Display.Width), WinPhone: () => result = SessionContext.CurrentDevice.Display.Width);
			}
			else
			{
				Device.OnPlatform (iOS: () => result = GridLength.Auto, Android: () => result = (SessionContext.CurrentDevice.Display.WidthRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenWidthInches (SessionContext.CurrentDevice.Display))), WinPhone: () => result = (SessionContext.CurrentDevice.Display.WidthRequestInInches (XLabs.Platform.Device.DisplayExtensions.ScreenWidthInches (SessionContext.CurrentDevice.Display))));
			}

			return result;
		}

		public static GridLength GetFavouriteGridLengthHeight ()
        {
            GridLength result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
            {
                Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.Height - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - 150), Android: () => result = (SessionContext.CurrentDevice.Display.Height - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - 60), WinPhone: () => result = GridLength.Auto);
            }
            else
            {
                Device.OnPlatform (iOS: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value) - 150, Android: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight ().Value - GetSearchBarHeight ().Value - 60), WinPhone: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight().Value - GetSearchBarHeight().Value - 50));
            }

            return result;
        }

		public static double GetFavouriteGridHeight()
        {
            double result = 0;

			if ((SessionContext.CurrentDevice.Display.Xdpi == 0) || (SessionContext.CurrentDevice.Display.Ydpi == 0))
            {
                Device.OnPlatform(iOS: () => result = (SessionContext.CurrentDevice.Display.Height - GetNavigationBarHeight().Value - GetSearchBarHeight().Value - 150), Android: () => result = (SessionContext.CurrentDevice.Display.Height - GetNavigationBarHeight().Value - GetSearchBarHeight().Value - 60), WinPhone: () => result = (SessionContext.CurrentDevice.Display.Height - GetNavigationBarHeight().Value - GetSearchBarHeight().Value - 60));
            }
            else
            {
                Device.OnPlatform(iOS: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight().Value - GetSearchBarHeight().Value) - 150, Android: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight().Value - GetSearchBarHeight().Value - 60), WinPhone: () => result = (SessionContext.CurrentDevice.Display.HeightRequestInInches(XLabs.Platform.Device.DisplayExtensions.ScreenHeightInches(SessionContext.CurrentDevice.Display)) - GetNavigationBarHeight().Value - GetSearchBarHeight().Value - 50));
            }

            return result;
        }
        
		public static byte[] StringToByteArray (String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes [i / 2] = Convert.ToByte (hex.Substring (i, 2), 16);
            return bytes;
        }

        public static string HexToChar (string hex)
        {
            //return ((char)ulong.Parse(hex.ToUpper(), System.Globalization.NumberStyles.HexNumber)).ToString();

            //hex = hex.ToUpper();
            //int value = Convert.ToInt32(hex, 16);
            //char charValue = (char)value;
            //string stringValue = charValue.ToString();
            ////string stringValue = Char.ConvertFromUtf32(value);

            //return stringValue;

            byte[] hexBytes = StringToByteArray (hex);

            char[] c = Encoding.BigEndianUnicode.GetChars (hexBytes);
            string result = string.Join (string.Empty, c);
            return result;

            /*
            string result;
            System.Byte code;

            code = System.Byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            //return ((char)Convert.ToUInt16(hex, 16)).ToString();
            Encoding enc = Encoding.GetEncoding("UTF-8");
            
            System.Byte[] ch = new System.Byte[1];
            ch[0] = code;

            result = enc.GetString(ch,0,1);

            return result;
            */
        }

        public static Xamarin.Forms.Color ConvertToIconColorToXamarinColor (string iconColor)
        {
            Xamarin.Forms.Color result = Xamarin.Forms.Color.Silver;

            //iconColor = iconColor ?? result;

            switch (iconColor)
            {
            case "blue":
                result = Xamarin.Forms.Color.Blue;
                break;
            case "lightBlue":
                result = Xamarin.Forms.Color.Teal;
                break;
            case "red":
                result = Xamarin.Forms.Color.Red;
                break;
            case "dimGray":
                result = Xamarin.Forms.Color.Gray;
                break;
            case "fireBrick":
                result = Xamarin.Forms.Color.Maroon;
                break;
            default:
                result = Xamarin.Forms.Color.Silver;
                break;
            }

            return result;
        }

        public static string ConvertAssetIconToFontCharacter (string icon)
        {
            string result = string.Empty;

            switch (icon)
            {
            case "forklift-left":
                result = HexToChar ("e600");
                break;
            case "forklift-right":
                result = HexToChar ("e601");
                break;
            case "batmobile2-left":
                result = HexToChar ("e603");
                break;
            case "batmobile2-right":
                result = HexToChar ("e602");
                break;
            case "batmobile-left":
                result = HexToChar ("e611");
                break;
            case "batmobile-right":
                result = HexToChar ("e605");
                break;
            case "boat-left":
                result = HexToChar ("e604");
                break;
            case "boat-right":
                result = HexToChar ("e612");
                break;
            case "bulldozer-left":
                result = HexToChar ("e606");
                break;
            case "bulldozer-right":
                result = HexToChar ("e607");
                break;
            case "bus-left":
                result = HexToChar ("e608");
                break;
            case "bus-right":
                result = HexToChar ("e609");
                break;
            case "car2-left":
                result = HexToChar ("e60a");
                break;
            case "car2-right":
                result = HexToChar ("e60b");
                break;
            case "car3-left":
                result = HexToChar ("e60c");
                break;
            case "car3-right":
                result = HexToChar ("e60d");
                break;
            case "car4-left":
                result = HexToChar ("e60e");
                break;
            case "car4-right":
                result = HexToChar ("e60f");
                break;
            case "car5-left":
                result = HexToChar ("e610");
                break;
            case "car5-right":
                result = HexToChar ("e613");
                break;
            case "car-left":
                result = HexToChar ("e614");
                break;
            case "car-right":
                result = HexToChar ("e616");
                break;
            case "cement-truck-left":
                result = HexToChar ("e617");
                break;
            case "cement-truck-right":
                result = HexToChar ("e615");
                break;
            case "crane2-left":
                result = HexToChar ("e618");
                break;
            case "crane2-right":
                result = HexToChar ("e619");
                break;
            case "crane-left":
                result = HexToChar ("e61a");
                break;
            case "crane-right":
                result = HexToChar ("e61c");
                break;
            case "ems-left":
                result = HexToChar ("e61d");
                break;
            case "ems-right":
                result = HexToChar ("e61b");
                break;
            case "flatbed-truck-left":
                result = HexToChar ("e61e");
                break;
            case "flatbed-truck-right":
                result = HexToChar ("e61f");
                break;
            case "generator2-left":
                result = HexToChar ("e620");
                break;
            case "generator2-right":
                result = HexToChar ("e621");
                break;
            case "generator-left":
                result = HexToChar ("e622");
                break;
            case "generator-right":
                result = HexToChar ("e623");
                break;
            case "key-left":
                result = HexToChar ("e624");
                break;
            case "key-right":
                result = HexToChar ("e626");
                break;
            case "ldv-left":
                result = HexToChar ("e63a");
                break;
            case "ldv-right":
                result = HexToChar ("e625");
                break;
            case "motorcycle-left":
                result = HexToChar ("e638");
                break;
            case "motorcycle-right":
                result = HexToChar ("e627");
                break;
            case "person":
                result = HexToChar ("e628");
                break;
            case "phone":
                result = HexToChar ("e629");
                break;
            case "plough-left":
                result = HexToChar ("e62a");
                break;
            case "plough-right":
                result = HexToChar ("e62b");
                break;
            case "tanker-left":
                result = HexToChar ("e62c");
                break;
            case "tanker-right":
                result = HexToChar ("e62d");
                break;
            case "tipper-left":
                result = HexToChar ("e62e");
                break;
            case "tipper-right":
                result = HexToChar ("e62f");
                break;
            case "trailer2-left":
                result = HexToChar ("e630");
                break;
            case "trailer2-right":
                result = HexToChar ("e631");
                break;
            case "trailer-left":
                result = HexToChar ("e632");
                break;
            case "trailer-right":
                result = HexToChar ("e633");
                break;
            case "train-left":
                result = HexToChar ("e634");
                break;
            case "train-right":
                result = HexToChar ("e635");
                break;
            case "truck-left":
                result = HexToChar ("e636");
                break;
            case "truck-right":
                result = HexToChar ("e637");
                break;
            case "van-left":
                result = HexToChar ("e639");
                break;
            case "van-right":
                result = HexToChar ("e63b");
                break;
                    
            default:
                //result = "");
                break;
            }
            
            //result = "M";

            return result;
        }

        public static string GetAssetIconFont ()
        {
            string result = string.Empty;

            Device.OnPlatform (iOS: () => result = "Assets", Android: () => result = "Assets", WinPhone: () => result = @"Assets\Fonts\Assets.ttf#Assets");
            
            return result;
        }

        public static string GetMovementStatusBorderRingFont ()
        {
            string result = string.Empty;

            Device.OnPlatform (iOS: () => result = "Wingdings 2", Android: () => result = "Wingdings 2", WinPhone: () => result = @"Assets\Fonts\WINGDNG2.TTF#Wingdings 2");
            
            return result;
        }

        public static Xamarin.Forms.NavigationPage GetPageWrappedInNavigationPage (ContentPage contentPage)
        {
            return new Xamarin.Forms.NavigationPage (contentPage) {
                BarTextColor = Xamarin.Forms.Color.White,
                BarBackgroundColor = Xamarin.Forms.Color.Black/*, Icon=Public.GetHamburgerIcon()*/
            };
        }

        public static Xamarin.Forms.UriImageSource GetImageUrlImageSource (string url)
        {
            UriImageSource result = null;

            if ((url != null) && (url.Length > 0))
            {
                //lock (Public._uriImageSourceCacheListLock)
                //{
                //    result = (from il in Public._uriImageSourceCacheList
                //              where il.Url == url
                //              select il.UriImageSource).FirstOrDefault();

                //    if (result == null)
                //    {
                        
                if (!url.Contains ("?width="))
                {
                    url = url + "?width=100&height=100&mode=crop";
                }

                result = new UriImageSource { CachingEnabled = false, Uri = new Uri (url, UriKind.Absolute) };

                //Public._uriImageSourceCacheList.Add(new Helpers.UriImageSourceCache() { UriImageSource = result, Url = url });
                //    }
                //}
            }

            return result;
        }

        public static string Left (this String stringValue, int noOfCharacters)
        {
            string result = null;

            if (stringValue.Length >= noOfCharacters)
            {
                result = stringValue.Substring (0, noOfCharacters);
            } else
            {
                result = "";
            }

            return result;
        }

        public static string Right (this String stringValue, int noOfCharacters)
        {
            string result = null;

            if (stringValue.Length >= noOfCharacters)
            {
                result = stringValue.Substring (stringValue.Length - noOfCharacters, noOfCharacters);
            } else
            {
                result = "";
            }

            return result;
        }

		public static async System.Threading.Tasks.Task<string> UploadImageMediaFileToAWSS3 (string awsS3BucketName, string awsS3BucketFolderName, string key, MediaFile imageMediaFile)
		{
			string result = string.Empty;

			try
			{
				AWSConfigs.AWSRegion = "us-east-1";

				//CognitoAWSCredentials credentials = new CognitoAWSCredentials ("us-east-1_A5U7804fi", RegionEndpoint.USEast1);
				//CognitoAWSCredentials credentials = new CognitoAWSCredentials ()"arn:aws:cognito-idp:us-east-1:229523761449:userpool/us-east-1_A5U7804fi", RegionEndpoint.USEast1);
				AmazonS3Config amazonS3Config = new AmazonS3Config ();

				amazonS3Config.RegionEndpoint = RegionEndpoint.USEast1;
				amazonS3Config.UseHttp = false;
				amazonS3Config.Timeout = new TimeSpan (0, 3, 0);
				amazonS3Config.MaxErrorRetry = 2;

				//AmazonS3Client s3Client = new AmazonS3Client (credentials, amazonS3Config);
				AmazonS3Client s3Client = new AmazonS3Client ("AKIAJODBTHGRVLFSZFLQ", "9+j+kS2ThDL0H9vyu9oOdJf8KbaNOyzZAWWN9UnN", amazonS3Config);

				TransferUtilityConfig config = new TransferUtilityConfig ();
				config.MinSizeBeforePartUpload = 11111;
				config.ConcurrentServiceRequests = 1;

				Amazon.S3.Transfer.TransferUtility transferUtility = new Amazon.S3.Transfer.TransferUtility (s3Client);
				//Amazon.S3.Transfer.TransferUtility transferUtility = new Amazon.S3.Transfer.TransferUtility ("AKIAJODBTHGRVLFSZFLQ", "9+j+kS2ThDL0H9vyu9oOdJf8KbaNOyzZAWWN9UnN", RegionEndpoint.USEast1, config);

				await transferUtility.UploadAsync (imageMediaFile.Path, awsS3BucketName, key);
				//await transferUtility.UploadAsync (pathToDb, awsS3BucketName, key);
			}
			catch(Exception exception)
			{
				result = exception.ToString ();
			}

			return result;
		}

		public static async System.Threading.Tasks.Task<string> DownloadImageMediaFileToAWSS3 (string awsS3BucketName, string awsS3BucketFolderName, string key)
		{
			string result = string.Empty;
			bool fileAlreadyDownloaded = false;

			try
			{
				var fileResult = await PCLStorage.FileSystem.Current.GetFileFromPathAsync (Path.Combine (SessionContext.DocumentsFolder, key)).ConfigureAwait (false);

				fileAlreadyDownloaded = (fileResult != null);
			}
			catch(Exception)
			{
				//Do Nothing Intentially
			}

			if (!fileAlreadyDownloaded)
			{
				try
				{
					AWSConfigs.AWSRegion = "us-east-1";

					//CognitoAWSCredentials credentials = new CognitoAWSCredentials ("us-east-1_A5U7804fi", RegionEndpoint.USEast1);
					//CognitoAWSCredentials credentials = new CognitoAWSCredentials ()"arn:aws:cognito-idp:us-east-1:229523761449:userpool/us-east-1_A5U7804fi", RegionEndpoint.USEast1);
					AmazonS3Config amazonS3Config = new AmazonS3Config ();

					amazonS3Config.RegionEndpoint = RegionEndpoint.USEast1;
					amazonS3Config.UseHttp = true;
					amazonS3Config.Timeout = new TimeSpan (0, 0, 30);
					amazonS3Config.MaxErrorRetry = 0;

					//AmazonS3Client s3Client = new AmazonS3Client (credentials, amazonS3Config);
					AmazonS3Client s3Client = new AmazonS3Client ("AKIAJODBTHGRVLFSZFLQ", "9+j+kS2ThDL0H9vyu9oOdJf8KbaNOyzZAWWN9UnN", amazonS3Config);

					TransferUtilityConfig config = new TransferUtilityConfig ();
					config.MinSizeBeforePartUpload = 16 * 1024 * 1024;
					config.ConcurrentServiceRequests = 10;

					Amazon.S3.Transfer.TransferUtility transferUtility = new Amazon.S3.Transfer.TransferUtility (s3Client);
					//Amazon.S3.Transfer.TransferUtility transferUtility = new Amazon.S3.Transfer.TransferUtility ("AKIAJODBTHGRVLFSZFLQ", "9+j+kS2ThDL0H9vyu9oOdJf8KbaNOyzZAWWN9UnN", RegionEndpoint.USEast1, config);

					TransferUtilityDownloadRequest transferUtilityDownloadRequest = new TransferUtilityDownloadRequest ();
					transferUtilityDownloadRequest.BucketName = awsS3BucketName;
					transferUtilityDownloadRequest.Key = key;
					transferUtilityDownloadRequest.FilePath = Path.Combine (SessionContext.DocumentsFolder, key);

					await transferUtility.DownloadAsync (transferUtilityDownloadRequest).ConfigureAwait(false); //iaFile.Path, awsS3BucketName, key);

					//MediaFile mediaFile = 
				}
				catch (Exception exception)
				{
					result = exception.ToString ();
				}
			}

			return result;
		}

        #endregion Public Methods
    }
}