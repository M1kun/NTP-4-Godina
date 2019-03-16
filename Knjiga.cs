using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Knjiga
    {
        static int counter = 1;
        int id;
        string nazivKnjige;
        string autor;
        int godinaIzdavanja;
        int brojcanoStanje;


        [DataMember]
        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        [DataMember]
        public string NazivKnjige
        {
            get { return nazivKnjige; }
            set { nazivKnjige = value; }
        }

        [DataMember]
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        [DataMember]
        public int GodinaIzdavanja
        {
            get { return godinaIzdavanja; }
            set { godinaIzdavanja = value; }
        }

        [DataMember]
        public int BrojcanoStanje
        {
            get { return brojcanoStanje; }
            set { brojcanoStanje = value; }
        }

        public Knjiga() : this("", "", -1, 0) { }
        public Knjiga(string ime, string imeAutora, int godinaIzdavanja, int brojcanoStanje)
        {
            this.id = counter;
            this.nazivKnjige = ime;
            this.autor = imeAutora;
            this.godinaIzdavanja = godinaIzdavanja;
            this.brojcanoStanje = brojcanoStanje;
            counter++;
        }

        public override string ToString()
        {
            return String.Format("id: {0}, {1} - {2} , (godina izdanja : {3}) trenutno u biblioteci ima {4} primerka.",id,autor,nazivKnjige,godinaIzdavanja,brojcanoStanje);
        }
    }
}
