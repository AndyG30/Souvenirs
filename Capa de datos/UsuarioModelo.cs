using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_de_datos
{
    public class UsuarioModelo : Modelo
    {

        public string ci;
        public string nombre;
        public string apellido;
        public string tipo;
        public string clave;

        public UsuarioModelo()
        {

        }   


        public bool validarUser(string ci, string clave)
        {
            this.comando.CommandText = "SELECT ci, Nombre, Apellido, Tipo, Clave FROM Usuarios WHERE ci=@ci AND Clave=@clave";
            this.comando.Parameters.AddWithValue("ci", ci);
            this.comando.Parameters.AddWithValue("clave", clave);
            /*  List<UsuarioModelo> usuarios = new List<UsuarioModelo>();
              lector = this.comando.ExecuteReader();

              while (lector.Read())
              {
                  UsuarioModelo u = new UsuarioModelo();
                  u.ci = lector[0].ToString();
                  u.nombre = lector[1].ToString();
                  u.apellido = lector[2].ToString();
                  u.tipo = lector[3].ToString();
                  u.clave = lector[4].ToString();
                  usuarios.Add(u);
              }
              lector.Close();

              return usuarios;  */

            lector = this.comando.ExecuteReader();
            if (lector.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        



    }
}
