﻿using System;
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
using Microsoft.AdMediator.Core.Models;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalMediator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            AdMediator_933982.AdSdkError += AdMediator_AdError;
            AdMediator_933982.AdMediatorFilled += AdMediator_AdFilled;
            AdMediator_933982.AdMediatorError += AdMediator_AdMediatorError;
            AdMediator_933982.AdSdkEvent += AdMediator_AdSdkEvent;

            AdMediator_933982.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Width"] = 480;
            AdMediator_933982.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Height"] = 80;
        }

        void AdMediator_AdSdkEvent(object sender, Microsoft.AdMediator.Core.Events.AdSdkEventArgs e)
        {
            Debug.WriteLine("AdSdk event {0} by {1}", e.EventName, e.Name);
        }

        void AdMediator_AdMediatorError(object sender, Microsoft.AdMediator.Core.Events.AdMediatorFailedEventArgs e)
        {
            Debug.WriteLine("AdMediatorError:" + e.Error + " " + e.ErrorCode);
            // if (e.ErrorCode == AdMediatorErrorCode.NoAdAvailable)
            // AdMediator will not show an ad for this mediation cycle
        }

        void AdMediator_AdFilled(object sender, Microsoft.AdMediator.Core.Events.AdSdkEventArgs e)
        {
            Debug.WriteLine("AdFilled:" + e.Name);
        }

        void AdMediator_AdError(object sender, Microsoft.AdMediator.Core.Events.AdFailedEventArgs e)
        {
            Debug.WriteLine("AdSdkError by {0} ErrorCode: {1} ErrorDescription: {2} Error: {3}", e.Name, e.ErrorCode, e.ErrorDescription, e.Error);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
