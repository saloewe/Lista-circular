using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Ruta
    {
        private Paradas primera;
        private Paradas ultima;
        public Ruta()
        {
            primera = null;
            ultima = null;
        }

        public void Agregar(Paradas nueva)
        {
            if (primera == null)
            {
                primera = nueva;
                primera.Siguiente = primera;
                ultima = primera;
            }
            else
            {
                ultima.Siguiente = nueva;
                nueva.Siguiente = primera;
                ultima = nueva;
            }
        }

        public void Insertar(int pos, Paradas nueva)
        {
            Paradas actual = primera;
            Paradas anterior = null;
            bool encontrado = false;
            int i = 1;
            if (actual != null)
            {
                do
                {
                    if (pos == i)
                    {
                        if (actual == primera)
                        {
                            anterior = primera;
                            primera = nueva;
                            primera.Siguiente = anterior;
                            ultima.Siguiente = primera;
                        }
                        else if (actual == ultima)
                        {
                            ultima.Siguiente = nueva;
                            nueva.Siguiente = primera;
                            ultima = nueva;
                        }
                        else
                        {
                            anterior.Siguiente = nueva;
                            nueva.Siguiente = actual;
                        }
                        encontrado = true;
                    }
                    i++;
                    anterior = actual;
                    actual = actual.Siguiente;
                } while (encontrado != true);
            }
        }

        public string Listar()
        {
            Paradas actual = primera;
            string cadena = "";
            if (actual != null)
            {
                do
                {
                    cadena += actual.ToString() + "\r\n";
                    actual = actual.Siguiente;
                } while (actual != primera);
            }
            else
            {
                cadena = "No hay rutas";
            }
            return cadena;
        }
        
        public string Buscar(string nombre)
        {
            Paradas actual = primera;
            string cadena = "";
            bool encontrado = false;
            if (actual != null)
            {
                do
                {
                    if (actual.Nombre == nombre)
                    {
                        cadena = "Parada encontrada";
                        encontrado = true;
                    }
                    actual = actual.Siguiente;
                } while (actual != primera && encontrado != true);
            }
            else
            {
                cadena = "No se encuentra la parada";
            }
            return cadena;
        }

        public void Eliminar(string nombre)
        {
            Paradas actual = primera;
            Paradas anterior = null;
            bool encontrado = false;
            if (actual != null)
            {
                do
                {
                    if (actual.Nombre == nombre)
                    {
                        if(actual== primera)
                        {
                            primera = primera.Siguiente;
                            ultima.Siguiente = primera;
                        }
                        else if(actual== ultima)
                        {
                            anterior.Siguiente = primera;
                            ultima = anterior;
                        }
                        else
                        {
                            anterior.Siguiente = actual.Siguiente;
                        }
                        encontrado = true;                       
                    }
                    anterior = actual;
                    actual = actual.Siguiente;
                } while (actual != primera && encontrado != true);
            }      
        }
                
        public void EliminarUltimo()
        {
            Paradas actual = primera;
            Paradas anterior = null;
            bool encontrado = false;
            if (actual != null)
            {
                do
                {
                    if (actual == ultima)
                    {               
                        anterior.Siguiente = primera;
                        ultima = anterior;  
                        encontrado = true;
                    }
                    anterior = actual;
                    actual = actual.Siguiente;
                } while (actual != primera && encontrado != true);
            }
        }

        public void EliminarPrimero()
        {
            primera = primera.Siguiente;
            ultima.Siguiente = primera;
        }
         
        public string informeRuta(string nombrebase, int horainicio, int horafin)
        {
            string cadena = "";
            Paradas actual = primera;
            bool encontrado = false;
            if (actual != null)
            {
                do
                {
                    if (actual.Nombre == nombrebase)
                    {
                        cadena = "inicia recorrido en Base "+actual.Nombre+ " a la hora "+ horainicio+ "\r\n";
                        encontrado = true;
                    }else
                    actual = actual.Siguiente;
                } while (actual != primera && encontrado != true);
                while (horainicio!=horafin)
                {
                    cadena += " a la hora " + (horainicio + actual.Tiempo) + " se llega a la base " + actual.Siguiente.Nombre+"\r\n";
                    horainicio += actual.Tiempo;
                    actual = actual.Siguiente;
                }
                
            }
            return cadena;
        }
    }
}
