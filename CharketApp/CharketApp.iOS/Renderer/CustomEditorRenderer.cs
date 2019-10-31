using System.ComponentModel;
using CharketApp.Controler;
using CharketApp.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace CharketApp.iOS.Renderer
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.Layer.BorderColor = CoreGraphics.CGColor.CreateSrgb(0f, 0f, 0f, 0f);
                Control.TextColor = UIColor.White;
                Control.TintColor = UIColor.White;
            }
        }
    }
}