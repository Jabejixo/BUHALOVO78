using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonLib;

namespace BUHALOVO.MVVM
{
    public class TypeVM : ViewModelBase
    {
        private string selectedType = "";
        public string SelectedType
        {
            get => selectedType;
            set => Set(ref selectedType, value);
        }
        public ObservableCollection<string> Types { get; set; }

        public void CreateType()
        {
            NoteVm.Types.Add(TypeWinVm.NewType);
            FileManager.Serialize(NoteVm.Types, "Types");
            TypeWinVm.CloseTypeWin();
        }

        public TypeVM()
        {
            TypeVm = this;
        }

    }
}
