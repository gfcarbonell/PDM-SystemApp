using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGAServerDev.Contexts;
using AGAServerDev.Models;

namespace AGAServerDev.Services
{
    public class PDM_ACTIVIDAD_SERV : IACTIVIDAD
    {
        public void Delete(PDM_ACTIVIDAD entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_ACTIVIDAD> Get()
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var actividades = db.Database.SqlQuery<PDM_ACTIVIDAD>("dbo.[PR_PDM_ACTIVIDAD_QRY]").ToList();
                        ctxTrans.Commit(); // OK
                        return actividades;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_ACTIVIDAD entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_ACTIVIDAD entidad)
        {
            throw new NotImplementedException();
        }
    }
}