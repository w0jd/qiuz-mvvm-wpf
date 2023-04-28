using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
