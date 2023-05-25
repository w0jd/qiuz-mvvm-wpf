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
        private string _tresc;
        private string _odp1;
        private string _odp2;
        private string _odp3;
        private string _odp4;
        private Int64 _id_quiz;
        public string Tresc{
            get => _tresc;
            set
            {
                _tresc = value;
            }
        }
        public string odp1
        {
            get => _odp1;
            set { _odp1 = value; }
        }
        public string odp2
        {
            get => _odp2;
            set { _odp2 = value; }
        }
        public string odp3
        {
            get => _odp3;
            set { _odp3 = value; }
        }
        public string odp4
        {
            get => _odp4;
            set { _odp4 = value; }
        }
        public Int64 Id_quiz
        {
            get => _id_quiz;
            set { _id_quiz = value; }
        }
        private Model.MainModel model = new Model.MainModel();
        static string databaseFilename = "quiz.db";
        static string localPath = AppDomain.CurrentDomain.BaseDirectory;
        private List<string> _items;
        public event PropertyChangedEventHandler PropertyChanged;
        static string ConPath = localPath.Replace("\\bin\\Debug", "");
        static private string databasePath = Path.Combine(ConPath, databaseFilename);
        static SQLiteConnection conn = new SQLiteConnection($"Data Source={databasePath}; Version=3");
        private ICommand _AddQestion;
        void CreateQuestions()
        {
            MainModel.AddQuestion(conn, _tresc, _odp1, _odp2,  _odp3, _odp4, _id_quiz);
        }
        public ICommand AddQestion
        {
            get
            {
                if (_AddQestion == null)
                    _AddQestion = new RelayCommand(i => CreateQuestions(), null) ;
               
                return _AddQestion;

            }
        }
        public CreateQuizViewModel()
        {
           // Console.WriteLine("dupa");
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
