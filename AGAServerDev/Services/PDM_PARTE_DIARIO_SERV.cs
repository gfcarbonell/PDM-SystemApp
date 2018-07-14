using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
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

        public ICollection<PDM_PARTE_DIARIO> Get()
        {
            throw new NotImplementedException();
        }
        
        public PDM_PARTE_DIARIO GetParteById(int IdParte)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdParteDiarioParameter = new SqlParameter();

                        IdParteDiarioParameter.ParameterName = "@IdParte";
                        IdParteDiarioParameter.Direction = ParameterDirection.Input;
                        IdParteDiarioParameter.SqlDbType = SqlDbType.SmallInt;
                        IdParteDiarioParameter.Value = IdParte;

                        var parteDiario = db.Database.SqlQuery<PDM_PARTE_DIARIO>("dbo.[PR_PDM_PARTE_SEL] @IdParte",
                            IdParteDiarioParameter).FirstOrDefault();

                        ctxTrans.Commit(); // OK
                        return parteDiario;
                    }
                    catch (NullReferenceException ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }

                    catch (SqlException ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }

                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        public ICollection<PDM_PARTE_EXT> Get(DateTime Fecha, int IdUsuario, string IdSucursal)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var FechaParameter = new SqlParameter();
                        var IdUsuarioParameter = new SqlParameter();
                        var IdSucursalParameter = new SqlParameter();

                        FechaParameter.ParameterName = "@Fecha";
                        FechaParameter.Direction = ParameterDirection.Input;
                        FechaParameter.SqlDbType = SqlDbType.Date;
                        FechaParameter.Value = Fecha;

                        IdUsuarioParameter.ParameterName = "@IdUsuario";
                        IdUsuarioParameter.Direction = ParameterDirection.Input;
                        IdUsuarioParameter.SqlDbType = SqlDbType.SmallInt;
                        IdUsuarioParameter.Value = IdUsuario;

                        IdSucursalParameter.ParameterName = "@IdSucursal";
                        IdSucursalParameter.Direction = ParameterDirection.Input;
                        IdSucursalParameter.SqlDbType = SqlDbType.VarChar;
                        IdSucursalParameter.Value = IdSucursal;

                        var parteDiarios = db.Database.SqlQuery<PDM_PARTE_EXT>("dbo.[PR_PDM_PARTE_QRY_Diario] @Fecha", 
                            FechaParameter)
                            .Select(t => new PDM_PARTE_EXT
                            {
                                IdParte = t.IdParte,
                                Fecha = t.Fecha,
                                IdSucursal = t.IdSucursal,
                                IdImplemento = t.IdImplemento,
                                IdTipoImplemento = t.IdTipoImplemento,
                                IdMaquinaria = t.IdMaquinaria,
                                IdOperario = t.IdOperario, 
                                IdEstado = t.IdEstado,
                                IdTurno = t.IdTurno
                            }).ToList();

                        ctxTrans.Commit(); // OK
                        return parteDiarios;
                    }
                    catch (NullReferenceException ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }

                    catch (SqlException ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }

                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }
        public void Save(PDM_PARTE_DIARIO entidad)
        {
            throw new NotImplementedException();
        }

        public PDM_PARTE_DIARIO SaveOK(PDM_PARTE_DIARIO entidad)
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
                        var IdTurnoParameter = new SqlParameter();
                        var TablaCheckListParameter = new SqlParameter();
                        var TablaObservacionParameter = new SqlParameter();
                        var UsuarioParameter = new SqlParameter();

                        IdSucursalParameter.ParameterName = "@IdSucursal";
                        IdSucursalParameter.Direction = ParameterDirection.Input;
                        IdSucursalParameter.SqlDbType = SqlDbType.VarChar;
                        IdSucursalParameter.Value = entidad.IdSucursal;

                        IdMaquinariaParameter.ParameterName = "@IdMaquinaria";
                        IdMaquinariaParameter.Direction = ParameterDirection.Input;
                        IdMaquinariaParameter.SqlDbType = SqlDbType.VarChar;
                        IdMaquinariaParameter.Value = entidad.IdMaquinaria;

                        IdImplementoParameter.ParameterName = "@IdImplemento";
                        IdImplementoParameter.Direction = ParameterDirection.Input;
                        IdImplementoParameter.SqlDbType = SqlDbType.VarChar;
                        IdImplementoParameter.Value = entidad.IdImplemento;

                        IdTipoImplementoParameter.ParameterName = "@IdTipoImplemento";
                        IdTipoImplementoParameter.Direction = ParameterDirection.Input;
                        IdTipoImplementoParameter.SqlDbType = SqlDbType.VarChar;
                        IdTipoImplementoParameter.Value = entidad.IdTipoImplemento;

                        IdOperarioParameter.ParameterName = "@IdOperario";
                        IdOperarioParameter.Direction = ParameterDirection.Input;
                        IdOperarioParameter.SqlDbType = SqlDbType.VarChar;
                        IdOperarioParameter.Value = entidad.IdOperario;

                        IdTurnoParameter.ParameterName = "@IdTurno";
                        IdTurnoParameter.Direction = ParameterDirection.Input;
                        IdTurnoParameter.SqlDbType = SqlDbType.VarChar;
                        IdTurnoParameter.Value = entidad.IdTurno;

                        //DataTable 
                        DataTable checkList = new DataTable();
                        //checkList.Columns.Add(new DataColumn("IdSistema", typeof(string)));
                        checkList.Columns.Add(new DataColumn("IdComponente", typeof(string)));
                        //checkList.Columns.Add(new DataColumn("Estado", typeof(Decimal)));
                        checkList.Columns.Add(new DataColumn("Situacion", typeof(Decimal)));

                        foreach (var item in entidad.PDM_CHECKLIST)
                        {
                            DataRow row = checkList.NewRow();
                            row["IdComponente"] = item.IdComponente;
                            row["Situacion"] = item.Situacion;
                            checkList.Rows.Add(row);
                        }

                        TablaCheckListParameter.ParameterName = "@TablaCheckList";
                        TablaCheckListParameter.Direction = ParameterDirection.Input;
                        TablaCheckListParameter.SqlDbType = SqlDbType.Structured;
                        TablaCheckListParameter.Value = checkList;
                        TablaCheckListParameter.TypeName = "TY_CHECKLIST_COMPONENTE";

                        //DataTable 
                        DataTable tabaObservation = new DataTable();
                        tabaObservation.Columns.Add(new DataColumn("IdSistema", typeof(string)));
                        tabaObservation.Columns.Add(new DataColumn("IdObservacion", typeof(int)));
                        tabaObservation.Columns.Add(new DataColumn("Observacion", typeof(string)));
                        tabaObservation.Columns.Add(new DataColumn("IdAccion", typeof(string)));

                        foreach (var item in entidad.PDM_OBSERVACION)
                        {
                            DataRow row = tabaObservation.NewRow();
                            row["IdSistema"] = item.IdSistema;
                            row["IdObservacion"] = item.IdObservacion;
                            row["Observacion"] = item.Observacion;
                            row["IdAccion"] = item.IdAccion;
                            tabaObservation.Rows.Add(row);
                        }

                        TablaObservacionParameter.ParameterName = "@TablaObservacion";
                        TablaObservacionParameter.Direction = ParameterDirection.Input;
                        TablaObservacionParameter.SqlDbType = SqlDbType.Structured;
                        TablaObservacionParameter.Value = tabaObservation;
                        TablaObservacionParameter.TypeName = "TY_OBSERVACION";

                        UsuarioParameter.ParameterName = "@IdUsuario";
                        UsuarioParameter.Direction = ParameterDirection.Input;
                        UsuarioParameter.SqlDbType = SqlDbType.SmallInt;
                        UsuarioParameter.Value = entidad.IdUsuario;

                        var x = db.Database.SqlQuery<PDM_PARTE_DIARIO>("dbo.[PR_PDM_PARTE_INS] " +
                            "@IdSucursal, @IdMaquinaria, @IdImplemento, @IdTipoImplemento, @IdOperario, @IdTurno, @TablaCheckList, @TablaObservacion, @IdUsuario",
                            IdSucursalParameter, IdMaquinariaParameter, IdImplementoParameter,
                            @IdTipoImplementoParameter, IdOperarioParameter, IdTurnoParameter, TablaCheckListParameter, TablaObservacionParameter, UsuarioParameter
                            ).FirstOrDefault();
                        
                        ctxTrans.Commit(); // OK
                        return x;
                    }
                    catch (NullReferenceException ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                    
                    catch (SqlException ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }

                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }
        public void Update(PDM_PARTE_DIARIO entidad)
        {
            throw new NotImplementedException();
        }
        public PDM_PARTE_DIARIO UpdateOk(PDM_PARTE_DIARIO entidad)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdParteParameter = new SqlParameter();
                        var IdSucursalParameter = new SqlParameter();
                        var IdMaquinariaParameter = new SqlParameter();
                        var IdImplementoParameter = new SqlParameter();
                        var IdTipoImplementoParameter = new SqlParameter();
                        var IdOperarioParameter = new SqlParameter();
                        var IdTurnoParameter = new SqlParameter();
                        var TablaCheckListParameter = new SqlParameter();
                        var TablaObservacionParameter = new SqlParameter();
                        var UsuarioParameter = new SqlParameter();

                        IdParteParameter.ParameterName = "@IdParte";
                        IdParteParameter.Direction = ParameterDirection.Input;
                        IdParteParameter.SqlDbType = SqlDbType.VarChar;
                        IdParteParameter.Value = entidad.IdSucursal;

                        IdSucursalParameter.ParameterName = "@IdSucursal";
                        IdSucursalParameter.Direction = ParameterDirection.Input;
                        IdSucursalParameter.SqlDbType = SqlDbType.VarChar;
                        IdSucursalParameter.Value = entidad.IdSucursal;

                        IdMaquinariaParameter.ParameterName = "@IdMaquinaria";
                        IdMaquinariaParameter.Direction = ParameterDirection.Input;
                        IdMaquinariaParameter.SqlDbType = SqlDbType.VarChar;
                        IdMaquinariaParameter.Value = entidad.IdMaquinaria;

                        IdImplementoParameter.ParameterName = "@IdImplemento";
                        IdImplementoParameter.Direction = ParameterDirection.Input;
                        IdImplementoParameter.SqlDbType = SqlDbType.VarChar;
                        IdImplementoParameter.Value = entidad.IdImplemento;

                        IdTipoImplementoParameter.ParameterName = "@IdTipoImplemento";
                        IdTipoImplementoParameter.Direction = ParameterDirection.Input;
                        IdTipoImplementoParameter.SqlDbType = SqlDbType.VarChar;
                        IdTipoImplementoParameter.Value = entidad.IdTipoImplemento;

                        IdOperarioParameter.ParameterName = "@IdOperario";
                        IdOperarioParameter.Direction = ParameterDirection.Input;
                        IdOperarioParameter.SqlDbType = SqlDbType.VarChar;
                        IdOperarioParameter.Value = entidad.IdOperario;

                        IdTurnoParameter.ParameterName = "@IdTurno";
                        IdTurnoParameter.Direction = ParameterDirection.Input;
                        IdTurnoParameter.SqlDbType = SqlDbType.VarChar;
                        IdTurnoParameter.Value = entidad.IdTurno;

                        //DataTable 
                        DataTable checkList = new DataTable();
                        //checkList.Columns.Add(new DataColumn("IdSistema", typeof(string)));
                        checkList.Columns.Add(new DataColumn("IdComponente", typeof(string)));
                        //checkList.Columns.Add(new DataColumn("Estado", typeof(Decimal)));
                        checkList.Columns.Add(new DataColumn("Situacion", typeof(Decimal)));

                        foreach (var item in entidad.PDM_CHECKLIST)
                        {
                            DataRow row = checkList.NewRow();
                            row["IdComponente"] = item.IdComponente;
                            row["Situacion"] = item.Situacion;
                            checkList.Rows.Add(row);
                        }

                        TablaCheckListParameter.ParameterName = "@TablaCheckList";
                        TablaCheckListParameter.Direction = ParameterDirection.Input;
                        TablaCheckListParameter.SqlDbType = SqlDbType.Structured;
                        TablaCheckListParameter.Value = checkList;
                        TablaCheckListParameter.TypeName = "TY_CHECKLIST_COMPONENTE";

                        //DataTable 
                        DataTable tabaObservation = new DataTable();
                        tabaObservation.Columns.Add(new DataColumn("IdSistema", typeof(string)));
                        tabaObservation.Columns.Add(new DataColumn("IdObservacion", typeof(int)));
                        tabaObservation.Columns.Add(new DataColumn("Observacion", typeof(string)));
                        tabaObservation.Columns.Add(new DataColumn("IdAccion", typeof(string)));

                        foreach (var item in entidad.PDM_OBSERVACION)
                        {
                            DataRow row = tabaObservation.NewRow();
                            row["IdSistema"] = item.IdSistema;
                            row["IdObservacion"] = item.IdObservacion;
                            row["Observacion"] = item.Observacion;
                            row["IdAccion"] = item.IdAccion;
                            tabaObservation.Rows.Add(row);
                        }

                        TablaObservacionParameter.ParameterName = "@TablaObservacion";
                        TablaObservacionParameter.Direction = ParameterDirection.Input;
                        TablaObservacionParameter.SqlDbType = SqlDbType.Structured;
                        TablaObservacionParameter.Value = tabaObservation;
                        TablaObservacionParameter.TypeName = "TY_OBSERVACION";

                        UsuarioParameter.ParameterName = "@IdUsuario";
                        UsuarioParameter.Direction = ParameterDirection.Input;
                        UsuarioParameter.SqlDbType = SqlDbType.SmallInt;
                        UsuarioParameter.Value = entidad.IdUsuario;

                        var obj = db.Database.SqlQuery<PDM_PARTE_DIARIO>("dbo.[PR_PDM_PARTE_UPD] " +
                            "@IdParte, @IdSucursal, @IdMaquinaria, @IdImplemento, @IdTipoImplemento, @IdOperario, @IdTurno, @TablaCheckList, @TablaObservacion, @IdUsuario",
                            IdParteParameter, IdSucursalParameter, IdMaquinariaParameter, IdImplementoParameter,
                            @IdTipoImplementoParameter, IdOperarioParameter, IdTurnoParameter, TablaCheckListParameter, TablaObservacionParameter, UsuarioParameter
                            ).FirstOrDefault();

                        ctxTrans.Commit(); // OK
                        return obj;
                    }
                    catch (NullReferenceException ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }

                    catch (SqlException ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }

                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
                    }
                }
            }
        }

        void IENTIDAD<PDM_PARTE_DIARIO>.Save(PDM_PARTE_DIARIO entidad)
        {
            throw new NotImplementedException();
        }
    }
}