using NEGOCIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MODELO;

namespace NEGOCIO
{
    public class Banco : IBanco
    {

        private DATOS.Banco _dato;

        public Banco() {
            DATOS.HelperSQL sql = new DATOS.HelperSQL();
            _dato = new DATOS.Banco(sql);
        }

        public MODELO.Banco BuscarPorId(int id, out string po_log)
        {
            po_log = string.Empty;
            try {

                return _dato.BuscarPorId(id, out po_log);
            }
            catch (Exception e){
                po_log = e.Message;
            }
            return null;
        }

        public List<MODELO.Banco> ListarTodos(out string po_log)
        {
            po_log = string.Empty;
            try
            {
                return _dato.ListarTodos(out po_log);
            }
            catch (Exception e)
            {
                po_log = e.Message;
            }
            return new List<MODELO.Banco>();
        }

        public bool Insertar(MODELO.Banco banco,out string po_log)
        {
            po_log = string.Empty;
            try
            {
                return _dato.Insertar(banco, out po_log);
            }
            catch (Exception e)
            {
                po_log = e.Message;
            }
            return false;
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                    _dato.Dispose();
                }
                disposedValue = true;
            }
        }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion


    }
}
