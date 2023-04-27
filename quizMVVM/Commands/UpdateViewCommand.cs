using quizMVVM.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quizMVVM.Commands
{
    internal class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "A")
            {
                viewModel.SelectedViewModel = new CreateQuizViewModel();
            }
            else if (parameter.ToString() == "B")
            {
                viewModel.SelectedViewModel = new SolveQuizViewModel();
            }
        }
    }
}
