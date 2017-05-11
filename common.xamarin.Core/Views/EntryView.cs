using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public class EntryView : Xamarin.Forms.Entry
	{
		#region Fields

		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(EntryView), Color.Black);
		public static readonly BindableProperty FontProperty = BindableProperty.Create("Font", typeof(Font), typeof(EntryView), new Font());
//		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(Double), typeof(EntryView), new Double());
		//public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create<EntryView, Color> (p => p.PlaceholderColor, Color.Default);
		//public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create("PlaceholderColor", typeof(Color), typeof(EntryView), Color.Black);
		public static readonly BindableProperty ValidationTextProperty = BindableProperty.Create("ValidationText", typeof(string), typeof(EntryView), string.Empty);

		#endregion Fields

		#region Constructors

		public EntryView ()
		{
			
		}

		#endregion Constructors

		#region Properties

		public Color BorderColor 
		{
			get 
			{
				return (Color)GetValue (BorderColorProperty);
			}
			set
			{
				SetValue (BorderColorProperty, value);
			}
		}

		public Font Font
		{
			get 
			{ 
				return (Font)GetValue(FontProperty); 
			}
			set 
			{ 
				SetValue(FontProperty, value); 
			}
		}

//		public Double FontSize
//		{
//			get 
//			{ 
//				return (Double)GetValue(FontSizeProperty); 
//			}
//			set 
//			{ 
//				SetValue(FontSizeProperty, value); 
//			}
//		}

		//public Color PlaceholderColor 
		//{
		//	get { return (Color)GetValue (PlaceholderColorProperty); }
		//	set { SetValue (PlaceholderColorProperty, value); }
		//}

		public string ValidationText 
		{
			get 
			{
				return (string)GetValue (ValidationTextProperty);
			}
			set
			{
				SetValue (ValidationTextProperty, value);
			}
		}

		#endregion Properties
	}
}