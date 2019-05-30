﻿using RedCorners.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Reflection;
using static RedCorners.Forms.Sidebar;

namespace RedCorners.Demo.ViewModels
{
    public class MainViewModel : BindableModel
    {
        bool _androidTranslucentStatus = true;
        public bool AndroidTranslucentStatus
        {
            get => _androidTranslucentStatus;
            set => SetProperty(ref _androidTranslucentStatus, value);
        }

        bool _androidLayoutInScreen = false;
        public bool AndroidLayoutInScreen
        {
            get => _androidLayoutInScreen;
            set => SetProperty(ref _androidLayoutInScreen, value);
        }

        bool _lightContent = true;
        public bool LightContent
        {
            get => _lightContent;
            set
            {
                _lightContent = value;
                UpdateProperties();
            }
        }

        public override bool IsModal => false;

        public UIStatusBarStyles UIStatusBarStyle => LightContent ? UIStatusBarStyles.LightContent : UIStatusBarStyles.Default;

        Color _androidStatusBarColor = Color.Red;
        public Color AndroidStatusBarColor
        {
            get => _androidStatusBarColor;
            set => SetProperty(ref _androidStatusBarColor, value);
        }

        SidebarSides _side = SidebarSides.Right;
        public SidebarSides Side
        {
            get => _side;
            set => SetProperty(ref _side, value);
        }

        bool _isFullSize = false;
        public bool IsFullSize
        {
            get => _isFullSize;
            set => SetProperty(ref _isFullSize, value);
        }

        GridLength _contentSize = GridLength.Star;
        public GridLength ContentSize
        {
            get => _contentSize;
            set => SetProperty(ref _contentSize, value);
        }
        public Command BlueStatusBarCommand => new Command(() => AndroidStatusBarColor = Color.FromHex("#770000FF"));
        public Command GreenStatusBarCommand => new Command(() => AndroidStatusBarColor = Color.FromHex("#7700FF00"));

        public ImageSource BackgroundImage => "https://images.pexels.com/photos/163822/color-umbrella-red-yellow-163822.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260";

        public Command<string> PlaceSidebarCommand => new Command<string>(side =>
        {
            if (Enum.TryParse<SidebarSides>(side, out var s))
                Side = s;
        });

        public Command AutoSizeCommand => new Command(() => ContentSize = GridLength.Auto);
        public Command Star2Command => new Command(() => ContentSize = new GridLength(2, GridUnitType.Star));
        public Command Absolute200Command => new Command(() => ContentSize = new GridLength(200, GridUnitType.Absolute));
    }
}
