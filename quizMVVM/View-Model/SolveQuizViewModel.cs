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
using System.ComponentModel;
using System.Windows.Input;
using quizMVVM.View;

namespace quizMVVM.View_Model
{
    internal class SolveQuizViewModel : BaseViewModel
    {
        private string _id;
        private Model.MainModel model = new Model.MainModel();
        static string databaseFilename = "quiz.db";
        static string localPath= AppDomain.CurrentDomain.BaseDirectory;
        private List<string> _items;
        public event PropertyChangedEventHandler PropertyChanged;
        static string ConPath = localPath.Replace("\\bin\\Debug","");
        static private string databasePath = Path.Combine(ConPath, databaseFilename);
        static SQLiteConnection conn = new SQLiteConnection($"Data Source={databasePath}; Version=3");
        private List<string> list =new List<string>();
        public SolveQuizViewModel()
        {

            List<string> array = new List<string>();
            Items =   MainModel.ShowAllQuizes(conn);
            conn.Close();
        }
        public List<string> Items
        {
            get => _items;
            set {
                _items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            } 
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

                    var list=MainModel.ShowQuestions(conn, Id);
                    conn.Close();
                    if (list.Count()!=0)
                    {
                        var Questions = new Questions(list);
                        var window = new Window();
                        window.Content = Questions;
                        window.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nie ma takiego quizu");
                    }
                }
            } 
        }
  
    }
 
}
