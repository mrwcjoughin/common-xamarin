using System;

namespace common.xamarin.Core
{
	public abstract class BaseMessage
    {
        #region Fields
        
        private object _sender = null;

        #endregion Fields

        #region Constructors
        
        public BaseMessage (object sender)
		{
            _sender = sender;
		}

        #endregion Constructors

        #region Methods

        public object Sender
		{
			get
			{
                return _sender;
			}
        }

        #endregion Methods
    }
}