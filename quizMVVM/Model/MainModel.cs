using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;
using System.Collections;
using System.IO;

namespace quizMVVM.Model
{
    internal class quiz{
        Int64 id;
        string nazwa;
        public quiz(Int64 id ,string nazwa)
        {

            this.id = id;
            this.nazwa = nazwa;

            
        }   
        public string giveString()
        {
             return this.id.ToString()+", "+this.nazwa;
        }
    
    }
    internal class pytania
    {
        int id_pyt;
    }
    internal class MainModel
    {
/*        static string lok = Directory.GetCurrentDirectory()+"quiz.db";
        static SQLiteConnection conn = new SQLiteConnection($@"Data Source={lok};Version=3");*/
       public static ArrayList ShowAllQuizes(SQLiteConnection conn)
        {

            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Open();
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirectory);
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM quizy";
            reader = command.ExecuteReader();
            ArrayList arrayList = new ArrayList();
            while (reader.Read())
            {
                Console.WriteLine("dupa");
                Int64 id = (Int64)reader["id_quiz"];
                string nazwaQuiz = (string)reader["nazwa_quizu"];
                quiz JedenQuiz = new quiz(id,nazwaQuiz);

                string wart=JedenQuiz.giveString();
                arrayList.Add(wart);
            }
            return arrayList;

        }


    }
}
