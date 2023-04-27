using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;

namespace quizMVVM.Model
{
    internal class quiz{
        
        int id;
        string nazwa;
    }
    internal class pytania
    {
        int id_pyt;
    }
    internal class MainModel
    {
        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=quiz.db;Version=3");

    }
}
