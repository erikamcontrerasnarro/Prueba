using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DATOS
{
    public class HelperSQL : IDisposable
    {

        public string strConexion = System.Configuration.ConfigurationManager.AppSettings["conexion"];


        public DataTable EjecutaConsultaConParametros(string procedure, object[] paramName, object[] paramValue, out string po_log) {

            DataTable oDT = new DataTable();
            po_log = string.Empty;

            using (SqlCommand comando = new SqlCommand())
            {
                comando.CommandTimeout = 100;
                using (SqlConnection conexion = new SqlConnection())
                {
                    try
                    {
                        conexion.ConnectionString = strConexion;
                        conexion.Open();
                        if (conexion.State == ConnectionState.Closed) {
                            return oDT;
                        }
                        comando.CommandText = procedure;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Connection = conexion;
                        for (int i = 0; i <= paramName.Length - 1; i++)
                        {
                            object value = paramValue[i];
                            if (value == null) value = DBNull.Value; else value =  paramValue[i];
                            comando.Parameters.AddWithValue("" + paramName[i], value);
                        }
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            oDT.Load(lector);
                        }
                    }
                    catch (Exception e)
                    {
                        po_log = e.Message;
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            return oDT;
    }

        public DataTable EjecutaConsultaSinParametros(string procedure, out string po_log)
        {

            DataTable oDT = new DataTable();
            po_log = string.Empty;

            using (SqlCommand comando = new SqlCommand())
            {
                comando.CommandTimeout = 100;
                using (SqlConnection conexion = new SqlConnection())
                {
                    try
                    {
                        conexion.ConnectionString = strConexion;
                        conexion.Open();
                        if (conexion.State == ConnectionState.Closed)
                        {
                            return oDT;
                        }
                        comando.CommandText = procedure;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Connection = conexion;
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            oDT.Load(lector);
                        }
                    }
                    catch (Exception e)
                    {
                        po_log = e.Message;
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            return oDT;
        }


        public int EjecutaComandoConParametros(string comando, object[] paramName, object[] paramValue, out string po_log)
        {

            int resultado = -1;
            po_log = string.Empty;

            using (SqlCommand comand = new SqlCommand())
            {
                comand.CommandTimeout = 100;
                using (SqlConnection conexion = new SqlConnection())
                {
                    try
                    {
                        conexion.ConnectionString = strConexion;
                        conexion.Open();
                        if (conexion.State == ConnectionState.Closed)
                        {
                            throw new System.InvalidOperationException("La conexión a BD esta cerrada.");
                        }
                        comand.CommandText = comando;
                        comand.CommandType = CommandType.StoredProcedure;
                        comand.Connection = conexion;
                        for (int i = 0; i <= paramName.Length - 1; i++)
                        {
                            object value = paramValue[i];
                            if (value == null) value = DBNull.Value; else value = paramValue[i];
                            comand.Parameters.AddWithValue("" + paramName[i], value);
                        }
                        resultado = comand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        po_log = e.Message;
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            return resultado;
        }


        #region "IDisposable Support"
        private bool disposedValue;

        protected void Dispose(bool disposing) {
            if (!this.disposedValue) {
                if (disposing) {
                //_DatosUsuario.Dispose();
                //_DatosGrupoMenu.Dispose();
           } 

        }
            this.disposedValue = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
