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
    internal class AddPositionViewModel
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddPositionCommand { get; private set; }
        private Position_title position = new Position_title();

        public AddPositionViewModel()
        {
            _connection = new Connection();
            AddPositionCommand = new RelayCommand(AddPosition);
        }

        public Position_title Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
            }
        }

        public async void AddPosition()
        {
            await _connection.AddPosition(Position);
        }
    }
}
