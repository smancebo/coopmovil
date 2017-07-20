using System;

using Xamarin.Forms;

namespace ibanking.Controls
{
    public class CoopInfoBtn : ContentPage
    {
        public CoopInfoBtn()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

