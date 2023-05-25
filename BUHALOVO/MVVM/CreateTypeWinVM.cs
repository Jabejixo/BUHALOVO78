using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BUHALOVO.MVVM
{
    public class CreateTypeWinVM : ViewModelBase
    {
        private CreateTypeWin win = new CreateTypeWin();
        public CreateTypeWin Win { get { return win; } set {Set(ref win, value);}}

        private string newType = "";
        public string NewType
        {
            get => newType;
            set => Set(ref newType, value);
        }


        private RelayCommand commandNewTypeWin;
        public RelayCommand CommandNewTypeWin
        {
            get
            {
                return commandNewTypeWin ?? (commandNewTypeWin = new RelayCommand(obj =>
                {
                    NewTypeWin();
                }));
            }
        }

        private RelayCommand commandNewType;
        public RelayCommand CommandNewType
        {
            get
            {
                return commandNewType ?? (commandNewType = new RelayCommand(obj =>
                {
                   TypeVm.CreateType();
                }));
            }
        }

        private void NewTypeWin()
        {
            Win.DataContext = this;
            Win.Show();
        }

        public void CloseTypeWin()
        {
            Win.Close();
        }

        public CreateTypeWinVM()
        {
            TypeWinVm = this;
        }
    }
}
