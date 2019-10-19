using Xamarin.Forms;

namespace CharketApp.Controler
{
    public class CustomButton : Button
    {
        //Create Underline on the button
        public static readonly BindableProperty IsUnderLineProperty = BindableProperty.Create("IsUnderLined", typeof(bool), typeof(CustomButton), false);

        //Show the isUnderline in design mode
        public bool IsUnderLined
        {
            get { return (bool)GetValue(IsUnderLineProperty); }
            set { SetValue(IsUnderLineProperty, value); }
        }
    }
}
