using quizMVVM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
namespace quizMVVM.View_Model
{
    public class QuestionsViewModel : BaseViewModel
    {
        private string _odp1;
        private string _odp2;
        private string _odp3;
        private string _odp4;
        private string _tresc;
        private int _len;
        private bool isRun = true;
        private Model.MainModel model = new Model.MainModel();
        static string databaseFilename = "quiz.db";
        static string localPath = AppDomain.CurrentDomain.BaseDirectory;
        public event PropertyChangedEventHandler PropertyChanged;
        static string ConPath = localPath.Replace("\\bin\\Debug", "");
        static private string databasePath = Path.Combine(ConPath, databaseFilename);
        static SQLiteConnection conn = new SQLiteConnection($"Data Source={databasePath}; Version=3");
        private List<string> _list;
    
        int i = 0;
        private string _selectedAnswer;

  public string SelectedAnswer
    {
        get { return _selectedAnswer; }
        set
        {
            if (_selectedAnswer != value)
            {
                _selectedAnswer = value;
                    var dupa = nameof(SelectedAnswer);
                OnPropertyChanged(nameof(SelectedAnswer));
            }
        }
    }

        public string odp1
        {
            get => _odp1;
            set
            {
                _odp1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(odp1)));
            }
        }
        public string odp2
        {
            get => _odp2;
            set
            {
                _odp2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(odp2)));
            }
        }
        public string odp3
        {
            get => _odp3;
            set
            {
                _odp3 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(odp3)));
            }
        }
        public string odp4
        {
            get => _odp4;
            set
            {
                _odp4 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(odp4)));
            }
        }
        public string tresc
        {
            get => _tresc;
            set
            {
                _tresc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tresc)));
            }
        }
    
        public QuestionsViewModel(List<string> list)
        {
        
            _list = list;
            var ciag= list[0].Split(',');
           
            int len = _list.Count;
            _len = len;
            tresc =ciag[1];
            _odp1 = ciag[2];
            _odp2 = ciag[3];
            _odp3 = ciag[4];
            _odp4 = ciag[5];

        }

    }
}
