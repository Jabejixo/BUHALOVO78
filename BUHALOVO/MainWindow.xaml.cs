using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using BUHALOVO.MVVM;
using Wpf.Ui.Controls;

namespace BUHALOVO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        public ViewModelBase viewModel = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
