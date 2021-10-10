using System;
using System.Collections.Generic;
using System.Text;
using Capa_de_datos;
using MySql.Data.MySqlClient;

namespace Capa_logica
{
    public static class UsuarioController
    {

      

        public static bool validarUsuario(string ci, string clave)
        {
            UsuarioModelo u = new UsuarioModelo();
            
            return u.validarUser(ci, clave);
        }

        


    }
}
