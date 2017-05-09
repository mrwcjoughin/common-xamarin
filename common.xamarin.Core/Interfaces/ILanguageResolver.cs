using System;

namespace common.xamarin.Core.Interfaces
{
	public interface ILanguageResolver
	{
		#region Methods

		string GetTranslatedString(string field);

		#endregion Methods
	}
}