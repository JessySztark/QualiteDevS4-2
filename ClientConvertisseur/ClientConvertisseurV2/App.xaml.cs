// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV2.ViewModels;
using ClientConvertisseurV2.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV2 {
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App() {
            this.InitializeComponent();

            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<ConvertisseurEuroViewModel>()
                .BuildServiceProvider()
            );
        }
        public static FrameworkElement MainRoot { get; private set; }

        public ConvertisseurEuroViewModel ConvertisseurEuroVM {
            get { return Ioc.Default.GetService<ConvertisseurEuroViewModel>();  }
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args) {
            m_window = new MainWindow();
            Frame rootFrame = new Frame();
            this.m_window.Content = rootFrame;
            m_window.Activate();
            rootFrame.Navigate(typeof(ConvertisseurEuroPage));
            MainRoot = m_window.Content as FrameworkElement; ;
        }
        
        private Window m_window;
    }
}
