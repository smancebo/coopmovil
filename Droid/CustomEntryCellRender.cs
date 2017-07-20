using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using ibanking.Controls;
using Xamarin.Forms.Platform.Android;


[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomEntryCell), typeof(ibanking.Droid.CustomEntryCellRenderer))]
namespace ibanking.Droid
{
    public class CustomEntryCellRenderer : Xamarin.Forms.Platform.Android.EntryCellRenderer
    {
        protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context) as EntryCellView;

            if(cell != null)
            {
                var textField = cell.EditText as TextView;
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(0);
                gd.SetStroke(0,Color.White);
                textField.SetBackground(gd);
            }

            return cell;
        }
    }
}
