using common.xamarin.Core.Enums;

namespace common.xamarin.Core.Interfaces
{
	public interface IApplicationConfigurationService
	{
		PlatformType GetPlatformType();
		DeviceType GetDeviceType();
		 string GetString( string comment);	 
	}
}

