using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Find_the_GoT.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Find_the_GoT.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        //Propiedades

        private bool clickable;
        private int parejasCompletas;
        private clsCarta primeraCarta;
        private clsCarta segundaCarta;
        private String contadorJuego;
        private Stopwatch contador = new Stopwatch();
        private String mensajeGanador;
        private clsDelegateCommand _reiniciarPartida;
        private ObservableCollection<clsCarta> listaCartas;
        
        //Constructor

        public clsMainPageVM()
        {
            listaCartas = new ObservableCollection<clsCarta>();
            parejasCompletas = 0;
            primeraCarta = null;
            segundaCarta = null;
            _reiniciarPartida = new clsDelegateCommand (Reiniciar_Partida);
            Clickable = true;
            listaCartas = new clsListaCartas().getListaCartas();
            barajarCartas();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            contador.Start();
        }

        //Gets y Sets

        public ObservableCollection<clsCarta> ListaCartas
        {
            get { return listaCartas; }

            set
            {
                listaCartas = value;
                NotifyPropertyChanged ("ListaCartas");
            }
        }

        public clsCarta PrimeraCarta
        {
            get { return primeraCarta; }

            set
            {
                primeraCarta = value;
                NotifyPropertyChanged ("PrimeraCarta");
                Clickable = false;
                comprobarPareja();
            }
        }

        public clsCarta SegundaCarta
        {
            get { return segundaCarta; }

            set
            {
                segundaCarta = value;
                NotifyPropertyChanged ("SegundaCarta");
            }
        }

        public String ContadorJuego
        {
            get { return this.contadorJuego; }

            set
            {
                this.contadorJuego = value;
                NotifyPropertyChanged ("ContadorJuego");
            }
        }

        public String MensajeGanador
        {
            get { return this.mensajeGanador; }

            set
            {
                this.mensajeGanador = value;
                NotifyPropertyChanged ("MensajeGanador");
            }
        }

        public bool Clickable
        {
            get { return clickable; }

            set
            {
                clickable = value;
                NotifyPropertyChanged ("Clickable");
            }
        }

        public clsDelegateCommand ReiniciarPartida
        {
            get { return _reiniciarPartida; }
        }

        //Métodos

        /// <summary>
        /// Método que comprueba las parejas y para el juego cuando se han encontrado todas.
        /// </summary>
        
        private async void comprobarPareja()
        {
            if (PrimeraCarta != null)
            {
                if (PrimeraCarta.Visible != Windows.UI.Xaml.Visibility.Visible)
                {
                    if (SegundaCarta == null)
                    {
                        PrimeraCarta.Visible = Windows.UI.Xaml.Visibility.Visible;
                        SegundaCarta = PrimeraCarta;
                    }

                    else
                    {
                        PrimeraCarta.Visible= Windows.UI.Xaml.Visibility.Visible;

                        if (PrimeraCarta.Id == SegundaCarta.Id)
                        {
                            parejasCompletas++;
                        }
                        else
                        {
                            await Task.Delay (1000);
                            PrimeraCarta.Visible = Windows.UI.Xaml.Visibility.Collapsed;
                            SegundaCarta.Visible = Windows.UI.Xaml.Visibility.Collapsed;
                        }

                        //La segunda carta seleccionada ha de ser null si queremos formar otra pareja.
                        SegundaCarta = null;
                    }
                }

                //Si primera carta seleccionada ya era visible, se pone a null.
                PrimeraCarta = null;
            }

            if (parejasCompletas == 6)
            {
                contador.Stop();
                MensajeGanador = "Congratulations! Winter is comming...";
                await Task.Delay(4000);
                Reiniciar_Partida();
            }

            else
            {
                Clickable = true;
            }
        }

        /// <summary>
        /// Barajar cartas aleatoriamente.
        /// </summary>
        private void barajarCartas()
        {
            Random random = new Random();
            int aleatorio;

            for (int i=0; i<listaCartas.Count; i++)
            {
                aleatorio = random.Next(12);
                listaCartas.Move (i, aleatorio);
            }
        }

        private void Reiniciar_Partida()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
        }

        private void timer_Tick(object sender, object e)
        {
            ContadorJuego = string.Format("{0}:{1}:{2}", contador.Elapsed.Hours.ToString(), contador.Elapsed.Minutes.ToString(), contador.Elapsed.Seconds.ToString());
        }
    } //Fin clsMainPageVM
}