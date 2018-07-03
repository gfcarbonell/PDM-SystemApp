using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGAServerDev.Contexts;

namespace AGAServerDev.Services
{
    public class PDM_SISTEMA_SERV : ISISTEMA
    {
        public void Delete(PDM_SISTEMA entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_SISTEMA> Get()
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var Turnos = db.Database.SqlQuery<PDM_SISTEMA>("dbo.[PR_PDM_SISTEMA_QRY]")
                        .OrderBy(t => t.Descripcion)
                        .Select(t => new PDM_SISTEMA
                        {
                            IdSistema = t.IdSistema,
                            Descripcion = t.Descripcion, 
                            IdTipoImplemento = t.IdTipoImplemento
                        }).ToList();
                        ctxTrans.Commit(); // OK
                        return Turnos;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_SISTEMA entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_SISTEMA entidad)
        {
            throw new NotImplementedException();
        }
    }
}