using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGAServerDev.Contexts;

namespace AGAServerDev.Services
{
    public class PDM_TIPO_IMPLEMENTO_SERV:ITIPO_IMPLEMENTO
    {
        public void Delete(PDM_TIPO_IMPLEMENTO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_TIPO_IMPLEMENTO> Get()
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var TipoImplementos = db.Database.SqlQuery<PDM_TIPO_IMPLEMENTO>("dbo.[PR_PDM_TIPO_IMPLEMENTO_QRY]")
                        .OrderBy(t => t.Descripcion)
                        .Select(t => new PDM_TIPO_IMPLEMENTO
                        {
                            IdTipoImplemento = t.IdTipoImplemento,
                            Descripcion = t.Descripcion
                        }).ToList();
                        ctxTrans.Commit(); // OK
                        return TipoImplementos;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_TIPO_IMPLEMENTO entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_TIPO_IMPLEMENTO entidad)
        {
            throw new NotImplementedException();
        }

        ICollection<PDM_TIPO_IMPLEMENTO> IENTIDAD<PDM_TIPO_IMPLEMENTO>.Get()
        {
            throw new NotImplementedException();
        }
    }
}