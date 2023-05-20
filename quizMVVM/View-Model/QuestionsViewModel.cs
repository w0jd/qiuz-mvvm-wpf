using quizMVVM.Model;
using System;
using System.CodeDom.Compiler;
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
        private string _selectedAnswer1;
        private string _selectedAnswer2;
        private string _selectedAnswer3;
        private string _selectedAnswer4;
        private string Wart;
        private string Ilosc;
        private int nr = 0;
        public string wart
        {
            get => Wart;
            set
            {
                Wart = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(wart)));
            }
        }
        public string ilosc
        {
            get => Ilosc;
            set
            {
                Ilosc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ilosc)));
            }
        }
        public string SelectedAnswer1
    {
        get { return _selectedAnswer1; }
        set
        {
            if (_selectedAnswer1 != value)
            {
                _selectedAnswer1 = value;
                
                OnPropertyChanged(nameof(SelectedAnswer1));
                    if (SelectedAnswer1 == "True")
                    {
                        nr = 1;
                
                        string ciag = _list[i];
                        var ciag1 = ciag.Split(',');
                        string wart = ciag1[2];
                        bool czy = checkAndNext(nr, _odp1, wart);
                        i++;
                        showNext(_list);
                    }
            }
        }
    }
        public string SelectedAnswer2
        {
            get { return _selectedAnswer2; }
            set
            {
                if (_selectedAnswer2!= value)
                {
                    _selectedAnswer2 = value;
                    OnPropertyChanged(nameof(SelectedAnswer2));
                    if (SelectedAnswer2 == "True")
                    {
                        nr = 2;
                      
                        string ciag = _list[i];
                        var ciag1 = ciag.Split(',');
                        string wart = ciag1[2];
                        bool czy = checkAndNext(nr, _odp2, wart);
                        i++;
                        showNext(_list);
                    }
                }
            }
        }
        public string SelectedAnswer3
        {
            get { return _selectedAnswer3; }
            set
            {
                if (_selectedAnswer3 != value)
                {
                    _selectedAnswer3 = value;
                    OnPropertyChanged(nameof(SelectedAnswer3));
                    if (SelectedAnswer3 == "True")
                    {
                        nr = 3;
                    
                        string ciag = _list[i];
                        var ciag1 = ciag.Split(',');
                        string wart = ciag1[2];
                        bool czy = checkAndNext(nr, _odp3, wart);
                        i++;
                        showNext(_list);
                    }
                }
            }
        }
        public string SelectedAnswer4
        {
            get { return _selectedAnswer4; }
            set
            {
                if (_selectedAnswer4 != value)
                {
                    _selectedAnswer4 = value;
                    OnPropertyChanged(nameof(SelectedAnswer4));
                    if (SelectedAnswer4 == "True")
                    {
                       
                        nr = 4;
                        string  ciag = _list[i];
                        var ciag1 = ciag.Split(',');
                        string wart = ciag1[2];
                        bool czy=checkAndNext(nr, _odp4,wart );
                        i++;
                        showNext(_list);

                    }
                }
            }
        }
        public bool checkAndNext(int nr, string wart,string wartZbazy)
        {
            if (wartZbazy == wart)
            {
                return true;
            }
            else
            {
                return false;
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
        public void showNext(List<string> list)
        {
            int[] random_answers = { 2, 3, 4, 5 };
            int questionNumber = i;
            if (list.Count() >= i)
            {
                _list = list;
                var ciag = list[questionNumber].Split(',');
                int len = _list.Count;
                _len = len;
                shuffle();
                _tresc = ciag[1];
                _odp1 = ciag[random_answers[0]];
                _odp2 = ciag[random_answers[1]];
                _odp3 = ciag[random_answers[2]];
                _odp4 = ciag[random_answers[3]];
                List<string> listaNiePrzet = new List<string>() { _odp1, _odp2, _odp3, _odp4 };
                var rnd = new Random();
                var result = listaNiePrzet.OrderBy(item => rnd.Next());
                OnPropertyChanged(nameof(odp1));
                OnPropertyChanged(nameof(tresc));
                OnPropertyChanged(nameof(odp2));
                OnPropertyChanged(nameof(odp3));
                OnPropertyChanged(nameof(odp4));
            }
            void shuffle()
            {
                for (int i = random_answers.Length - 1; i > 0; i--)
                {
                    var rand = new Random();
                    int r = rand.Next(0, i);
                    int temp = random_answers[i];
                    random_answers[i] = random_answers[r];
                    random_answers[r] = temp;
                }
            }
        }
    
        public QuestionsViewModel(List<string> list)
        {
            int[] random_answers = { 2, 3, 4, 5 };
            int questionNumber  = i;
            if (list.Count() != 0)
            {
             
                    _list = list;
                    //             while (questionNumber < _list.Count()) {
                    var ciag = list[questionNumber].Split(',');
                    int len = _list.Count;
                    _len = len;
                    shuffle();
                    _tresc = ciag[1];
                    _odp1 = ciag[random_answers[0]];
                    _odp2 = ciag[random_answers[1]];
                    _odp3 = ciag[random_answers[2]];
                    _odp4 = ciag[random_answers[3]];

                    //          }




                    List<string> listaNiePrzet = new List<string>() { _odp1, _odp2, _odp3, _odp4 };
               /*     var rnd = new Random();
                    var result = listaNiePrzet.OrderBy(item => rnd.Next());*/
                
            }
            void shuffle()
            {
                for(int i = random_answers.Length-1; i >0 ; i--)
                {
                    var rand = new Random();
                    int r = rand.Next(0, i);
                    int temp= random_answers[i];
                    random_answers[i] = random_answers[r];
                    random_answers[r] = temp;
                }
            }
        }
        

     
    }
}
