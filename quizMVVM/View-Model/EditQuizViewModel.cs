using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quizMVVM.Model;
using System.Windows.Controls;
using System.Windows;
using quizMVVM.Model;

using System.Windows.Input;
using quizMVVM.View;
namespace quizMVVM.View_Model
{
    internal class EditQuizViewModel : BaseViewModel
    {
        private Model.MainModel model = new Model.MainModel();
        static string databaseFilename = "quiz.db";
        static string localPath = AppDomain.CurrentDomain.BaseDirectory;
        public event PropertyChangedEventHandler PropertyChanged;
        static string ConPath = localPath.Replace("\\bin\\Debug", "");
        static private string databasePath = Path.Combine(ConPath, databaseFilename);
        static SQLiteConnection conn = new SQLiteConnection($"Data Source={databasePath}; Version=3");
        private List<string> _list;
        private int _len;
        public EditQuizViewModel(int id_quiz)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Close();
            conn.Open();
            Int64 id_QUIZ = 0;
            string idQuizString = id_quiz.ToString();
            Int64.TryParse(idQuizString, out id_QUIZ);
            command = conn.CreateCommand();
            command.CommandText = $"SELECT pytania.tresc, pytania.odpowiedz_1, pytania.odpowiedz_2, pytania.odpowiedz_3, pytania.odpowiedz_4, quizy.nazwa_quizu,quizy.id_quiz FROM pytania, quizy WHERE pytania.id_quiz = (SELECT quizy.id_quiz FROM quizy WHERE id_quiz = {id_QUIZ}) LIMIT 1";
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                questionid = i.ToString();
                string Name = (string)reader["nazwa_quizu"];
                string tresc = (string)reader["tresc"];
                string odp1 = (string)reader["odpowiedz_1"];
                string odp2 = (string)reader["odpowiedz_2"];
                string odp3 = (string)reader["odpowiedz_3"];
                string odp4 = (string)reader["odpowiedz_4"];
                _tresc = tresc;
                _staraTresc = tresc;
                _odp1 = odp1;
                _staraodp1 = odp1;
                _odp2 = odp2;
                _staraodp2 = odp2;
                _odp3 = odp3;
                _staraodp3 = odp3;
                _odp4 = odp4;
                _staraodp4 = odp4;
                _name = Name;
                _oldName = Name;
                long intid = (Int64)reader["id_quiz"];
                quizid = intid.ToString();
                i++;
            }
        }
        public void showNext(List<string> list)
        {
            int questionNumber = i;
            if (list.Count() > i)
            {
                _list = list;
                var ciag = list[questionNumber].Split(',');
                int len = _list.Count;
                _len = len;   
                _tresc = ciag[1];
                _odp1 = ciag[2];
                _odp2 = ciag[3];
                _odp3 = ciag[4];
                _odp4 = ciag[5];
                _name = ciag[6];
                OnPropertyChanged(nameof(odp1));
                OnPropertyChanged(nameof(Tresc));
                OnPropertyChanged(nameof(odp2));
                OnPropertyChanged(nameof(odp3));
                OnPropertyChanged(nameof(odp4));
                OnPropertyChanged(nameof(Name));
                i++;
            }          
        }
        private string _odp1;
        private string _staraodp1;
        private string _name;
        private string _oldName;
        private string _staraTresc;
        private string _odp2;
        private string _staraodp2;
        private string _odp3;
        private string _staraodp3;
        private string _odp4;
        private string _staraodp4;
        private string _tresc;
        private string quizid;
        private string questionid;
        public string OldName
        {
            get => _oldName;
            set
            {
                _oldName = value;
                OnPropertyChanged(nameof(OldName));
            }
        }
        public string odp1
        {
            get => _odp1;
            set
            {
                _odp1 = value;        
            }
        }
        public string StaraOdp1
        {
            get => _staraodp1;
            set
            {
                _staraodp1 = value;
                OnPropertyChanged(nameof(StaraOdp1));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        public string StaraTresc
        {
            get => _staraTresc;
            set
            {
                _staraTresc = value;
                OnPropertyChanged(nameof(StaraTresc));
            }
        }

        public string odp2
        {
            get => _odp2;
            set
            {
                _odp2 = value;
            }
        }

        public string StaraOdp2
        {
            get => _staraodp2;
            set
            {
                _staraodp2 = value;
                OnPropertyChanged(nameof(StaraOdp2));
            }
        }

        public string odp3
        {
            get => _odp3;
            set
            {
                _odp3 = value;
            }
        }

        public string StaraOdp3
        {
            get => _staraodp3;
            set
            {
                _staraodp3 = value;
                OnPropertyChanged(nameof(StaraOdp3));
            }
        }

        public string odp4
        {
            get => _odp4;
            set
            {
                _odp4 = value;
            }
        }

        public string StaraOdp4
        {
            get => _staraodp4;
            set
            {
                _staraodp4 = value;
                OnPropertyChanged(nameof(StaraOdp4));
            }
        }

        public string Tresc
        {
            get => _tresc;
            set
            {
                _tresc = value;
                OnPropertyChanged(nameof(Tresc));
            }
        }

    
        private ICommand _EditQestion;
        public ICommand EditQestion
        {
            get
            {
                if (_EditQestion == null)
                    questionid = i.ToString();
                _EditQestion = new RelayCommand(i => MainModel.EditQuizQuestion(conn,Tresc,odp1,odp2,odp3,odp4,questionid), null);
                questionid = i.ToString();
                return _EditQestion;

            }
        }
        private ICommand _NextQestion;
        public ICommand NextQestion
        {
            get
            {
                if (_NextQestion == null)
                    questionid = i.ToString();
                _NextQestion = new RelayCommand(i => showNext(_list),null);
                questionid = i.ToString();
                return _NextQestion;

            }
        }
        int i = 0;
    }
}
