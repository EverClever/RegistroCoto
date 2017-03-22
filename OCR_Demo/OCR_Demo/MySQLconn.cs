using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace OCR_Demo
{
    class MySQLconn
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public MySQLconn()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "recogto.hopto.org";
            database = "Recogto";
            uid = "lavariega";
            password = "lavariega";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Hola");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        
        /*StoredProcedure
        public void SP()
        {
            string rtn = "revisaplaca";
            this.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(rtn, connection);
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@placa", "VR3270");

            MySqlDataReader rdr = cmd.ExecuteReader();

            User Persona=null;

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    User Record = new User();
                    Record.Nombre = rdr[1].ToString();
                    Record.Placa = rdr[2].ToString();
                    Record.Residente = rdr.GetUInt16(3);
                    Record.Casa = rdr[4].ToString();
                    Record.Numero = rdr[5].ToString();
                    Persona = Record;
                }

                Console.WriteLine(Persona.Nombre);
            }
            else
            {
                Console.WriteLine("Hola");
            }
        }*/
        /*
        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        public List <string> [] Select()
        {
        }

        //Count statement
        public int Count()
        {
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }*/
    }
}
