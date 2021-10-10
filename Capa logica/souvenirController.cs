using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Capa_de_datos;

namespace Capa_logica
{
    public static class souvenirController
    {

        public static void alta(string nombre, string descripcion, int stock, int precio, DateTime fecha)
        {
            SouvenirModelo s = new SouvenirModelo();
            s.nombre = nombre;
            s.descripcion = descripcion;
            s.stock = stock;
            s.precio = precio;
            s.fecha = fecha;
            s.altaSouvenir();
        }


        public static void baja(int id)
        {
            SouvenirModelo s = new SouvenirModelo();
           // s.id = id;
            s.bajaSouvenir(id);
        }

        public static void modificar(int id, string nombre, string descripcion, int stock, int precio, DateTime fecha)
        {
            SouvenirModelo s = new SouvenirModelo();
          //  s.nombre = nombre;
          //  s.descripcion = descripcion;
          //  s.stock = stock;
          //  s.precio = precio;
          //  s.fecha = fecha;
            s.modificarSouvenir(id, nombre, descripcion, stock, precio, fecha);
        }

        public static void vender(int id, DateTime fecha, string nombre, int stock, int cantidad)
        {
            SouvenirModelo s = new SouvenirModelo();
            s.modificarStock(id, stock);
            s.nombre = nombre;
            s.fecha = fecha;
            s.venderSouvenir(cantidad);
        }




        public static DataTable listarSouvenirs()
        {
            SouvenirModelo s = new SouvenirModelo();
            List<SouvenirModelo> souvenirs = s.listarSouvenirs();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Descripcion");
            tabla.Columns.Add("Stock");
            tabla.Columns.Add("Precio");
            tabla.Columns.Add("Fecha");
            foreach (SouvenirModelo souvenir in souvenirs)
            {
                tabla.Rows.Add(souvenir.id, souvenir.nombre, souvenir.descripcion, souvenir.stock, souvenir.precio, souvenir.fecha);
            }
            return tabla;
        }


        public static DataTable listarVentas()
        {
            SouvenirModelo s = new SouvenirModelo();
            List<SouvenirModelo> compras = s.listarVentas();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Producto");
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("Fecha");
            foreach (SouvenirModelo compra in compras)
            {
                tabla.Rows.Add(compra.nombre, compra.cantidad, compra.fecha);
            }
            return tabla;
        }







    }
}
