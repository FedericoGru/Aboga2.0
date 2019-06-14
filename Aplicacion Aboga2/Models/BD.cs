using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Aplicacion_Aboga2.Models
{
    public class BD
    {
        public static string connectionString = "Server=.;Database=Aboga2.0;Trusted_Connection=true";

        public static SqlConnection Conectar()
        {
            SqlConnection Conexion = new SqlConnection(connectionString);
            Conexion.Open();
            return Conexion;
        }

        public static void Desconectar(SqlConnection Conexion)
        {
            Conexion.Close();
        }


        public static int ModificarExpediente(Expediente expedientes)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_modificar_Expedientes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@ID_EXPEDIENETES", expedientes.IdExpediente);
            consulta.Parameters.AddWithValue("@ID_TIPO_EXPEDIENTES", expedientes.IdTipoExpediente);
            consulta.Parameters.AddWithValue("@DESCRIPCION", expedientes.Descripcion);
            consulta.Parameters.AddWithValue("@ID_JUZGADO_EXPEDIENTE", expedientes.IdJuzgadoExpediente);
            consulta.Parameters.AddWithValue("@NUMERO_EXPEDIENTES", expedientes.NumeroExpediente);
            consulta.Parameters.AddWithValue("@ESTADO", expedientes.Estado);
            consulta.Parameters.AddWithValue("@CARATULA", expedientes.Caratula);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }



        public static int InsertarExpediente(Expediente expedientes)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Crear_cliente_ORIGINAL";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@ID_EXPEDIENETES", expedientes.IdExpediente);
            consulta.Parameters.AddWithValue("@ID_TIPO_EXPEDIENTES", expedientes.IdTipoExpediente);
            consulta.Parameters.AddWithValue("@DESCRIPCION", expedientes.Descripcion);
            consulta.Parameters.AddWithValue("@ID_JUZGADO_EXPEDIENTE", expedientes.IdJuzgadoExpediente);
            consulta.Parameters.AddWithValue("@NUMERO_EXPEDIENTES", expedientes.NumeroExpediente);
            consulta.Parameters.AddWithValue("@ESTADO", expedientes.Estado);
            consulta.Parameters.AddWithValue("@CARATULA", expedientes.Caratula);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }



        public static List<Expediente> TraerExpedientes()
        {
            /*List<Personaje> ListaPj = new List<Personaje>();*/
            List<Expediente> Lista = new List<Expediente>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Expedientes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdExpedientes = Convert.ToInt32(dataReader["ID_EXPEDIENETES"]);
                int IdTipoExpedientes = Convert.ToInt32(dataReader["ID_TIPO_EXPEDIENTES"]);
                string Descripcions = dataReader["DESCRIPCION"].ToString();
                int IdJuzgadoExpedientes = Convert.ToInt32(dataReader["ID_JUZGADO_EXPEDIENTE"]);
                int NumeroExpedientes = Convert.ToInt32(dataReader["NUMERO_EXPEDIENTES"]);
                int Estado = Convert.ToInt32(dataReader["ESTADO"]);
                string Caratula = dataReader["CARATULA"].ToString();
                Expediente exp = new Expediente(IdExpedientes, IdTipoExpedientes, Descripcions, IdJuzgadoExpedientes, NumeroExpedientes, Estado, Caratula);
                Lista.Add(exp);
            }
            Desconectar(Conexion);
            return Lista;
        }
        public static int Eliminar(int IdExpediente)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_eliminar_Expedientes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("id", IdExpediente);
            int RegsAfectados = consulta.ExecuteNonQuery();
            Desconectar(Conexion);
            return RegsAfectados;
        }


        public static Expediente TraerExpediente(int idexpediente)
        {
            /*List<Personaje> ListaPj = new List<Personaje>();*/
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "sp_Traer_Expediente";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Id_Expedientes", idexpediente);
            SqlDataReader dataReader = consulta.ExecuteReader();
            Expediente exp=new Expediente();
            while (dataReader.Read())
            {
                int IdExpedientes = Convert.ToInt32(dataReader["ID_EXPEDIENETES"]);
                int IdTipoExpedientes = Convert.ToInt32(dataReader["ID_TIPO_EXPEDIENTES"]);
                string Descripcions = dataReader["DESCRIPCION"].ToString();
                int IdJuzgadoExpedientes = Convert.ToInt32(dataReader["ID_JUZGADO_EXPEDIENTE"]);
                int NumeroExpedientes = Convert.ToInt32(dataReader["NUMERO_EXPEDIENTES"]);
                int Estado = Convert.ToInt32(dataReader["ESTADO"]);
                string Caratula = dataReader["CARATULA"].ToString();
                exp = new Expediente(IdExpedientes, IdTipoExpedientes, Descripcions, IdJuzgadoExpedientes, NumeroExpedientes, Estado, Caratula);
            }
            Desconectar(Conexion);
            return exp;
        }



    }
}