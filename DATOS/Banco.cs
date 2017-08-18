using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DATOS
{
    public class Banco : IDisposable
    {

        #region "Atributos"
        private HelperSQL _SQL;
        #endregion

        #region "Constructores"
        public Banco() { _SQL = new HelperSQL(); }
        public Banco(HelperSQL sql) { _SQL = sql; }
        #endregion


        #region "Funciones"

        public MODELO.Banco BuscarPorId(int id, out string po_log)
        {
            string procedure = "spBAN_BuscarPorId";
            object[] paramName = { "@Id" };
            object[] paramValue = { id };
            MODELO.Banco banco = null;
            po_log = string.Empty;

            try
            {
                using (DataTable resultado = _SQL.EjecutaConsultaConParametros(procedure, paramName, paramValue, out po_log))
                {
                    if (resultado.Rows.Count > 0)
                    {
                        banco = new MODELO.Banco(resultado.Rows[0]);
                    }
                }
            }
            catch (Exception e)
            {
                po_log = e.Message;
            }

            return banco;
        }

        public List<MODELO.Banco> ListarTodos(out string po_log)
        {
            string procedure = "spBAN_ListarTodos";
            po_log = string.Empty;

            try
            {
                using (DataTable resultado = _SQL.EjecutaConsultaSinParametros(procedure, out po_log))
                {
                    if (resultado.Rows.Count > 0)
                    {
                        List<MODELO.Banco> lista = new List<MODELO.Banco>();
                        foreach (DataRow row in resultado.Rows)
                        {
                            lista.Add(new MODELO.Banco(row));
                        }
                        return lista;
                    }
                }
            }
            catch (Exception e)
            {
                po_log = e.Message;
            }

            return new List<MODELO.Banco>();
        }

        public bool Insertar(MODELO.Banco banco, out string po_log)
        {
            string comando = "spBAN_Insertar";
            object[] paramName = { "@Id", "@Nombre", "@Direccion", "@FechaReg" };
            object[] paramValue = { banco.Id, banco.Nombre, banco.Direccion, banco.FechaReg};
            po_log = string.Empty;

            try
            {
                return  _SQL.EjecutaComandoConParametros(comando, paramName, paramValue, out po_log) > 0;
            }
            catch (Exception e)
            {
                po_log = e.Message;
            }

            return false;
        }


        #endregion


        #region IDisposable Support
        private bool disposedValue;

        protected void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _SQL.Dispose();
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
