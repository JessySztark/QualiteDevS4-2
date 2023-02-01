// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using ClientConvertisseurV2.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV2.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page {
        public ConvertisseurEuroPage() {
            this.InitializeComponent();
            ConvertisseurEuroViewModel convertisseurEuroViewModel = new ConvertisseurEuroViewModel();
            DataContext = ((App)Application.Current).ConvertisseurEuroVM;
        }
    }
}
