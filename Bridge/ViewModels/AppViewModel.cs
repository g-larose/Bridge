using Bridge.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bridge.ViewModels
{
    internal class AppViewModel : ViewModelBase
    {
        public ICommand ExitAppCommand { get; set; }

     

        public AppViewModel()
        {
            ExitAppCommand = new RelayCommand(exitAppCommand);
        }

        private void exitAppCommand()
        {
            Environment.Exit(0);
        }
    }
}
