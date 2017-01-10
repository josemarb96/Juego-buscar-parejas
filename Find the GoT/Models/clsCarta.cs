using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_the_GoT.Models
{
    public class clsCarta : INotifyPropertyChanged
    {
        //Atributos

        private int _id;
        private String _img;
        private Windows.UI.Xaml.Visibility _visible;
        public event PropertyChangedEventHandler PropertyChanged;

        //Constructor

        public clsCarta (int id, String img)
        {
            _id = id;
            _img = img;
            _visible = Windows.UI.Xaml.Visibility.Collapsed;
        }

        //Gets y Sets

        public int Id
        {
            get  { return _id; }

            set
            {
                _id = value;
                OnPropertyChanged ("Id");
            }
        }

        public String Img
        {
            get { return _img; }

            set
            {
                _img = value;
                OnPropertyChanged ("Img");
            }
        }

        public Windows.UI.Xaml.Visibility Visible
        {
            get
            { return _visible; }

            set
            {
                _visible = value;
                OnPropertyChanged ("Visible");
            }
        }

        protected void OnPropertyChanged (string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs (name));
            }
        }
    } //Fin clsCarta
}
