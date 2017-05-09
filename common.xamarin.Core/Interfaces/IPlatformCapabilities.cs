using Xamarin.Forms;

namespace common.xamarin.Core.Interfaces
{
	public interface IPlatformCapabilities
	{
		bool HasNetworkConnection();
		bool UseLocalCaching();
	}
}