// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseur.Models;
using ClientConvertisseur.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseur.views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged {

        public ConvertisseurEuroPage() {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private ObservableCollection<Devise> lesDevises;

        public ObservableCollection<Devise> LesDevises {
            get { return lesDevises; }
            set {
                lesDevises = value;
                OnPropertyChanged(nameof(LesDevises));
            }
        }

        private Devise? devise;

        public Devise? Devise {
            get { return devise; }
            set {
                devise = value;
                OnPropertyChanged(nameof(Devise));
            }
        }

        private double montantEuro;

        public double MontantEuro {
            get { return montantEuro; }
            set {
                montantEuro = value;
                OnPropertyChanged(nameof(MontantEuro));
            }
        }

        private double montantCalculer;

        public double MontantCalculer {
            get { return montantCalculer; }
            set {
                montantCalculer = value;
                OnPropertyChanged(nameof(MontantCalculer));
            }
        }

        private async void GetDataOnLoadAsync() {
            try {
                WSService service = new WSService("https://localhost:44336/api/");
                List<Devise> result = await service.GetDevisesAsync("devises");
                if (result == null)
                    throw new ArgumentException("API n'est pas disponible");
                else
                    LesDevises = new ObservableCollection<Devise>(result);
            }
            catch(Exception ex){
                DisplayMessageBox(ex);
            }
        }

        public void btnConvertir_click(object sender, RoutedEventArgs e) {
            try {
                if (Devise is null)
                    throw new ArgumentNullException("Veuillez sélectionner une devise.");
                if (MontantEuro <= 0)
                    throw new ArgumentOutOfRangeException("Veuillez entrer un montant supérieur à 0");

                MontantCalculer = Math.Round(MontantEuro * Devise.TauxDevise, 2);
            }
            catch (Exception ex) {
                DisplayMessageBox(ex);
            }
        }

        private async void DisplayMessageBox(Exception ex) {
            ContentDialog messageBox = new ContentDialog {
                XamlRoot = this.Content.XamlRoot,
                Title = "Erreur",
                Content = ex.Message,
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await messageBox.ShowAsync();
        }
    }
}
