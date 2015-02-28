using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI;
using RatingRemainder;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.System;
using Windows.Media.Capture;
using Windows.Media.Devices;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Settings_plus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public RatingRemainderClass remainder { get; set; }
        public TorchControl torchControl { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            remainder = new RatingRemainderClass(6);
            remainder.mailToAdress = "akash.professionals@outlook.com";
            checkForFlash();
            // setup_statusbar();
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }

        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Application.Current.Exit();
        }

        async void setup_statusbar()
        {
            StatusBar sb = StatusBar.GetForCurrentView();
            sb.BackgroundOpacity = 1;
            sb.BackgroundColor = Colors.SteelBlue;
            sb.ProgressIndicator.Text = "# Settings +";
            sb.ProgressIndicator.ProgressValue = 0;
            await sb.ProgressIndicator.ShowAsync();
            await sb.ShowAsync();
        }

        private void about_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(aboutPage));
        }

        private async void Rate_click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + "b5c148d0-dd05-4d7e-ae75-0e1b7e651f9f", UriKind.RelativeOrAbsolute));
        }

        private async void moreapps_click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("zune:search?publisher=Interactive Apps"));
        }

        private async void feedBack_click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:[akash.professionals@outlook.com]"));
        }

        private async void wifi_click(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-wifi:"));
        }

        private async void airplaneMode_click(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-airplanemode:"));
        }

        private async void cellular_click(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-cellular:"));
        }

        private async void bluettoh_click(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-bluetooth:"));
        }

        private async void location_click(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-location:"));
        }

        private async void lockscreen_click(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
        }

        private async void power_click(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-power:"));
        }

        private async void screenRotation_click(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-screenrotation:"));
        }

        private async void emailsAndAccounts_click(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:"));
        }

        private async void flash_click(object sender, TappedRoutedEventArgs e)
        {

            if (torchControl.Supported) 
            {       
                torchControl.PowerPercent = 100;
                torchControl.Enabled = true; 
            }
            else
            {
                MessageDialog md = new MessageDialog(""); md.Content = "Flash isn't supported in your device";
                md.Title = "Flash Not Supported"; await md.ShowAsync();
            }
        }

        public async void checkForFlash()
        {
            var _mediadDevice = new MediaCapture();
            await _mediadDevice.InitializeAsync();
            var videoDevice = _mediadDevice.VideoDeviceController;
            torchControl = videoDevice.TorchControl;
        }

        private async void Hotspot_click(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("This feature is yet to come","Currently Not Supported");
            await md.ShowAsync();
        }

        private async void wApp_click(object sender, TappedRoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("whatsapp:"));
        }


    }
}
