using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quizMVVM.View_Model
{
    internal class SolveQuizViewModel : BaseViewModel
    {
        private string _id;
        public string Id 
        {
            get { return this._id; }
            set 
            { 
                if(!string.Equals(this._id, value))
                {
                    this._id = value;
                    this.OnPropertyChanged(nameof(Id));
                    Console.WriteLine(_id);
                }
            } 
        }
        //private DelegateCommand _checkId;
        //public ICommand CheckId
        //{
        //    get { if (this._checkId == null)
        //            _checkId = new DelegateCommand(new Action(CheckIdExecuted), new Func<bool>(CheckIdCanExecute));
        //    return _checkId;
        //    }
        //}
        //public bool CheckIdCanExecute()
        //{
        //    //do ustalenia wzór 
        //    return true;
        //}
        //public void CheckIdExecuted()
        //{

        //    //if select public_id from quiz where public_id like {_id}
        //}
    }
}
