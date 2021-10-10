using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_de_datos
{
    public class SouvenirModelo : Modelo
    {

        public int id;
        public string nombre;
        public string descripcion;
        public int stock;
        public int precio;
        public DateTime fecha;
        public int cantidad;

        public SouvenirModelo()
        {

        }


        public void altaSouvenir()
        {
            this.comando.CommandText = "INSERT INTO Souvenirs (Nombre, Descripcion, Stock, Precio, FechaAlta) VALUES(" +
                                    "@nombre, @descripcion, @stock, @precio, @fecha);";

            this.comando.Parameters.AddWithValue("@nombre", this.nombre);
            this.comando.Parameters.AddWithValue("@descripcion", this.descripcion);
            this.comando.Parameters.AddWithValue("@stock", this.stock);
            this.comando.Parameters.AddWithValue("@precio", this.precio);
            this.comando.Parameters.AddWithValue("@fecha", this.fecha);
            
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }

        public void bajaSouvenir(int id)
        {
            this.comando.CommandText = "DELETE FROM Souvenirs WHERE id=@id;";
            this.comando.Parameters.AddWithValue("@id", id);
            
            EjecutarQuery(this.comando);
        }

        public void modificarSouvenir(int id, string nombre, string descripcion, int stock, int precio, DateTime fecha)
        {
            this.comando.CommandText = "UPDATE Souvenirs SET Nombre=@nombre, Descripcion=@descripcion, Stock=@stock, " +
                                        "Precio=@precio, FechaAlta=@fecha WHERE id=@id;";

            this.comando.Parameters.AddWithValue("@id", id);
            this.comando.Parameters.AddWithValue("@nombre", nombre);
            this.comando.Parameters.AddWithValue("@descripcion", descripcion);
            this.comando.Parameters.AddWithValue("@stock", stock);
            this.comando.Parameters.AddWithValue("@precio", precio);
            this.comando.Parameters.AddWithValue("@fecha", fecha);

            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }

        public void modificarStock(int id, int stock)
        {
            this.comando.CommandText = "UPDATE Souvenirs SET Stock=@stock WHERE id=@id;";

            this.comando.Parameters.AddWithValue("@id", id);
            this.comando.Parameters.AddWithValue("@stock", stock);

            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }

        public void venderSouvenir(int cantidad)
        {
            this.comando.CommandText = "INSERT INTO Compras (FechaCompra, Producto, Cantidad) VALUES(" +
                                    "@fecha, @producto, @cantidad);";

           
            this.comando.Parameters.AddWithValue("@fecha", this.fecha);
            this.comando.Parameters.AddWithValue("@producto", this.nombre);
            this.comando.Parameters.AddWithValue("@cantidad", cantidad);

            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }


        public List<SouvenirModelo> listarSouvenirs()
        {
            this.comando.CommandText = "SELECT id, Nombre, Descripcion, Stock, Precio, FechaAlta FROM Souvenirs;";
            List<SouvenirModelo> souvenirs = new List<SouvenirModelo>();
            lector = this.comando.ExecuteReader();
            while (lector.Read())
            {
                SouvenirModelo s = new SouvenirModelo();
                s.id = Int32.Parse(lector[0].ToString());
                s.nombre = lector[1].ToString();
                s.descripcion = lector[2].ToString();
                s.stock = Int32.Parse(lector[3].ToString());
                s.precio = Int32.Parse(lector[4].ToString());
                s.fecha = DateTime.Parse(lector[5].ToString());

                souvenirs.Add(s);
            }

            lector.Close();
            return souvenirs;
        }


        public List<SouvenirModelo> listarVentas()
        {
            this.comando.CommandText = "SELECT FechaCompra, Producto, Cantidad FROM Compras;";
            List<SouvenirModelo> compras = new List<SouvenirModelo>();
            lector = this.comando.ExecuteReader();
            while (lector.Read())
            {
                SouvenirModelo s = new SouvenirModelo();
                s.nombre = lector[1].ToString();
                s.cantidad = Int32.Parse(lector[2].ToString());
                s.fecha = DateTime.Parse(lector[0].ToString());
                
                compras.Add(s);
            }

            lector.Close();
            return compras;
        }










    }
}
