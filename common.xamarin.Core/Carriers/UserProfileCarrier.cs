using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.xamarin.Core.Carriers
{
	public class UserProfileCarrier
	{
		#region Properties

		public long UserProfileId
		{ 
			get; 
			set; 
		}

		public string FirstName
		{ 
			get; 
			set; 
		}

		public string LastName
		{ 
			get; 
			set; 
		}

		//public string CountryCode { get; set; }

		//public string LanguageCode { get; set; }

		public string WorkPhone
		{ 
			get; 
			set; 
		}

		public string MobilePhone
		{ 
			get; 
			set; 
		}

		public string HomePhone
		{ 
			get; 
			set; 
		}

		public string Email
		{ 
			get; 
			set; 
		}

		public string TimeZone
		{ 
			get; 
			set; 
		}

		//public int LocaleId { get; set; }

		//public string CurrencyCode { get; set; }

		//public DateTimeOffset CreatedDateTime { get; set; }

		//public bool ReceiveMarketingInfo { get; set; }

		#endregion Properties
	}
}