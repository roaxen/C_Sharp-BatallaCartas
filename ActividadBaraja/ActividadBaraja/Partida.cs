using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadBaraja
{
    public class Partida
    {
       List<Jugador> jugadores;
       Baraja barajaCartas;
        Jugador ganador;



        public Partida(List<Jugador> jugadores, Baraja barajaCartas)
        {
            this.jugadores = jugadores;
            this.barajaCartas = barajaCartas;

            this.barajaCartas.MezclarBaraja();

        }

        public List<Jugador> Jugadores {get=> jugadores; set => jugadores = value;}

        public Baraja BarajaCartas { get => barajaCartas; set => barajaCartas = value; }

        public Jugador Ganador { get => ganador; set => ganador = value; }

        public List<List<Carta>> CortarMazo() 
        {
            List<List<Carta>> montonesCartas= new List<List<Carta>>();

            int maximosJugadores = jugadores.Count;
            int maxCartasRepartir = barajaCartas.ListaCartas.Count / maximosJugadores;

            Console.WriteLine("maxCartasRepartir"+ maxCartasRepartir + "-- maximosJugadores"+ maximosJugadores );
            for (int i = 0; i < maximosJugadores; i ++)
            {
                List<Carta> paqueteCartas = new List<Carta>();
                Console.WriteLine("cortando mazo bucle valor de i  "+i);

                for (int j = 0; j < maxCartasRepartir; j++)
                {
      
                    paqueteCartas.Add(barajaCartas.ListaCartas[j+ (maxCartasRepartir * i)]);
                }
                montonesCartas.Add(paqueteCartas);
            }
            return montonesCartas;
        }

        public void RepartirTodasLasCartas() 
        {
            List<List<Carta>> mazoCortado =  CortarMazo();

            Console.WriteLine("RepartirTodasLasCartas +++ mazoCortado " + mazoCortado.Count);
            for (int i = 0; i < mazoCortado.Count; i++)
            {
                jugadores[i].GuardarCartas(mazoCortado[i]);
                
            }
        }
        public int ComprobarJugadoresActivos()
        {
            int contadorActivos = 0;

            for (int i = 0; i < jugadores.Count; i++)
            {
                if(jugadores[i].Estado == true)
                    contadorActivos++;
            }

            return contadorActivos;
        }

        public void ActivarJugadores() 
        {
            for (int i = 0; i < jugadores.Count; i++)
            {
                if (jugadores[i].tieneCartas())
                {
                    jugadores[i].Estado = true;
                }
                else 
                {
                    jugadores[i].Estado = false;
                }

                // jugadores[i].Estado = jugadores[i].tieneCartas() 

            }
        }
    }
}
