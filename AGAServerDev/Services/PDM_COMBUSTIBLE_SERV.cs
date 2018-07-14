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
    public class PDM_COMBUSTIBLE_SERV : ICOMBUSTIBLE
    {
        public void Delete(PDM_COMBUSTIBLE entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }
        public ICollection<PDM_COMBUSTIBLE> Get()
        {
            throw new NotImplementedException();
        }
        public ICollection<PDM_COMBUSTIBLE> Get(int IdParte)
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

                        var abastecimiento = db.Database.SqlQuery<PDM_COMBUSTIBLE>("dbo.[PR_PDM_COMBUSTIBLE_QRY_Parte] @IdParte",
                            IdParteParameter
                            ).ToList();

                        ctxTrans.Commit(); // OK
                        return abastecimiento;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_COMBUSTIBLE entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_COMBUSTIBLE entidad)
        {
            throw new NotImplementedException();
        }
    }
}