using System;
using Xamarin.Forms;

namespace ibanking.Controls
{
    public class CustomEntry : Entry
    {
        public delegate void OnEntryTappedDelegate(object sender, EventArgs e);
        public event OnEntryTappedDelegate OnEntryTapped;

        public bool SelectAllOnFocus { get; set; }


        public CustomEntry()
        {
            this.SelectAllOnFocus = false;
        }

        public void Click(object sender, EventArgs e)
        {
            OnEntryTapped?.Invoke(sender, e);
        }
    }
}
