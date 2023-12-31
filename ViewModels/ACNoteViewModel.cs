﻿using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaicedoRamos_TareaMVVM.ViewModels
{
    internal class NoteViewModel : ObservableObject, IQueryAttributable
    {
        private Models.Nota _note;

        public string Text
        {
            get => _note.ACText;
            set
            {
                if (_note.ACText != value)
                {
                    _note.ACText = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date => _note.ACDate;

        public string Identifier => _note.ACFilename;

        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public NoteViewModel()
        {
            _note = new Models.Nota();
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
        }

        public NoteViewModel(Models.Nota note)
        {
            _note = note;
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
        }

        private async Task Save()
        {
            _note.ACDate = DateTime.Now;
            _note.Save();
            await Shell.Current.GoToAsync($"..?saved={_note.ACFilename}");
        }

        private async Task Delete()
        {
            _note.Delete();
            await Shell.Current.GoToAsync($"..?deleted={_note.ACFilename}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _note = Models.Nota.Load(query["load"].ToString());
                RefreshProperties();
            }
        }

        public void Reload()
        {
            _note = Models.Nota.Load(_note.ACFilename);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Text));
            OnPropertyChanged(nameof(Date));
        }
    }
}
