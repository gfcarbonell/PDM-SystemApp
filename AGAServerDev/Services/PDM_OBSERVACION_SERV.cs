using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AGAServerDev.Contexts;
using AGAServerDev.Models;

namespace AGAServerDev.Services
{
    public class PDM_OBSERVACION_SERV : IOBSERVACION
    {
        public void Delete(PDM_OBSERVACION_EXT entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }
        public ICollection<PDM_OBSERVACION_EXT> Get()
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_OBSERVACION_EXT> Get(int IdParte)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdParteParameter = new SqlParameter();

                        IdParteParameter.ParameterName = "@IdParte";
                        IdParteParameter.Direction = ParameterDirection.Input;
                        IdParteParameter.SqlDbType = SqlDbType.Int;
                        IdParteParameter.Value = IdParte;

                        var observaciones = db.Database.SqlQuery<PDM_OBSERVACION_EXT>("dbo.[PR_PDM_OBSERVACION_QRY_NroParte] @IdParte",
                            IdParteParameter
                            ).ToList();
                        ctxTrans.Commit(); // OK
                        return observaciones;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_OBSERVACION_EXT entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_OBSERVACION_EXT entidad)
        {
            throw new NotImplementedException();
        }
    }
}