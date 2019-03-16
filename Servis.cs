using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Servis : IServis
    {

        public bool DodajClana(Clan clan)
        {
            if (!Baza.clanovi.ContainsKey(clan.Id))
            {
                Baza.clanovi.Add(clan.Id, clan);
                return true;
            }
            return false;
        }

        public bool DodajKnjigu(Knjiga knjiga)
        {
            
            if (!Baza.knjige.ContainsKey(knjiga.Id))
            {
                Baza.knjige.Add(knjiga.Id, knjiga);
                return true;
            }
            return false;
        }

        public void IznajmiKnjigu(int idClana, int idKnjige)
        {
            if (Baza.clanovi.ContainsKey(idClana) && Baza.knjige.ContainsKey(idKnjige))
            {
                if (Baza.clanovi[idClana].PosedujeKnjigu(idKnjige))
                {
                    Izuzetak izuzetak = new Izuzetak();
                    izuzetak.Razlog = "Clan je već iznajmio knjiga sa datim ID-jem(" + idKnjige + ")";
                    throw new FaultException<Izuzetak>(izuzetak);
                }
                else
                {
                    if (Baza.knjige[idKnjige].BrojcanoStanje > 0)
                    {
                        Baza.clanovi[idClana].DodajKnjiguClanu(Baza.knjige[idKnjige]);
                        Baza.knjige[idKnjige].BrojcanoStanje--;
                    }
                   
                }
            }
            else
            {
                Izuzetak izuzetak = new Izuzetak();
                if (!Baza.clanovi.ContainsKey(idClana))
                   izuzetak.Razlog += "Clan sa datim ID-jem(" + idClana + ") ne postoji. ";
                if (!Baza.knjige.ContainsKey(idKnjige))
                    izuzetak.Razlog += "Knjiga sa datim ID-jem(" + idKnjige + ") ne postoji. ";
                throw new FaultException<Izuzetak>(izuzetak);
            }
        }

        public void ObrisiClana(int idClana)
        {
            if (Baza.clanovi.ContainsKey(idClana))
            {
                foreach (Knjiga knjiga in Baza.clanovi[idClana].ListaKnjiga)
                {
                    Baza.knjige[knjiga.Id].BrojcanoStanje++;
                }

                Baza.clanovi.Remove(idClana);
            }
            else
            {
                Izuzetak izuzetak = new Izuzetak();
                izuzetak.Razlog = "Clan sa datim ID-jem(" + idClana + ") ne postoji u bazi.";
                throw new FaultException<Izuzetak>(izuzetak);
            }
        }

        public void ObrisiKnjigu(int idKnjige)
        {
            if (Baza.knjige.ContainsKey(idKnjige))
            {
                foreach (Clan clan in Baza.clanovi.Values)
                {
                    if (clan.PosedujeKnjigu(idKnjige))
                    {
                        Izuzetak izuzetak = new Izuzetak();
                        izuzetak.Razlog = "Knjiga sa ID-jem(" + idKnjige + ") je iznajmljena od strane nekog od clanova i iz tog razloga ne može da se obriše.";
                        throw new FaultException<Izuzetak>(izuzetak);
                    }
                }
                Baza.knjige.Remove(idKnjige);
            }
            else
            {
                Izuzetak izuzetak = new Izuzetak();
                izuzetak.Razlog = "Knjiga sa datim ID-jem(" + idKnjige + ") ne postoji u bazi.";
                throw new FaultException<Izuzetak>(izuzetak);
            }
        }

        public void PromeniStanjeKnjiga(int stanje, int idKnjige)
        {
                Knjiga knjiga = new Knjiga();
            if (Baza.knjige.TryGetValue(idKnjige, out knjiga))
            {
                knjiga.BrojcanoStanje += stanje;
            }
            else
            {
                Izuzetak izuzetak = new Izuzetak();
                izuzetak.Razlog = "Knjiga sa datim ID-jem(" + idKnjige + ") ne postoji";
                throw new FaultException<Izuzetak>(izuzetak);
            }

            
        }

        public List<Knjiga> SveKnjige()
        {
            List<Knjiga> lista = new List<Knjiga>();
            foreach (KeyValuePair<int, Knjiga> kvpknjiga in Baza.knjige)
            {
                lista.Add(kvpknjiga.Value);
            }
            return lista;
        }

        public List<Clan> SviClanovi()
        {
            List<Clan> lista = new List<Clan>();
            foreach (KeyValuePair<int, Clan> kvpclan in Baza.clanovi)
            {
                lista.Add(kvpclan.Value);
            }
            return lista;
        }

        public void VratiKnjigu(int idClana, int idKnjige)
        {
            Clan clan = new Clan();
            if (Baza.clanovi.TryGetValue(idClana, out clan))
            {
                if (!clan.ObrisiKnjiguClana(idKnjige))
                {
                    Izuzetak izuzetak = new Izuzetak();
                    izuzetak.Razlog = "Knjiga sa datim ID-jem(" + idKnjige + ") ne postoji u iznajmljenim knjigama korisnika";
                    throw new FaultException<Izuzetak>(izuzetak);
                }
            }
            else
            {
                Izuzetak izuzetak = new Izuzetak();
                izuzetak.Razlog = "Clan sa datim ID-jem(" + idClana + ") ne postoji";
                throw new FaultException<Izuzetak>(izuzetak);
            }
        }
    }
}
