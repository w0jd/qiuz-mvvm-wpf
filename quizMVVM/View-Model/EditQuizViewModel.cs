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
                OnPropertyChanged(nameof(Name));
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

        public string Odp3
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

        public string Odp4
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

        int i = 0;
    }
}
