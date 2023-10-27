﻿using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektInz.ViewModel
{
    internal class AddWorkerViewModel
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        private Worker worker = new Worker();

        public AddWorkerViewModel()
        {
            _connection = new Connection();
        }


        public Worker Worker
        {
            get
            {
                return worker;
            }
            set
            {
                worker = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Worker)));
            }   
        }

        public async void AddWorker()
        {
           await _connection.AddWorker(Worker);
        }
    }
}
