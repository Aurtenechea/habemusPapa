using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habemusPapa
{
    class Conclave
    {
        private int _cantMaxCardenales;
        private List<Cardenal> _cardenales;
        private bool _habemusPapa;
        private string _lugarEleccion;
        private Cardenal _papa;
        public static int cantVotaciones;
        public static DateTime fechaVotacion;
        private static Random rdm ;

        static Conclave() 
        {
            Conclave.cantVotaciones = 0;
            Conclave.fechaVotacion = DateTime.Now;
            Conclave.rdm = new Random();
        }

        public Conclave() 
        {
            this._cantMaxCardenales = 1;
            this._lugarEleccion = "Capilla Sixtina";
        }

        private Conclave(int cantidadCardenales)
            : this()
        {
            this._cantMaxCardenales = cantidadCardenales;
        }

        public Conclave(int cantidadCardenales, string lugarEleccion)
            : this(cantidadCardenales)
        {

        }

        private bool HayLugar()
        {
            //if (this._cardenales.Count < this._cantMaxCardenales)
            //    return true;
            //    return false;
                return this._cardenales.Count < this._cantMaxCardenales ? true : false;
        }

        private string MostrarCardenales()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Cardenal item in this._cardenales)
            {
                sb.AppendLine(Cardenal.Mostrar(item));
            }
            return sb.ToString();
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lugar vot: " + this._lugarEleccion);
            sb.AppendLine("Fecha : " + Conclave.fechaVotacion);
            sb.AppendLine("Cant vot: " + Conclave.cantVotaciones);
            if (this._habemusPapa) 
            {
                sb.AppendLine("HABEMUS PAPA" + this._papa.ObtenerNombreYNombrePapal());
            }
            else 
            {
                sb.AppendLine("NO HABEMUS PAPA");
                sb.AppendLine(this.MostrarCardenales());
            }
            return sb.ToString();
        }


        public void VotarPapa(Conclave con)
        { 
           
            con._cardenales[Conclave.rdm.Next(1, con._cardenales.Count-1)]++; // incrementa en 1 voto un cardenal elegiod al azar del list.
        }


        private void ContarVotos(Conclave con)
        {
            int max = 0;
            int cont=0;
            Cardenal c = null;
            
            foreach (Cardenal item in con._cardenales)
            {
                if (max < item.getCantidadVotosRecibidos())
                {
                    max = item.getCantidadVotosRecibidos();
                    c = item;
                }
            }
           
            foreach (Cardenal item in con._cardenales)
            {
                if (max == item.getCantidadVotosRecibidos())
                {
                    cont++;
                }
            }

            if (cont == 1 &&  c != null)
            {
                con._habemusPapa = true;
            }
            else
            {
                con._habemusPapa = false;
            }
            

            //for (int i = 0; i < con._cardenales.Count - 1; i++)
            //{ 
            //    if (con._cardenales[0] >)
            //}

        }


        public static implicit operator Conclave(int cantCardenales)  
        {
            return new Conclave(cantCardenales);
        }

        public static explicit operator bool(Conclave con)
        {
            return con._habemusPapa;
        }

        public static bool operator ==(Conclave con, Cardenal c)
        {
            bool r = false;
            foreach (Cardenal item in con._cardenales)
            {
                if (item == c) 
                    r=true; 
            }
            return r;
        }
        public static bool operator !=(Conclave con, Cardenal c)
        {
            return !(con == c);
        }

        public static Conclave operator +(Conclave con, Cardenal c)
        {
            if (con.HayLugar() && !(con == c))
            {
                con._cardenales.Add(c);
            }
            return con;
        }

    }
}
