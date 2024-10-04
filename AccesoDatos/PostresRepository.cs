using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PostresRepository
    {
        public int IngresarPostre(Postres postre)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String insert = "";
                insert = insert + "INSERT INTO [dbo].[Postres] " + "\n";
                insert = insert + "           ([Nombre] " + "\n";
                insert = insert + "           ,[Descripcion] " + "\n";
                insert = insert + "           ,[Precio] " + "\n";
                insert = insert + "           ,[FechaVencimiento] " + "\n";
                insert = insert + "           ,[Estado] " + "\n";
                insert = insert + "           ,[Stock] " + "\n";
                insert = insert + "           ,[Calorias]) " + "\n";
                insert = insert + "     VALUES " + "\n";
                insert = insert + "           (@Nombre " + "\n";
                insert = insert + "           ,@Descripcion " + "\n";
                insert = insert + "           ,@Precio " + "\n";
                insert = insert + "           ,@FechaVencimiento" + "\n";
                insert = insert + "           ,@Estado " + "\n";
                insert = insert + "           ,@Stock " + "\n";
                insert = insert + "           ,@Calorias)";

                using (SqlCommand comando = new SqlCommand(insert, conexion)) 
                {
                    comando.Parameters.AddWithValue("Descripcion", postre.Descripcion);
                    comando.Parameters.AddWithValue("Nombre", postre.Nombre);
                    comando.Parameters.AddWithValue("Precio", postre.Precio);
                    comando.Parameters.AddWithValue("FechaVencimiento", postre.FechaVencimiento);
                    comando.Parameters.AddWithValue("Estado", postre.Estado);
                    comando.Parameters.AddWithValue("Stock", postre.Stock);
                    comando.Parameters.AddWithValue("Calorias", postre.Calorias);

                    int resultado = comando.ExecuteNonQuery();
                    return resultado;
                }
            }
        }
    }
}
