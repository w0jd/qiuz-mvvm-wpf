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
             return this.id.ToString()+", "+this.nazwa;
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
       public static ArrayList ShowAllQuizes(SQLiteConnection conn)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM quizy";
            reader = command.ExecuteReader();
            ArrayList arrayList = new ArrayList();
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
       public static ArrayList ShowQuestions(SQLiteConnection conn,string id_quiz)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT * FROM pyatnia WHERE id_quiz={id_quiz}";
            reader = command.ExecuteReader();
            ArrayList arrayList = new ArrayList();
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
    }
}
