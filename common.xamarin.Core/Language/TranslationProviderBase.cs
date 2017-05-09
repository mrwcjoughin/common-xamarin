using System;
using System.Resources;

namespace common.xamarin.Core.Language
{
	public abstract class TranslationProviderBase
	{

		public abstract ResourceManager CurrentResourceManager
		{
			get;
		}

		public string GetTranslatedString(string fieldName)
		{
			string result = this.CurrentResourceManager.GetString(fieldName);

			if ((result ?? string.Empty).Length == 0)
			{
				result = fieldName;
			}

			return result;
		}
	}
}