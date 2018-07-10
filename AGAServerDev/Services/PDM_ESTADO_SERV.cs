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

        public ICollection<PDM_ESTADO> Get(string IdEstado)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdEstadoParameter = new SqlParameter();

                        IdEstadoParameter.ParameterName = "@Estado";
                        IdEstadoParameter.Direction = ParameterDirection.Input;
                        IdEstadoParameter.SqlDbType = SqlDbType.VarChar;
                        IdEstadoParameter.Value = IdEstado;

                        var operarios = db.Database.SqlQuery<PDM_ESTADO>("dbo.[PR_PDM_OPERADOR_QRY_IdPersonal] @IdEstado",
                            IdEstadoParameter
                        ).ToList();

                        ctxTrans.Commit(); // OK
                        return operarios;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public ICollection<PDM_ESTADO> Get()
        {
            throw new NotImplementedException();
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