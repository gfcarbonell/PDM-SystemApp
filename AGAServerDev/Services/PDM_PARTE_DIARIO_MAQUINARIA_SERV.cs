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
    public class PDM_PARTE_DIARIO_MAQUINARIA_SERV : IPARTE_MAQUINARIA
    {
        public void Delete(PDM_PARTE_MAQUINARIA entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_PARTE_MAQUINARIA> Get(int IdParte)
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
                        var obj = db.Database.SqlQuery<PDM_PARTE_MAQUINARIA>("dbo.[PR_PDM_PARTE_DIARIO_QRY_Parte] @IdParte",
                           IdParteParameter
                       ).ToList();

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

        public ICollection<PDM_PARTE_MAQUINARIA> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(PDM_PARTE_MAQUINARIA entidad)
        {
            throw new NotImplementedException();
        }

        public PDM_PARTE_DIARIO_MAQUINARIA SaveOK(PDM_PARTE_DIARIO_MAQUINARIA entidad)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdParteParameter = new SqlParameter();
                        var TablaDiarioParameter = new SqlParameter();
                        var IdUsuarioParameter = new SqlParameter();

                        IdParteParameter.ParameterName = "@IdParte";
                        IdParteParameter.Direction = ParameterDirection.Input;
                        IdParteParameter.SqlDbType = SqlDbType.Int;
                        IdParteParameter.Value = entidad.IdParte;

                        //DataTable 
                        DataTable pdm = new DataTable();
                        pdm.Columns.Add(new DataColumn("IdParteDiario", typeof(int)));
                        pdm.Columns.Add(new DataColumn("IdConsumidor", typeof(string)));
                        pdm.Columns.Add(new DataColumn("HoraInicio", typeof(DateTime)));
                        pdm.Columns.Add(new DataColumn("HoraFin", typeof(DateTime)));
                        pdm.Columns.Add(new DataColumn("IdActividad", typeof(string)));
                        pdm.Columns.Add(new DataColumn("IdLabor", typeof(string)));
                        pdm.Columns.Add(new DataColumn("HorometroInicio", typeof(double)));
                        pdm.Columns.Add(new DataColumn("HorometroFinal", typeof(double)));

                        foreach (var item in entidad.TablaDiario)
                        {
                            DataRow row = pdm.NewRow();
                            row["IdParteDiario"] = item.IdParte;
                            row["IdConsumidor"] = item.IdConsumidor;
                            row["HoraInicio"] = item.HoraInicio;
                            row["HoraFin"] = item.HoraFin;
                            row["IdActividad"] = item.IdActividad;
                            row["IdLabor"] = item.IdLabor;
                            row["HorometroInicio"] = item.HorometroInicio;
                            row["HorometroFinal"] = item.HorometroFinal;
                            pdm.Rows.Add(row);
                        }

                        TablaDiarioParameter.ParameterName = "@TablaDiario";
                        TablaDiarioParameter.Direction = ParameterDirection.Input;
                        TablaDiarioParameter.SqlDbType = SqlDbType.Structured;
                        TablaDiarioParameter.Value = pdm;
                        TablaDiarioParameter.TypeName = "TY_PARTEDIARIO";

                        IdUsuarioParameter.ParameterName = "@IdUsuario";
                        IdUsuarioParameter.Direction = ParameterDirection.Input;
                        IdUsuarioParameter.SqlDbType = SqlDbType.SmallInt;
                        IdUsuarioParameter.Value = entidad.IdUsuario;

                        var obj = db.Database.SqlQuery<PDM_PARTE_DIARIO_MAQUINARIA>("dbo.[PR_PDM_PARTE_DIARIO_UPD] @IdParte, @TablaDiario, @IdUsuario",
                            IdParteParameter, TablaDiarioParameter, IdUsuarioParameter
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

        public void Update(PDM_PARTE_MAQUINARIA entidad)
        {
            throw new NotImplementedException();
        }
    }
}