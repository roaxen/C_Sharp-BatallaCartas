using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Baraja
    {

    private List<Carta> listaCartas;

    public Baraja() {

        this.listaCartas = GenerarBaraja();
    }

    public List<Carta> ListaCartas { get => listaCartas; set => listaCartas = value; }

    public List<Carta> GenerarBaraja() {
      
        List<char> tiposCarta = new List<char> { '♠', '♥', '♦', '♣' };

        List<Carta> barajaCartas= new List<Carta>();

        for (int i = 0; i < tiposCarta.Count(); i++)
        {
            for (int j = 1; j <= 13; j++) 
            {
                barajaCartas.Add(new Carta(tiposCarta[i], j));
            }  
        }

        return barajaCartas;
    }

    public void MezclarBaraja() 
    {
        List<int> listPosicionesCarta = new List<int>();
        List<Carta> cartaListaMezclada = new List<Carta>();
        Random rand = new Random();

        for(int i = 0; i < listaCartas.Count; i++) 
        {
            listPosicionesCarta.Add(i); 
        }

        while (SeguirBarajando(listPosicionesCarta))
        {
            int numeroAleatorio = rand.Next(listaCartas.Count);

            if (listPosicionesCarta[numeroAleatorio] >= 0)
            {
                cartaListaMezclada.Add(listaCartas[numeroAleatorio]);
                listPosicionesCarta[numeroAleatorio] = -1;
            }
        }



       this.listaCartas= cartaListaMezclada;
    }

    public bool SeguirBarajando(List<int> listPosicionesCarta) {
        
        for(int i = 0; i < listPosicionesCarta.Count(); i++) 
        {
            if (listPosicionesCarta[i] >= 0)
                return true;          
        }
        return false;
    }

    }

