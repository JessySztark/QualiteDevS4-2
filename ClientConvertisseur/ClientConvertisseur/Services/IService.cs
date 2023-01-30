using ClientConvertisseur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseur.Services {
    interface IService {

        Task<List<Devise>> GetDevisesAsync(String nomController);

    }
}
