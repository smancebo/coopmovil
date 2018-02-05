﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using ibanking.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomFontNavigationPageRenderer))]
namespace ibanking.iOS
{


    public class CustomFontNavigationPageRenderer : NavigationRenderer
    {
        public CustomFontNavigationPageRenderer()
        {
        }

        const string customFontName = "FontAwesome.ttf";
        nfloat customFontSize = 10;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (this.NavigationBar == null) return;

            SetNavBarStyle();
            //          SetNavBarTitle();
            SetNavBarItems();
        }

        private void SetNavBarStyle()
        {
            NavigationBar.ShadowImage = new UIImage();
            NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();
            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
        }

        private void SetNavBarItems()
        {
            var navPage = this.Element as NavigationPage;

            if (navPage == null) return;

            var textAttributes = new UITextAttributes()
            {
                Font = UIFont.FromName(customFontName, customFontSize)
            };

            var textAttributesHighlighted = new UITextAttributes()
            {
                TextColor = Color.Blue.ToUIColor(),
                Font = UIFont.FromName(customFontName, customFontSize)
            };

            UIBarButtonItem.Appearance.SetTitleTextAttributes(textAttributes,
                UIControlState.Normal);
            UIBarButtonItem.Appearance.SetTitleTextAttributes(textAttributesHighlighted,
                UIControlState.Highlighted);
        }

    }
}
