using System;

namespace common.xamarin.Core.Interfaces
{
	public interface IEmail
	{
		#region Properties

		string ToAddresses
		{
			get;
			set;
		}

		string FromAddress
		{
			get;
			set;
		}

		string Subject
		{
			get;
			set;
		}

		string Message
		{
			get;
			set;
		}

		#endregion Properties
	}
}