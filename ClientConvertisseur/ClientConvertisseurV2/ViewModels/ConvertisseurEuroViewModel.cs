using CommunityToolkit.Mvvm.ComponentModel;
using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ClientConvertisseurV2.ViewModels {
    public class ConvertisseurEuroViewModel : ObservableObject {

        public ConvertisseurEuroViewModel() {
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
    }
}
