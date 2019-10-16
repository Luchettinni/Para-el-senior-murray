using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entidades
{
    public class DepositoDeCocinas
    {
        int _capacidadMaxima;
        List<Cocina> _lista = new List<Cocina>();

        public DepositoDeCocinas(int capacaidad)
        {
            this._capacidadMaxima = capacaidad;
        }

        public bool Agregar(Cocina c)
        {
            return this + c;
        }

        public bool Remover(Cocina c)
        {
            return this - c;
        }

        public static bool operator +(DepositoDeCocinas d, Cocina c)
        {
            if (d._lista.Count < d._capacidadMaxima)
            {
                d._lista.Add(c);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator -(DepositoDeCocinas d, Cocina c)
        {
            int indice = d.getIndice(c);

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

        private int getIndice(Cocina c)
        {
            return this._lista.IndexOf(c);
        }

        public override string ToString()
        {
            string output = "\n--------------------------------------------------|";
            output += "\nListado de cocinas";
            output += "\n--------------------------------------------------|";
            output += "\nCOCINAS DEPOSITDAS: " + this._lista.Count + "/" + this._capacidadMaxima + "\n\n";

            foreach (Cocina cocina in this._lista)
            {
                output += cocina.ToString() + "\n";
            }

            output += "--------------------------------------------------|\n";

            return output;
        }
    }
}
