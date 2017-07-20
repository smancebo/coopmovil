﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.Controls
{
    [Preserve (AllMembers = true)]
    public partial class CoopInfoBtn : StackLayout
    {
        public string Text { 
            get {
                return ButtonText.Text;
                } 
            set
            {
                ButtonText.Text = value;
            }
        }

        TapGestureRecognizer _onTapped;

        public EventHandler Tapped
        {
            set
            {
                _onTapped.Tapped += value;
            }
        }




        public CoopInfoBtn()
        {
            InitializeComponent();
            this._onTapped = new TapGestureRecognizer(); 
            this.Text = "";
            this.main.GestureRecognizers.Add(_onTapped);
        }
    }
}
