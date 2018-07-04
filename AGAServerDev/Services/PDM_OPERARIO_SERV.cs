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
    public class PDM_OPERARIO_SERV : IOPERARIO
    {
        public void Delete(PDM_OPERARIO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_OPERARIO> Get(Decimal Estado)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var EstadoParameter = new SqlParameter();

                        EstadoParameter.ParameterName = "@Estado";
                        EstadoParameter.Direction = ParameterDirection.Input;
                        EstadoParameter.SqlDbType = SqlDbType.SmallInt;
                        EstadoParameter.Value = Estado; 

                        var operarios = db.Database.SqlQuery<PDM_OPERARIO>("dbo.[PR_PDM_OPERADOR_QRY_IdPersonal] @Estado",
                            EstadoParameter
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

        public ICollection<PDM_OPERARIO> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(PDM_OPERARIO entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_OPERARIO entidad)
        {
            throw new NotImplementedException();
        }
    }
}