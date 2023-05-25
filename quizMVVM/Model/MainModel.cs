using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Windows;

namespace quizMVVM.Model
{
    internal class quiz{
        Int64 id;
        string nazwa;
        string public_id;
        string private_id;
        public quiz(Int64 id ,string nazwa, string public_id, string private_id)
        {

            this.id = id;
            this.nazwa = nazwa;
            this.public_id= public_id;
            this.private_id= private_id;

            
        }   
        public string giveString()
        {
             return this.id.ToString()+", "+this.nazwa+", "+this.public_id+", "+this.private_id;
        }
    
    }
    internal class pytania
    {
        Int64 id_pyt;
        string tresc;
        string odp1;
        string odp2;
        string odp3;
        string odp4;
        Int64 id_quizy;
        public pytania(Int64 id_pyt,string tresc,string odp1,string odp2,string odp3,string odp4, Int64 id_quizu)
        {
            this.id_pyt = id_pyt;
            this.tresc = tresc;
            this.odp1 = odp1;
            this.odp2 = odp2;
            this.odp3 = odp3;
            this.odp4 = odp4;
            this.id_quizy= id_quizu;
        }
        public string giveString()
        {
            return this.id_pyt.ToString()+","+this.tresc+","+this.odp1+","+this.odp2+","+this.odp3+","+this.odp4+","+this.id_quizy.ToString();
        }
    }
    internal class MainModel
    {
        
       public static List<string> ShowAllQuizes(SQLiteConnection conn)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM quizy";
            reader = command.ExecuteReader();
            List<string> arrayList = new List<string>();
            while (reader.Read()) { 
                Int64 id = (Int64)reader["id_quiz"];
                string nazwaQuiz = (string)reader["nazwa_quizu"];
                string public_id = (string)reader["public_id"];
                string private_id = (string)reader["private_id"];
                quiz JedenQuiz = new quiz(id,nazwaQuiz,public_id,private_id);
                string wart=JedenQuiz.giveString();
                arrayList.Add(wart);
            }
       
            return arrayList;
        }
       public static List<string> ShowQuestions(SQLiteConnection conn,string id_quiz)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Close();
            conn.Open();
            Int64 id_QUIZ = 0;
            Int64.TryParse(id_quiz, out id_QUIZ);
            command = conn.CreateCommand();
            command.CommandText = $"SELECT * FROM pytania WHERE id_quiz= (SELECT id_quiz FROM quizy WHERE public_id={id_QUIZ} )";
            reader = command.ExecuteReader();
            List<string> arrayList = new List<string>();

            while (reader.Read())
            {
                Int64 id = (Int64)reader["id_pytania"];
                string tresc = (string)reader["tresc"];
                string odp1 = (string)reader["odpowiedz_1"];
                string odp2 = (string)reader["odpowiedz_2"];
                string odp3 = (string)reader["odpowiedz_3"];
                string odp4 = (string)reader["odpowiedz_4"];
                Int64 id_quizu = (Int64)reader["id_quiz"];
                pytania Pytania=new pytania(id,tresc,odp1,odp2,odp3,odp4,id_quizu);
                string wart=Pytania.giveString();
                arrayList.Add(wart);
            }
            return arrayList;
        }
        public static void AddQuiz(SQLiteConnection conn,string nazwa,string idCzyt,string idEdit)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"INSERT INTO quizy(nazwa_quizu,private_id,public_id) VALUES ('{nazwa}','{idEdit}','{idCzyt}')";
            reader = command.ExecuteReader();
            conn.Close();
        }
        public static void EditQuizName(SQLiteConnection conn,string NewName,Int64 quizid)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"UPDATE quizy SET nazwa_quizu='{NewName}' WHERE id_quiz={quizid} ";
            reader = command.ExecuteReader();
            conn.Close();
        }
        public static void EditQuizQuestion(SQLiteConnection conn, string NowaTresc, string NowaOdp1, string NowaOdp2, string NowaOdp3, string NowaOdp4,Int64 questionId)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"UPDATE pytania SET tresc='{NowaTresc}',odp1='{NowaOdp1}',odp2='{NowaOdp2}',odp3='{NowaOdp3}',,odp4='{NowaOdp4}' WHERE id_pytania={questionId} ";
            reader = command.ExecuteReader();
            conn.Close();
        }
        public static void AddQuestion(SQLiteConnection conn,string tresc,string odp1,string odp2,string odp3,string odp4, Int64 id_quiz) 
        {

            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"INSERT INTO pytania(tresc,odpowiedz_1,odpowiedz_2,odpowiedz_3,odpowiedz_4,id_quiz) VALUES ('{tresc}','{odp1}','{odp2}','{odp3}','{odp4}','{id_quiz}')";
            reader = command.ExecuteReader();
            MessageBox.Show("operacja wykonana");
            conn.Close();
        }
    }
}
