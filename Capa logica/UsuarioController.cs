using System;
using System.Collections.Generic;
using System.Text;
using Capa_de_datos;

namespace Capa_logica
{
    public static class UsuarioController
    {

        

     /*   public static bool getUser(string ci, string clave)
        {
            UsuarioModelo u = new UsuarioModelo();
            u = u.validarUser(ci, clave);
            List<string> personaString = new List<string>();
            personaString.Add(u.Nombre);
            personaString.Add(" ");
            personaString.Add(u.Apellido);

            return true;
        }
         */

        public static bool validarUsuario(string ci, string clave)
        {
            UsuarioModelo u = new UsuarioModelo();

            return u.validarUser(ci, clave);
        }


    }
}
