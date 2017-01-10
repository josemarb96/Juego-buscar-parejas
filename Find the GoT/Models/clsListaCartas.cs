using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_the_GoT.Models
{
    public class clsListaCartas
    {
        ObservableCollection<clsCarta> listaCartas;

        public ObservableCollection<clsCarta> getListaCartas()
        {
            listaCartas = new ObservableCollection<clsCarta>();

            //Casas

            listaCartas.Add(new clsCarta(1, "/Assets/baratheon.jpg"));
            listaCartas.Add(new clsCarta(2, "/Assets/lannister.jpg"));
            listaCartas.Add(new clsCarta(3, "/Assets/mormont.jpg"));
            listaCartas.Add(new clsCarta(4, "/Assets/stark.jpg"));
            listaCartas.Add(new clsCarta(5, "/Assets/targaryen.jpg"));
            listaCartas.Add(new clsCarta(6, "/Assets/tyrell.jpg"));

            //Personajes

            listaCartas.Add(new clsCarta(1, "/Assets/stannis.jpg"));
            listaCartas.Add(new clsCarta(2, "/Assets/cersei.jpg"));
            listaCartas.Add(new clsCarta(3, "/Assets/ladymormont.jpg"));
            listaCartas.Add(new clsCarta(4, "/Assets/ned.jpg"));
            listaCartas.Add(new clsCarta(5, "/Assets/danerys.jpg"));
            listaCartas.Add(new clsCarta(6, "/Assets/olenna.jpg"));

            return listaCartas;
        }
    } //Fin clsListaCartas
}
