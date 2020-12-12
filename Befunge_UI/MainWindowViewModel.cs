using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Befunge_UI
{
    public class MainWindowViewModel
    {
        public string ProgramContent
        {
            get;
            set;
        }

        public ICommand LoadInputCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    throw new NotImplementedException();
                },
                p => true);
            }
        }

        public ICommand RunCodeCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    var test = this.ProgramContent;
                    throw new NotImplementedException();
                },
                p => true);
            }
        }
    }
}
