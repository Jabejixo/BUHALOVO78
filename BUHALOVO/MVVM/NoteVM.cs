using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using JsonLib;

namespace BUHALOVO.MVVM
{
    public class NoteVM : ViewModelBase
    {
        private double fullMoney;
        private DateTime date = DateTime.Today;
        private Note? selectedNote;
        public Note? SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value;
                Set(ref selectedNote, value);
                if (selectedNote != null)
                {
                    Name = selectedNote.Name;
                    Type = selectedNote.Type;
                    AmountOfMoney = selectedNote.AmountOfMoney;
                }
            }
        }
        private string name = "";
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private string type = "";
        public string Type
        {
            get { return type; }
            set { Set(ref type, value); }
        }

        private double amountOfMoney = 0;
        public double AmountOfMoney
        {
            get { return amountOfMoney; }
            set { Set(ref amountOfMoney, value); }
        }

        private bool isReceipt;
        public bool IsReceipt
        {
            get { return isReceipt; }
            set
            {
                if (AmountOfMoney > 0) isReceipt = true; else isReceipt = false; Set(ref isReceipt, value);
            }
        }

        public double FullMoney
        {
            get
            {
              return fullMoney;
            }
            set
            {
                Set(ref fullMoney, value);
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                Set(ref date, value);
                UpNotes();
            }
        }
        public ObservableCollection<string> Types { get; set; }


        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        private RelayCommand commandSave;
        public RelayCommand CommandSave
        {
            get
            {
                return commandSave ?? (commandSave = new RelayCommand(obj =>
                {
                    SaveNote();
                }));
            }
        }

        private RelayCommand commandDelete;
        public RelayCommand CommandDelete
        {
            get
            {
                return commandDelete ?? (commandDelete = new RelayCommand(obj =>
                {
                    DeleteNote();
                }));
            }
        }

        private void UpNotes()
        {
            NotesOnDays.Clear();
            foreach (var note in Notes)
            {
                if (note.Date == Date)
                {
                    NotesOnDays.Add(note);
                }
            }
        }

        private ObservableCollection<Note> notesOnDays = new();
        public ObservableCollection<Note> NotesOnDays
        {
            get
            {
                return notesOnDays;
            }
            set
            {
               
            }
        }


        public NoteVM()
        {
            NoteVm = this;
            Notes = FileManager.Deserialization<Note>("Notes");
            Date = DateTime.Today;
            UpCounter();
            Types = FileManager.Deserialization<string>("Types");
        }



        public void SaveNote()
        {
            if (SelectedNote != null)
            {
                // обновление выбранной записи
                SelectedNote.Name = Name;
                SelectedNote.Type = Type;
                SelectedNote.AmountOfMoney = AmountOfMoney;
                SelectedNote.IsReceipt = IsReceipt;
                FileManager.Serialize(Notes, "Notes");
            }
            else
            {
                // создание новой записи
                Notes.Add(new Note(Name, Type, AmountOfMoney, IsReceipt, Date));
                FileManager.Serialize(Notes, "Notes");

            }

            Name = "";
            Type = "";
            AmountOfMoney = 0;
            SelectedNote = null;
            UpNotes();
            UpCounter();
        }

        public void DeleteNote()
        {
            if (SelectedNote != null)
            {
                Notes.Remove(SelectedNote);
                Name = "";
                Type = "";
                AmountOfMoney = 0;
                IsReceipt = false;
                SelectedNote = null;
                UpNotes();
                UpCounter();
                FileManager.Serialize(Notes, "Notes");
            }
        }

        public void UpCounter()
        {
            FullMoney = 0;
            foreach (var note in Notes)
            {
                FullMoney += note.AmountOfMoney;
            }
        }
    }
}
