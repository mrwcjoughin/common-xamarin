using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public class EntryView : Xamarin.Forms.Entry
	{
		#region Fields

		public static readonly BindableProperty FontProperty = BindableProperty.Create("Font", typeof(Font), typeof(EntryView), new Font());

//		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(Double), typeof(EntryView), new Double());
		
		#endregion Fields

		#region Constructors

		public EntryView ()
		{
		}

		#endregion Constructors

		#region Properties

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
		       
		#endregion Properties
	}
}