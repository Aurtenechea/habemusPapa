using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habemusPapa
{
    class Cardenal
    {

        private int _cantVotosRecibidos;
        private ENacionalidades _nacionalidad;
        private string _nombre;
        private string _nombrePapal;

        private Cardenal()
        {
            this._cantVotosRecibidos = 0;
        }

        public Cardenal(string nombre, string nombrePapal) :this()
        {
            this._nombre = nombre;
            this._nombrePapal = nombrePapal;

        }

        public Cardenal(string nombre, string nombrePapal, ENacionalidades nacionalidad) :this(nombre, nombrePapal)
        {
            this._nacionalidad = nacionalidad;
        }

        public int getCantidadVotosRecibidos()
        {
            return this._cantVotosRecibidos;
        }

        public string ObtenerNombreYNombrePapal()
        {
            return "El cardenal " + this._nombre + " se llamará “Papa " + this._nombrePapal + "“."; 
        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.ObtenerNombreYNombrePapal());
            sb.AppendLine("mucha mas informacion");
            return sb.ToString();
        }

        public static string Mostrar(Cardenal c)
        {
            return c.Mostrar();
        }

        public static bool operator ==(Cardenal c1, Cardenal c2)
        {
            //root.Equals(root2, StringComparison.OrdinalIgnoreCase);
            if (c1._nombre.Equals(c2._nombre, StringComparison.OrdinalIgnoreCase) && c1._nombrePapal.Equals(c2._nombrePapal, StringComparison.OrdinalIgnoreCase) && (c1._nacionalidad == c2._nacionalidad))
                return true;
            return false;
        }
        public static bool operator !=(Cardenal c1, Cardenal c2)
        {
            return !(c1 == c2);    
        }

        public static Cardenal operator ++(Cardenal c)
        {
            c._cantVotosRecibidos++;
            return c;
        }

    }
}
