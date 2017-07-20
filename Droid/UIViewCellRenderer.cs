using System;
using Xamarin.Forms.Platform.Android;
using ibanking.Controls;
using Xamarin.Forms;
using ibanking.Droid;
using Android.Support.V4.Content;

[assembly: ExportRenderer(typeof(ViewCell), typeof(UIViewCellRenderer))]
namespace ibanking.Droid
{
    public class UIViewCellRenderer : ViewCellRenderer
    {
        Android.Views.View _cellCore; 

       

        protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {
            _cellCore = base.GetCellCore(item, convertView, parent, context);


            var listView = parent as Android.Widget.ListView;

            if(listView != null)
            {
                listView.SetSelector(Resource.Color.ListViewSelector);
                listView.CacheColorHint = new Android.Graphics.Color(ContextCompat.GetColor(Forms.Context, Resource.Color.ListViewSelector));
            }



            return _cellCore;
        }

        public UIViewCellRenderer()
        {
        }
    }
}
