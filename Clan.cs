using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Clan
    {
        static int counter = 1;
        int id;
        string ime;
        string prezime;
        List<Knjiga> listaKnjiga;

        [DataMember]
        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        [DataMember]
        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        [DataMember]
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }
        [DataMember]
        public List<Knjiga> ListaKnjiga
        {
            get { return listaKnjiga; }
            private set { listaKnjiga = value; }
        }

        public Clan()
        {
            this.id = counter;
            this.ime = "";
            this.prezime = "";
            this.listaKnjiga = new List<Knjiga>();
            counter++;
        }

        public Clan(string ime, string prezime)
        {
            this.id = counter;
            this.ime = ime;
            this.prezime = prezime;
            this.listaKnjiga = new List<Knjiga>();
            counter++;
        }

        public bool ObrisiKnjiguClana(int idKnjige)
        {
            for(int i=0;i<=listaKnjiga.Count;i++)
            {
                if (idKnjige == listaKnjiga[i].Id)
                {
                    listaKnjiga.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool PosedujeKnjigu(int idKnjige)
        {
            foreach (Knjiga k in listaKnjiga)
            {
                if (k.Id == idKnjige)
                    return true;
            }
            return false;
        }

        public void DodajKnjiguClanu(Knjiga knjiga)
        {
            listaKnjiga.Add(knjiga);
        }

        public override string ToString()
        {
            return id + ": " + ime + " " + prezime;
        }
    }
}
