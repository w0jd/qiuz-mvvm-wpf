using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using quizMVVM.Model;
using System.IO;
using System.Collections;

namespace quizMVVM.View_Model
{
    internal class SolveQuizViewModel : BaseViewModel
    {
        private string _id;
        private Model.MainModel model = new Model.MainModel();
       static string databaseFilename = "quiz.db";
        static private string databasePath = Path.Combine("C:\\Users\\Wojtek\\Documents\\GitHub\\qiuz-mvvm-wpf\\quizMVVM", databaseFilename);
        static SQLiteConnection conn = new SQLiteConnection($"Data Source={databasePath};Version=3");

        public SolveQuizViewModel()
        {
            Console.WriteLine(conn);
            ArrayList array = new ArrayList();
          array=  MainModel.ShowAllQuizes(conn);
            conn.Close();
        }

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
