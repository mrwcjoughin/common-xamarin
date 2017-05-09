using System.Collections.Generic;
using common.xamarin.Core;
using common.xamarin.Core.Enums;
//using common.xamarin.Core.DTO;

namespace common.xamarin.Core.Interfaces
{
	public interface IDataContext
	{
		#region Caching

		void ClearUserData();
		bool ShouldFetch(ModelType modelType, long organisationId);

		#endregion

		#region Network Connectivity

		bool IsConnected();

		#endregion
	}
}