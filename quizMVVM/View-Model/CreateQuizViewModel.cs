using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

using System.Windows;
using quizMVVM.Model;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using quizMVVM.View;
namespace quizMVVM.View_Model
{
    internal class CreateQuizViewModel : BaseViewModel
    {
        private string _id;
        private string _Send;
        private Model.MainModel model = new Model.MainModel();
        static string databaseFilename = "quiz.db";
        static string localPath = AppDomain.CurrentDomain.BaseDirectory;
        private List<string> _items;
        public event PropertyChangedEventHandler PropertyChanged;
        static string ConPath = localPath.Replace("\\bin\\Debug", "");
        static private string databasePath = Path.Combine(ConPath, databaseFilename);
        static SQLiteConnection conn = new SQLiteConnection($"Data Source={databasePath}; Version=3");
        private string _Par;
        public CreateQuizViewModel()
        {
            Console.WriteLine("dupa");
        }

        public string Id
        {
            get { return this._id; }
            set
            {
             
                this._id = value;
                this.OnPropertyChanged(nameof(Id));

                var list = MainModel.ShowQuestions(conn, Id);
                conn.Close();
                Random rnd = new Random();
                int jed = rnd.Next(0, 9);
                int dz = rnd.Next(0, 9);
                int set = rnd.Next(0, 9);
                int tys = rnd.Next(0, 9);
                string wybier = jed.ToString() + dz.ToString() + set.ToString() + tys.ToString();
                jed = rnd.Next(0, 9);
                dz = rnd.Next(0, 9);
                set = rnd.Next(0, 9);
                tys = rnd.Next(0, 9);
                string edycja = jed.ToString() + dz.ToString() + set.ToString() + tys.ToString();
                MainModel.AddQuiz(conn, Id, wybier, edycja);

                 
            }
        }
    }

}
