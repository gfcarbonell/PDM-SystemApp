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
    public class PDM_PARTE_DIARIO_SERV : IPARTE_DIARIO
    {
        public void Delete(PDM_PARTE_DIARIO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_PARTE_DIARIO> 
            Get(string IdSucursal, 
                string IdMaquinaria, 
                string IdImplemento, 
                string IdTipoImplemento, 
                string IdOperario,
                PDM_CHECKLIST [] TablaCheckList,
                PDM_OBSERVACION [] TablaObservacion
                )
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdSucursalParameter = new SqlParameter();
                        var IdMaquinariaParameter = new SqlParameter();
                        var IdImplementoParameter = new SqlParameter();
                        var IdTipoImplementoParameter = new SqlParameter();
                        var IdOperarioParameter = new SqlParameter();
                        var TablaCheckListParameter = new SqlParameter();
                        var TablaObservacionParameter = new SqlParameter(); 

                        IdSucursalParameter.ParameterName = "@IdSucursal";
                        IdSucursalParameter.Direction = ParameterDirection.Input;
                        IdSucursalParameter.SqlDbType = SqlDbType.VarChar;
                        IdSucursalParameter.Value = IdSucursal;

                        IdMaquinariaParameter.ParameterName = "@IdMaquinaria";
                        IdMaquinariaParameter.Direction = ParameterDirection.Input;
                        IdMaquinariaParameter.SqlDbType = SqlDbType.VarChar;
                        IdMaquinariaParameter.Value = IdMaquinaria;

                        IdImplementoParameter.ParameterName = "@IdImplemento";
                        IdImplementoParameter.Direction = ParameterDirection.Input;
                        IdImplementoParameter.SqlDbType = SqlDbType.VarChar;
                        IdImplementoParameter.Value = IdImplemento;

                        IdTipoImplementoParameter.ParameterName = "@IdTipoImplemento";
                        IdTipoImplementoParameter.Direction = ParameterDirection.Input;
                        IdTipoImplementoParameter.SqlDbType = SqlDbType.VarChar;
                        IdTipoImplementoParameter.Value = IdTipoImplemento;

                        IdOperarioParameter.ParameterName = "@IdOperario";
                        IdOperarioParameter.Direction = ParameterDirection.Input;
                        IdOperarioParameter.SqlDbType = SqlDbType.VarChar;
                        IdOperarioParameter.Value = IdOperario;

                        TablaCheckListParameter.ParameterName = "@TablaCheckList";
                        TablaCheckListParameter.Direction = ParameterDirection.Input;
                        TablaCheckListParameter.SqlDbType = SqlDbType.Structured;
                        TablaCheckListParameter.Value = TablaCheckList;

                        TablaObservacionParameter.ParameterName = "@TablaObservacion";
                        TablaObservacionParameter.Direction = ParameterDirection.Input;
                        TablaObservacionParameter.SqlDbType = SqlDbType.Structured;
                        TablaObservacionParameter.Value = TablaObservacion;


                        var partes = db.Database.SqlQuery<PDM_PARTE_DIARIO>
                            ("[dbo].[PR_PDM_IMPLEMENTO_QRY] @IdSucursal, @Estado",
                                IdSucursalParameter,
                                IdMaquinariaParameter,
                                IdImplementoParameter,
                                IdTipoImplementoParameter,
                                IdOperarioParameter,
                                TablaCheckListParameter,
                                TablaObservacionParameter
                            ).ToList();

                        ctxTrans.Commit(); // Aprobado
                        return partes;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }

            }
        }

        public ICollection<PDM_PARTE_DIARIO> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(PDM_PARTE_DIARIO entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_PARTE_DIARIO entidad)
        {
            throw new NotImplementedException();
        }
    }
}