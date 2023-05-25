using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUHALOVO.MVVM
{
    internal class NoteViewModel : ViewModelBase
    {
        private Note note;

        public NoteViewModel(Note n)
        {
            note = n;
        }

        public string Name
        {
            get { return note.Name; }
            set
            {
                note.Name = value;
                Set(ref note, note);
            }
        }
        public string Type
        {
            get { return note.Type; }
            set
            {
                note.Type = value;
                Set(ref note, note);
            }
        }
        public double AmountOfMoney
        {
            get { return note.AmountOfMoney; }
            set
            {
                note.AmountOfMoney = value;
                Set(ref note, note);

            }
        }

        public bool IsReceipt
        {
            get { return note.IsReceipt; }
            set
            {
                if (note.AmountOfMoney > 0)
                {
                    note.IsReceipt = true;
                    Set(ref note, note);
                }
                else
                {
                    note.IsReceipt = false;
                    Set(ref note, note);
                }
            }
        }

        public DateTime Date
        {
            get
            {
                return note.Date;
            }
            set
            {
                note.Date = value;
                Set(ref note, note);
            }
        }

    }
}
