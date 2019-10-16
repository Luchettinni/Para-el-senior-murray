using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entidades
{
    public class DepositoDeAutos
    {
        int _capacidadMaxima;
        List<Auto> _lista = new List<Auto>();

        public DepositoDeAutos(int capacaidad)
        {
            this._capacidadMaxima = capacaidad;
        }

        public bool Agregar(Auto a)
        {
            return this + a;
        }

        public bool Remover(Auto a)
        {
            return this - a;
        }

        public static bool operator +(DepositoDeAutos d, Auto a)
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

        public static bool operator -(DepositoDeAutos d, Auto a)
        {
            int indice = d.getIndice(a);

            if ( indice != -1 )
            {
                d._lista.RemoveAt(indice);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int getIndice(Auto a)
        {
            return this._lista.IndexOf(a);
        }

        public override string ToString()
        {
            string output = "\n----------------------------------------|";
            output += "\nListado de autos";
            output += "\n----------------------------------------|";
            output += "\nAUTOS DEPOSITADOS: " + this._lista.Count + "/" + this._capacidadMaxima + "\n\n";
                
            foreach (Auto auto in this._lista)
            {
                output += auto.ToString() + "\n";
            }

            output += "----------------------------------------|\n";

            return output;
        }
    }
}
