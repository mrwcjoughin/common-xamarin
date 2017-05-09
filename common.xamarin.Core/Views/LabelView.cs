using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace common.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public class LabelView : Xamarin.Forms.Label
	{
		#region Fields

		public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create<LabelView, double>(p => p.CornerRadius, default(double));
		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create<LabelView, Color>(p => p.BorderColor, default(Color));
		public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create<LabelView, float>(p => p.BorderWidth, default(float));

		#endregion Fields

		#region Constructors

		public LabelView ()
		{
			
		}

		#endregion Constructors

		#region Properties

		public double CornerRadius
		{
			get { return (double)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		public float BorderWidth
		{
			get { return (float)GetValue(BorderWidthProperty); }
			set { SetValue(BorderWidthProperty, value); }
		}

		#endregion Properties
	}
}