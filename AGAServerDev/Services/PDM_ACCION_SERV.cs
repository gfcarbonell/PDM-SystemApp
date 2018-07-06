using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGAServerDev.Contexts;

namespace AGAServerDev.Services
{
    public class PDM_ACCION_SERV : IACCION
    {
        public void Delete(PDM_ACCION entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_ACCION> Get()
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var acciones = db.Database.SqlQuery<PDM_ACCION>("dbo.[PR_PDM_ACCION_QRY]").ToList();
                        ctxTrans.Commit(); // OK
                        return acciones;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_ACCION entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_ACCION entidad)
        {
            throw new NotImplementedException();
        }
    }
}