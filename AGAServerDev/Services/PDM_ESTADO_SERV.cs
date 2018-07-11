using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AGAServerDev.Contexts;

namespace AGAServerDev.Services
{
    public class PDM_ESTADO_SERV : IESTADO
    {
        public void Delete(PDM_ESTADO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_ESTADO> Get()
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var estados = db.Database.SqlQuery<PDM_ESTADO>("dbo.[PR_PDM_ESTADO_QRY]").ToList();
                        ctxTrans.Commit(); // OK
                        return estados;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_ESTADO entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_ESTADO entidad)
        {
            throw new NotImplementedException();
        }
    }
}