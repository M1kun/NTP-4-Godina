using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IServis
    {
        [OperationContract]
        bool DodajKnjigu(Knjiga knjiga);

        [OperationContract]
        [FaultContract(typeof(Izuzetak))]
        void ObrisiKnjigu(int idKnjige);

        [OperationContract]
        [FaultContract(typeof(Izuzetak))]
        void PromeniStanjeKnjiga(int stanje, int idKnjige);

        [OperationContract]
        bool DodajClana(Clan clan);

        [OperationContract]
        [FaultContract(typeof(Izuzetak))]
        void ObrisiClana(int idClana);

        [OperationContract]
        [FaultContract(typeof(Izuzetak))]
        void IznajmiKnjigu(int idClana, int idKnjige);

        [OperationContract]
        [FaultContract(typeof(Izuzetak))]
        void VratiKnjigu(int idClana, int idKnjige);

        [OperationContract]
        List<Knjiga> SveKnjige();

        [OperationContract]
        List<Clan> SviClanovi();
    }
}
