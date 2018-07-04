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
    public class PDM_MAQUINARIA_SERV : IMAQUINARIA
    {
        public void Delete(PDM_MAQUINARIA entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_MAQUINARIA> Get(string IdSucursal, Decimal Estado)
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

                        EstadoParameter.ParameterName = "@Estado";
                        EstadoParameter.Direction = ParameterDirection.Input;
                        EstadoParameter.SqlDbType = SqlDbType.TinyInt;
                        EstadoParameter.Value = Estado;

                        if (EstadoParameter.Value == null)
                        {
                            EstadoParameter.Value = 1;
                        }

                        if(IdSucursalParameter.Value == null)
                        {
                            IdSucursalParameter.Value = "000";
                        }

                        var Maquinarias = db.Database.SqlQuery<PDM_MAQUINARIA>("dbo.[PR_PDM_MAQUINARIA_QRY] @IdSucursal, @Estado",
                            IdSucursalParameter,
                            EstadoParameter
                        ).ToList();

                        ctxTrans.Commit(); // Aprobado
                        return Maquinarias;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public ICollection<PDM_MAQUINARIA> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(PDM_MAQUINARIA entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_MAQUINARIA entidad)
        {
            throw new NotImplementedException();
        }
    }
}