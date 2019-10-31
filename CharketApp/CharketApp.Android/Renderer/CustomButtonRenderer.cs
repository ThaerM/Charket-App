using Android.Content;
using CharketApp.Controler;
using CharketApp.Droid.Rederer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace CharketApp.Droid.Rederer
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element != null)
            {
                if (((CustomButton)Element).IsUnderLined)
                {
                    Control.PaintFlags = Android.Graphics.PaintFlags.UnderlineText;
                }
            }
        }
    }
}