using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharketApp.Controler;
using CharketApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace CharketApp.iOS
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if(Control!=null&& Element != null)
            {
                if (((CustomButton)Element).IsUnderLined)
                {
                }
            }
        }
    }
}