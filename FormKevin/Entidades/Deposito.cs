using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entidades
{
    public class Deposito<T>
    {
        int _capacidadMaxima;
        List<T> _lista = new List<T>();

        public Deposito(int capacaidad)
        {
            this._capacidadMaxima = capacaidad;
        }

        public bool Agregar(T t)
        {
            return this + t;
        }

        public bool Remover(T t)
        {
            return this - t;
        }

        public static bool operator +(Deposito<T> d, T a)
        {
            if (d._lista.Count < d._capacidadMaxima)
            {
                d._lista.Add(a);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator -(Deposito<T> d, T a)
        {
            int indice = d.getIndice(a);

            if (indice != -1)
            {
                d._lista.RemoveAt(indice);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int getIndice(T a)
        {
            return this._lista.IndexOf(a);
        }

        public override string ToString()
        {
            string output = "\n---------------------------------------------|";
            output += "\nlista de " + typeof(T).Name;
            output += "\n---------------------------------------------|";
            output += "\nDEPOSITADOS: " + this._lista.Count + "/" + this._capacidadMaxima + "\n\n";

            foreach (T t in this._lista)
            {
                output += t.ToString() + "\n";
            }

            output += "---------------------------------------------|\n";

            return output;
        }
    }
}
