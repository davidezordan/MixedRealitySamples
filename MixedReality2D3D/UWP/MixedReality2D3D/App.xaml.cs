﻿using Windows.ApplicationModel.Activation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UnityPlayer;
using System;
using System.Threading.Tasks;
// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace MixedReality2D3D
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public AppCallbacks appCallbacks;
        public SplashScreen splashScreen;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            SetupOrientation();
            appCallbacks = new AppCallbacks();
        }

        /// <summary>
        /// Invoked when application is launched through protocol.
        /// Read more - http://msdn.microsoft.com/library/windows/apps/br224742
        /// </summary>
        /// <param name="args"></param>
        protected override void OnActivated(IActivatedEventArgs args)
        {
            string appArgs = "";

            switch (args.Kind)
            {
                case ActivationKind.Protocol:
                    ProtocolActivatedEventArgs eventArgs = args as ProtocolActivatedEventArgs;
                    splashScreen = eventArgs.SplashScreen;
                    appArgs += string.Format("Uri={0}", eventArgs.Uri.AbsoluteUri);
                    break;
            }
            InitializeUnity(appArgs);
        }

        /// <summary>
        /// Invoked when application is launched via file
        /// Read more - http://msdn.microsoft.com/library/windows/apps/br224742
        /// </summary>
        /// <param name="args"></param>
        protected override void OnFileActivated(FileActivatedEventArgs args)
        {
            string appArgs = "";

            splashScreen = args.SplashScreen;
            appArgs += "File=";
            bool firstFileAdded = false;
            foreach (var file in args.Files)
            {
                if (firstFileAdded) appArgs += ";";
                appArgs += file.Path;
                firstFileAdded = true;
            }

            InitializeUnity(appArgs);
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            splashScreen = args.SplashScreen;
            InitializeUnity(args.Arguments);
        }

        private async void InitializeUnity(string args)
        {
#if UNITY_WP_8_1 || UNITY_UWP
            ApplicationView.GetForCurrentView().SuppressSystemOverlays = true;
#endif

#if UNITY_WP_8_1
            StatusBar.GetForCurrentView().HideAsync();
#endif

            appCallbacks.SetAppArguments(args);
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null && !appCallbacks.IsInitialized())
            {
                rootFrame = new Frame();
                Window.Current.Content = rootFrame;
#if !UNITY_HOLOGRAPHIC
                Window.Current.Activate();
#endif
                rootFrame.Navigate(typeof(MainPage));
            }

            Window.Current.Activate();

            await InitialiseAppViewManager();
        }

        private async Task InitialiseAppViewManager()
        {
            // Capture the "Main" view which becomes 3D when Unity starts
            var mainView = await AppViewManager.CreateFromCurrentDispatcherAsync("MainPage");

            // Create a new 2D view for the "Content" page.
            var contentPage = await AppViewManager.CreateNewAsync("ContentPage", typeof(ContentPage));
        }

        void SetupOrientation()
        {
#if UNITY_UWP
            Unity.UnityGenerated.SetupDisplay();
#endif
        }
    }
}
