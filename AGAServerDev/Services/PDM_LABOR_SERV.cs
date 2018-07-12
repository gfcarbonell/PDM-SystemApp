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
    public class PDM_LABOR_SERV : ILABOR
    {
        public void Delete(PDM_LABOR entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_LABOR> Get()
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_LABOR> Get(string IdActividad)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdActividadParameter = new SqlParameter();

                        IdActividadParameter.ParameterName = "@IdActividad";
                        IdActividadParameter.Direction = ParameterDirection.Input;
                        IdActividadParameter.SqlDbType = SqlDbType.VarChar;
                        IdActividadParameter.Value = IdActividad;

                        var labores = db.Database.SqlQuery<PDM_LABOR>("dbo.[PR_PDM_LABOR_QRY] @IdActividad",
                            IdActividadParameter
                        ).ToList();

                        ctxTrans.Commit(); // Aprobado
                        return labores;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_LABOR entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_LABOR entidad)
        {
            throw new NotImplementedException();
        }
    }
}