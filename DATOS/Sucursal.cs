using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class Sucursal
    {
        #region "Atributos"
        private HelperSQL _SQL;
        #endregion

        #region "Constructores"
        public Sucursal() { _SQL = new HelperSQL(); }
        public Sucursal(HelperSQL sql) { _SQL = sql; }
        #endregion


        #region "Funciones"

        public MODELO.Sucursal BuscarPorId(int id, out string po_log)
        {
            string procedure = "spSUC_BuscarPorId";
            object[] paramName = { "@Id" };
            object[] paramValue = { id };
            MODELO.Sucursal sucursal = null;
            po_log = string.Empty;

            try
            {
                using (DataTable resultado = _SQL.EjecutaConsultaConParametros(procedure, paramName, paramValue, out po_log))
                {
                    if (resultado.Rows.Count > 0)
                    {
                        sucursal = new MODELO.Sucursal(resultado.Rows[0]);
                    }
                }
            }
            catch (Exception e)
            {
                po_log = e.Message;
            }

            return sucursal;
        }

        public List<MODELO.Sucursal> ListarPorBanco(MODELO.Banco banco, out string po_log)
        {
            string procedure = "spSUC_ListarPorBanco";
            po_log = string.Empty;

            try
            {
                using (DataTable resultado = _SQL.EjecutaConsultaSinParametros(procedure, out po_log))
                {
                    if (resultado.Rows.Count > 0)
                    {
                        List<MODELO.Sucursal> lista = new List<MODELO.Sucursal>();
                        foreach (DataRow row in resultado.Rows)
                        {
                            lista.Add(new MODELO.Sucursal(row));
                        }
                        return lista;
                    }
                }
            }
            catch (Exception e)
            {
                po_log = e.Message;
            }

            return new List<MODELO.Sucursal>();
        }

        public bool Insertar(MODELO.Sucursal sucursal, out string po_log)
        {
            string comando = "spSUC_Insertar";
            object[] paramName = { "@Id", "@Nombre", "@Direccion", "@FechaReg" };
            object[] paramValue = { sucursal.Id, sucursal.Nombre, sucursal.Direccion, sucursal.FechaReg };
            po_log = string.Empty;

            try
            {
                return _SQL.EjecutaComandoConParametros(comando, paramName, paramValue, out po_log) > 0;
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
