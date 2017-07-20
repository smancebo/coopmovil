using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ibanking.Controls.Resumen
{
    public partial class separator : StackLayout
    {
        public separator()
        {
            InitializeComponent();
        }

        public separator(string title)
        {
            InitializeComponent();
            this.Title.Text = title;
        }
    }
}
