using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Paradas
    {
        private string _nombre;
        private int _tiempo;
        private Paradas _sig;

        public int Tiempo { get { return _tiempo; } }
        public string Nombre { get { return _nombre; } }
        public Paradas(string nombre, int tiempo)
        {
            _nombre = nombre;
            _tiempo = tiempo;
        }

        public Paradas Siguiente
        {
            get { return _sig; }
            set { _sig = value; }
        }

        public override string ToString()
        {
            return "De la parada " + _nombre + " tarda " + _tiempo + "min en llegar a la parada " + _sig.Nombre;
        }
    }
}
