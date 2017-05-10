using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.xamarin.Core.Messages
{
    public class ChangeViewMessage : BaseMessage
    {
        public ChangeViewMessage(object sender)
            : base(sender)
        {
            //Do Nothing Extra Intentionally
        }
    }
}
