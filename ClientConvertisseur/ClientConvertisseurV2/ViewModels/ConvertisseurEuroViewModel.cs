using CommunityToolkit.Mvvm.ComponentModel;
using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ClientConvertisseurClassModels;

namespace ClientConvertisseurV2.ViewModels {
    public class ConvertisseurEuroViewModel : Calcul {

        public IRelayCommand BtnSetConversion { get; }

        public ConvertisseurEuroViewModel() {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
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
                OnPropertyChanged();
            }
        }

        private Devise? devise;

        public Devise? Devise {
            get { return devise; }
            set {
                devise = value;
                OnPropertyChanged();
            }
        }

        private double montantEuro;

        public double MontantEuro {
            get { return montantEuro; }
            set {
                montantEuro = value;
                OnPropertyChanged();
            }
        }

        private double montantCalculer;

        public double MontantCalculer {
            get { return montantCalculer; }
            set {
                montantCalculer = value;
                OnPropertyChanged();
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
            catch (Exception ex) {
                throw new ArgumentException($"{ex}");
            }
        }

        private void ActionSetConversion() {
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
                XamlRoot = App.MainRoot.XamlRoot,
                Title = "Erreur",
                Content = ex.Message,
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await messageBox.ShowAsync();
        }
    }
}
