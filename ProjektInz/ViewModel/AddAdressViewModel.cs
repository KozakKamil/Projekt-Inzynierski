using CommunityToolkit.Mvvm.Input;
using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektInz.ViewModel
{
    internal class AddAdressViewModel
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddAdressCommand { get; private set; }
        private Adress adress = new Adress();

        public AddAdressViewModel()
        {
            _connection = new Connection();
            AddAdressCommand = new RelayCommand(AddAdress);
        }

        public Adress Adress
        {
            get
            {
                return adress;
            }
            set
            {
                adress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Adress)));
            }
        }

        public async void AddAdress()
        {
            await _connection.AddAdress(Adress);
        }
    }
}
