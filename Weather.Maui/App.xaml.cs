﻿using Microsoft.Maui;
using Microsoft.Maui.Controls;
namespace Weather.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
