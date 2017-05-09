using System;

namespace common.xamarin.Core.Enums
{
	public enum AuthenticateResultStatus
	{
		Error = 0,
		Success = 1,
		InvalidCredentials,
		Locked,
		Disabled,
		Unauthorised,
		Unverified,
		Inactive
	}
}