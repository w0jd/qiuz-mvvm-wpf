using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace quizMVVM.Model
{
    internal class quiz {

        int id;
        string nazwa;
        string privteId;
        string publicId;
    }
    internal class pytania
    {
        int id_pyt;
        string tresc;
        string odp1;
        string odp2;
        string odp3;
        string odp4;
        int IdQuiz;

    }
/*    internal class listOfQuestions(pytania obj)
        {

        }*/
    internal class MainModel
    {
        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=quiz.db;Version=3");

    }
}
