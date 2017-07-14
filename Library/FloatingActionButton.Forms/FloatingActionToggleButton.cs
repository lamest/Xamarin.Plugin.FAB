using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace FAB.Forms
{
    public class FloatingActionToggleButton : FloatingActionButton
    {
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create(nameof(Checked), typeof(bool), typeof(FloatingActionToggleButton), false);

        public static readonly BindableProperty CheckedColorProperty = BindableProperty.Create(nameof(CheckedColor), typeof(Color), typeof(FloatingActionToggleButton), Color.Blue);

        public static readonly BindableProperty UnCheckedColorProperty = BindableProperty.Create(nameof(UnCheckedColor), typeof(Color), typeof(FloatingActionToggleButton), Color.White);

        public static readonly BindableProperty CheckedImageProperty = BindableProperty.Create(nameof(CheckedImage), typeof(ImageSource), typeof(FloatingActionToggleButton));

        public static readonly BindableProperty UnCheckedImageProperty = BindableProperty.Create(nameof(UnCheckedImage), typeof(ImageSource), typeof(FloatingActionToggleButton));

        public bool Checked
        {
            get { return (bool)this.GetValue(CheckedProperty); }
            set { this.SetValue(CheckedProperty, value); }
        }

        public Color CheckedColor
        {
            get { return (Color)this.GetValue(CheckedColorProperty); }
            set { this.SetValue(CheckedColorProperty, value); }
        }

        public Color UnCheckedColor
        {
            get { return (Color)this.GetValue(UnCheckedColorProperty); }
            set { this.SetValue(UnCheckedColorProperty, value); }
        }

        [TypeConverter(typeof(ImageSourceConverter))]
        public ImageSource CheckedImage
        {
            get { return (ImageSource)this.GetValue(CheckedImageProperty); }
            set { this.SetValue(CheckedImageProperty, value); }
        }

        [TypeConverter(typeof(ImageSourceConverter))]
        public ImageSource UnCheckedImage
        {
            get { return (ImageSource)this.GetValue(UnCheckedImageProperty); }
            set { this.SetValue(UnCheckedImageProperty, value); }
        }

        internal override void SendClicked()
        {
            if (Source == UnCheckedImage)
            {
                Source = CheckedImage;
                NormalColor = CheckedColor;
                Checked = true;
            }
            else
            {
                Source = UnCheckedImage;
                NormalColor = UnCheckedColor;
                Checked = false;
            }

            base.SendClicked();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            Source = UnCheckedImage;
            NormalColor = UnCheckedColor;
        }
    }
}
