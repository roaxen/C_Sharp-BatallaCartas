using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ActividadBaraja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmpezarPartida();
            Console.ReadLine();
        }

        public static void EmpezarPartida()
        {


            Partida partida = new Partida(InstanciarJugadores(), new Baraja());

            partida.RepartirTodasLasCartas();

            EmpezarTurnos(partida);
        }


        public static List<Jugador> InstanciarJugadores()
        {

            Console.WriteLine("Cuantos Jugadores van a jugar ");
            int totalJugadores = int.Parse(Console.ReadLine());

            List<Jugador> jugadores = new List<Jugador>();

            for (int i = 0; i < totalJugadores; i++)
            {
                jugadores.Add(new Jugador(CrearJugador()));
            }

            return jugadores;
        }

        public static String CrearJugador()
        {
            Console.WriteLine("Dime el nombre del jugador");
            String nombre = Console.ReadLine();
            return nombre;
        }

        public static void EmpezarTurnos(Partida partida)
        {

            List<Carta> cartasJugadas = new List<Carta>();
            List<Jugador> jugadoresActivos = new List<Jugador>();

            int contadorTurnos = 0;
            int numeroMaxCarta;
            Jugador jugadorTurno;

            while (EstadoDeLaPartida(partida) == false)
            {

                partida.ActivarJugadores(); // si tinene cartas estan activos 
                contadorTurnos++;
                numeroMaxCarta = 0;
                
                while (partida.ComprobarJugadoresActivos() != 1) // hay +1 jugador con cartas
                {
                    Console.WriteLine("\nTurno " + contadorTurnos + " : LOS JUGADORES SACAN CARTAS \n");

                    // añadimos los jugadores activos 

                    for (int i = 0; i < partida.Jugadores.Count; i++)
                    {
                        if (partida.Jugadores[i].Estado == true)
                            jugadoresActivos.Add(partida.Jugadores[i]);
                    }
                    

                    for (int i = 0; i < jugadoresActivos.Count; i++)
                    {
                        jugadorTurno = jugadoresActivos[i];
                        Console.WriteLine("Turno del jugador " + jugadorTurno.Nombre);
                        Console.WriteLine("\t\tCarta sacada " + jugadorTurno.mostrarPrimeraCarta()+"\n");

                        cartasJugadas.Add(jugadorTurno.SacarCarta()); // Coje la primera carta y la pone en cartas jugadas, eliminando la carta de la mano 

                        if (jugadorTurno.UltimaCartaJugada.Numero > numeroMaxCarta) // sacar la maxima carta 
                            numeroMaxCarta = jugadorTurno.UltimaCartaJugada.Numero;
                    }

                  

                    // BUSCAR LOS JUGADORES CON LA MAXIMA CARTA 
                    for (int i = 0; i < jugadoresActivos.Count; i++)
                    {
                        if (jugadoresActivos[i].UltimaCartaJugada.Numero != numeroMaxCarta)
                        {
                            jugadoresActivos[i].Estado = false;

                        }
                    }

                    numeroMaxCarta = 0;
                    jugadoresActivos.Clear();

                }
                // DARLE LAS CARTAS AL JUGADOR QUE A GANADO 

                for (int i = 0; i < partida.Jugadores.Count; i++)
                {
                    if (partida.Jugadores[i].Estado)
                    {
                        partida.Jugadores[i].GuardarCartas(cartasJugadas);
                        cartasJugadas.Clear();
                        Console.WriteLine("\n El jugador " + partida.Jugadores[i].Nombre + " ha ganado con un " + partida.Jugadores[i].UltimaCartaJugada.ToString());
                    }
                }
                    
                Console.WriteLine("\n\tHEMOS ACABADO EL TURNO\n");
                

                Console.WriteLine("\n\tNOTAS AYUDA CODIGO \n");
                Console.WriteLine("\n\t  numeroMaxCarta -> " + numeroMaxCarta + "\n");

                for (int i = 0; i < partida.Jugadores.Count; i++)
                {
                    Console.WriteLine(" INFO PLAYER-->" + partida.Jugadores[i].ToString());
                }

                Console.WriteLine(" PULSE UNA TECLA PARA CONTINUAR ");

                Console.ReadLine();
            }


            Console.WriteLine("El ganador es " + partida.Ganador.Nombre + " con un total de cartas " + partida.Ganador.CartasMano.Count);

        }

        public static bool EstadoDeLaPartida(Partida partida)
        {
            int jugadoresActivos = 0;
            Jugador ganador = null;
            List<Jugador> listaJugadores = partida.Jugadores;

            for (int i = 0; i < listaJugadores.Count; i++)
            {
                if (partida.Jugadores[i].CartasMano.Count != 0)
                {
                    jugadoresActivos++;
                    ganador = partida.Jugadores[i];
                }
       
            }
            if (jugadoresActivos == 1)
            {
                partida.Ganador = ganador;
            }
            return jugadoresActivos == 1;
        }

    }
}
