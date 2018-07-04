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
    public class PDM_IMPLEMENTO_SERV : IIMPLEMENTO
    {
        public void Delete(PDM_IMPLEMENTO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_IMPLEMENTO> Get(string IdSucursal, Decimal Estado)
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
                        string _IdSucursal = (IdSucursal == null) ? "002" : IdSucursal;
                        IdSucursalParameter.Value = _IdSucursal;

                        EstadoParameter.ParameterName = "@Estado";
                        EstadoParameter.Direction = ParameterDirection.Input;
                        EstadoParameter.SqlDbType = SqlDbType.TinyInt;
                        EstadoParameter.Value = Estado;

                        if (EstadoParameter.Value == null)
                        {
                            EstadoParameter.Value = 1;
                        }

                        if (IdSucursalParameter.Value == null)
                        {
                            IdSucursalParameter.Value = "000";
                        }

                        var Implementos = db.Database.SqlQuery<PDM_IMPLEMENTO>("[dbo].[PR_PDM_IMPLEMENTO_QRY] @IdSucursal, @Estado",
                            IdSucursalParameter,
                            EstadoParameter
                            ).ToList();

                        ctxTrans.Commit(); // Aprobado
                        return Implementos;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }

            }
        }

        public ICollection<PDM_IMPLEMENTO> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(PDM_IMPLEMENTO entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_IMPLEMENTO entidad)
        {
            throw new NotImplementedException();
        }
    }
}