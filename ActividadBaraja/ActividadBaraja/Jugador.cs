using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadBaraja
{
    public class Jugador
    {
        String nombre;
        List<Carta> cartasMano;
        List<Carta> cartasJugadas;
        Carta ultimaCartaJugada; 
        bool estado;
        
        public Jugador() { }

        public Jugador(String nombre)
        {
            this.nombre = nombre;
            this.cartasMano= new List<Carta>();
            this.cartasJugadas = new List<Carta>();
            this.ultimaCartaJugada = null;
            this.estado = true;
        }

        public String Nombre{ get => nombre; set => nombre = value; }

        public List<Carta> CartasMano { get => cartasMano; set => cartasMano = value; }

        public List<Carta> CartasJugadas { get => cartasJugadas; set => cartasJugadas = value; }

        public Carta UltimaCartaJugada { get => ultimaCartaJugada; }

        public bool Estado { get => estado; set => estado = value; }
        public void MostrarMano() 
        {
            for(int i = 0; i < cartasMano.Count; i ++)
            {
                Console.WriteLine(cartasMano[i]);
            }
        }
        public Carta mostrarPrimeraCarta() 
        {
            return cartasMano[0];
        }
        public Carta SacarCarta()
        {
                Carta cartaJugada = cartasMano[0];
                ultimaCartaJugada = cartasMano[0];
                cartasJugadas.Add(cartaJugada);
                cartasMano.RemoveAt(0);
                return cartaJugada;

        }

        public void EliminarCartasJugadas()
        {
            cartasJugadas.Clear();
        }

        public void GuardarCartas(List<Carta> cartasGanadas)
        {
            for(int i = 0; i < cartasGanadas.Count; i ++)
            {
                cartasMano.Add(cartasGanadas[i]);
            }
        }

        public bool tieneCartas() 
        {
            if (cartasMano.Count > 0)
                return true;
        
           return  false;
        }
        public override string ToString()
        {
            return "Jugador: " + Nombre +"  total de cartas ->  "+ cartasMano.Count+ "  ultimaCartaJugada ->  " + ultimaCartaJugada;
        }
    }
}
