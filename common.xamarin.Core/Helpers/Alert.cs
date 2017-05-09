using System;

namespace common.xamarin.Core.Helpers
{
	public class Alert
	{
		#region Constructors

		public Alert (string message, Action done = null, string title = "", string okButtonText = "OK")
		{
			Message = message;
			Done = done;
			Title = title;
			OkButtonText = okButtonText;
		}

		#endregion Constructors

		#region Properties

		public string Message
		{
			get;
			set;
		}

		public Action Done
		{
			get;
			set;
		}


		public string Title
		{
			get;
			set;
		}

		public string OkButtonText
		{
			get;
			set;
		}

		#endregion Properties
	}
}