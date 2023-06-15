using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Carta
    {
    private char palo;
    private int numero;

    public Carta() { }

    public Carta(char palo, int numero) 
    {
        this.palo = palo;
        this.numero = numero;
    }

    public int Numero { get => numero; set => numero = value; }

    public char Palo { get => palo; set => palo = value; }
  
    public override string ToString()
    {
        switch (numero)
        {
            case 11:
                return " [J" + palo + "] ";

            case 12:
                return " [Q" + palo + "] ";

            case 13:
                return " [K" + palo + "] ";

            default:
                return " [" + numero + palo + "] ";
        }
    }

}

