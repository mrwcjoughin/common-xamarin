using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using common.xamarin.Core.ViewModels;

namespace common.xamarin.Core.Interfaces
{
	public interface IEmailHandler
	{
		Task CreateAndOpenEmail(IEmail email, object uiControl);
	}
}
