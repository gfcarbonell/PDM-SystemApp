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
    public class PDM_CONSUMIDOR_SERV : ICONSUMIDOR
    {
        public void Delete(PDM_CONSUMIDOR entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_CONSUMIDOR> Get()
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_CONSUMIDOR> Get(string IdSucursal)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdSucursalParameter = new SqlParameter();
                        var EstadoParameter = new SqlParameter();

                        IdSucursalParameter.ParameterName = "@IdSucursal";
                        IdSucursalParameter.Direction = ParameterDirection.Input;
                        IdSucursalParameter.SqlDbType = SqlDbType.VarChar;
                        IdSucursalParameter.Value = IdSucursal;

                        var consumidores = db.Database.SqlQuery<PDM_CONSUMIDOR>("[dbo].[PR_PDM_CONSUMIDOR_QRY_Sucursal] @IdSucursal",
                            IdSucursalParameter
                        ).ToList();

                        ctxTrans.Commit(); // Aprobado
                        return consumidores;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }

            }
        }

        public void Save(PDM_CONSUMIDOR entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_CONSUMIDOR entidad)
        {
            throw new NotImplementedException();
        }
    }
}