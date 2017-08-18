using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO.Interfaces
{
    interface IBanco: IDisposable
    {
        MODELO.Banco BuscarPorId(int id, out string po_log);
        List<MODELO.Banco> ListarTodos(out string po_log);
        bool Insertar(MODELO.Banco banco, out string po_log);

    }
}
