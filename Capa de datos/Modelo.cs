using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_de_datos
{
    public class Modelo
    {

        protected string ipDB;
        protected string NombreDB;
        protected string UsuarioDB;
        protected string PasswordDB;
        protected MySqlConnection conexion;
        protected MySqlCommand comando;
        protected MySqlDataReader lector;

        public Modelo()
        {
            try
            {
                connection();
                Console.WriteLine("SE CONECTO!");
                
            }
            catch (MySqlException e)
            {
                    string mensaje = "";
                    switch (e.Number)
                    {
                        case 1042:
                            mensaje = "La conexion a esa direccion no existe.";
                            break;
                        case 0:
                            mensaje = "No se pudo conectar a la base de datos.";
                            break;
                    }
                    throw new Exception(mensaje); 
              //  throw new Exception(e.Number.ToString());
            }
        }

        public void EjecutarQuery(MySqlCommand comando)
        {
            try
            {
                this.comando.ExecuteNonQuery();
                
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Number.ToString());
            }
        }

        public void connection()
        {
            this.InicializarConexion();
            conexion = new MySqlConnection(
                 "server=" + this.ipDB + ";" +
                "userid=" + this.UsuarioDB + ";" +
                "password=" + this.PasswordDB + ";" +
                "database=" + this.NombreDB);
            conexion.Open();
            this.comando = new MySqlCommand();
            this.comando.Connection = this.conexion;
        }


        protected void InicializarConexion()
        {

            this.ipDB = "localhost";
            this.UsuarioDB = "root";
            this.NombreDB = "SouvenirsDB";
            this.PasswordDB = "andylu30";
        }






    }
}
