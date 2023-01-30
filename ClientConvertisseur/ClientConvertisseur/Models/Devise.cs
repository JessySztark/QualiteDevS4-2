using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseur.Models {
    public class Devise {
        private int idDevise;
        private String nomDevise;
        private Double tauxDevise;

        public Devise() {

        }

        public Devise(int id, String nom, Double taux) {
            this.IDDevise = id;
            this.NomDevise = nom;
            this.TauxDevise = taux;
        }

        public int IDDevise {
            get {
                return idDevise;
            }

            set {
                idDevise = value;
            }
        }

        public string NomDevise {
            get {
                return nomDevise;
            }

            set {
                nomDevise = value;
            }
        }

        public double TauxDevise {
            get {
                return tauxDevise;
            }

            set {
                tauxDevise = value;
            }
        }
    }
}
