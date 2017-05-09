using System.Threading.Tasks;

//using common.xamarin.Core.Carriers;
using common.xamarin.Core.Enums;

namespace common.xamarin.Core.Interfaces
{
	public interface IAuthenticationManager
	{
		#region Properties

		string AuthToken
		{
			get;
			set; 
		}

		#endregion Properties

		#region Methods

		Task<AuthenticateResultStatus> Login(string username, string password, string serverAddress, bool auto = true);

		Task<AuthenticateResultStatus> TryAutoLogin();

		void StoreDeviceToken();
		void RemoveDeviceToken();

		#endregion Methods
	}
}

