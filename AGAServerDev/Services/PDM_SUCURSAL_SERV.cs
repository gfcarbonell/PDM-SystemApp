using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGAServerDev.Contexts;
using AGAServerDev.Models;

namespace AGAServerDev.Services
{
    public class PDM_SUCURSAL_SERV : ISUCURSAL
    {
        public void Delete(PDM_SUCURSAL entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_SUCURSAL> Get()
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var Sucursales = db.Database.SqlQuery<PDM_SUCURSAL>("dbo.[PR_PDM_SUCURSAL_QRY]").ToList();
                        ctxTrans.Commit(); // OK
                        return Sucursales;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_SUCURSAL entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_SUCURSAL entidad)
        {
            throw new NotImplementedException();
        }
    }
}