using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BUHALOVO.MVVM
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public static NoteVM NoteVm { get; set; } = new();
        public static TypeVM TypeVm { get; set; } = new();

        public static CreateTypeWinVM TypeWinVm { get; set; } = new();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propName = "")
        {
            if (field != null)
            {
                if (!field.Equals(value))
                {
                    field = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        }

        protected void Set<T>(ref T field, T value, params string[] propNames)
        {
            if (!field.Equals(value))
            {
                field = value;
                foreach (var name in propNames)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        protected void Notify(params string[] names)
        {
            foreach (var name in names)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
