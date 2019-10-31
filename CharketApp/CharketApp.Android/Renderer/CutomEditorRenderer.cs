using System;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using CharketApp.Controler;
using CharketApp.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CutomEditorRenderer))]
namespace CharketApp.Droid.Renderer
{
    public class CutomEditorRenderer : EditorRenderer
    {
        public CutomEditorRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
                Control.SetTextColor(Android.Graphics.Color.Black);

                IntPtr intPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(intPtrtextViewClass, "mCursorDrawableRes", "I");

                //My_Cursor is the xml file name wich we defind aboce
                JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.CustomEntry);
            }
        }
    }
}