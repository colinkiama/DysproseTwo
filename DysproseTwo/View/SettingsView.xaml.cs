﻿using DysproseTwo.Dialogs;
using DysproseTwo.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DysproseTwo.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsView : Page
    {
        SettingsViewModel _viewModel = new SettingsViewModel();
        AboutDialog _aboutDialog = new AboutDialog();
        public SettingsView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _viewModel.GetSettings();
        }

        private async void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _aboutDialog.ShowAsync();
            }
            catch (Exception)
            {

            }
        }

        private void FullScreenModeButton_Click(object sender, RoutedEventArgs e)
        {
            var appView = ApplicationView.GetForCurrentView();
            if (appView.IsFullScreenMode)
            {
                appView.ExitFullScreenMode();
            }
            else
            {
                appView.TryEnterFullScreenMode();
            }
        }
    }
}
