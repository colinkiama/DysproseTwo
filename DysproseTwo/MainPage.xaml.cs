﻿using DysproseTwo.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DysproseTwo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainPageViewModel ViewModel = new MainPageViewModel();
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void TimerButton_Click(object sender, RoutedEventArgs e)
        {
            switch (ViewModel.CurrentSession.State)
            {
                case Enums.SessionState.InProgress:
                    ViewModel.CurrentSession.PauseSession();
                    break;
                case Enums.SessionState.Paused:
                    ViewModel.CurrentSession.StartSession();
                    break;
                case Enums.SessionState.Stopped:
                    ViewModel.CurrentSession.StartSession();
                    break;
            }
        }
    }
}
