using common.xamarin.Core.Carriers;
using common.xamarin.Core.Interfaces;

namespace common.xamarin.Core.Interfaces
{
	public interface IUserSettings
	{
		bool AutoLogin { get; set; }
		ISettings AppSettings { get; }
		string Username { get; set; }
		string Password { get; set; }
		string Server { get; set; }
		string DeviceToken {get;set;}
		MobilePermissionsCarrier MobilePermissions { get; set; }
		UserProfileCarrier UserProfile { get; set; }
		void Clear();
	}
}

