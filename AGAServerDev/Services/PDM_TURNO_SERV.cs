using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGAServerDev.Contexts;
using AGAServerDev.Models;

namespace AGAServerDev.Services
{
    public class PDM_TURNO_SERV : ITURNO
    {
        public void Delete(PDM_TURNO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_TURNO> Get()
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                         var Turnos = db.Database.SqlQuery<PDM_TURNO>("dbo.[PR_PDM_TURNO_QRY]")
                        .OrderBy(t => t.Descripcion)
                        .Select(t => new PDM_TURNO
                        {
                            IdTurno = t.IdTurno,
                            Descripcion = t.Descripcion
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

        public void Save(PDM_TURNO entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_TURNO entidad)
        {
            throw new NotImplementedException();
        }
    }
}