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
    public class PDM_ABASTECIMIENTO_SERV : IABASTECIMIENTO
    {
        public void Delete(PDM_ABASTECIMIENTO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_ABASTECIMIENTO> Get()
        {
            throw new NotImplementedException();
        }

        

        public void Save(PDM_ABASTECIMIENTO entidad)
        {
            throw new NotImplementedException();
        }

        public PDM_ABASTECIMIENTO SaveOK(PDM_ABASTECIMIENTO entidad)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdParteParameter = new SqlParameter();
                        var TablaCombustibleParameter = new SqlParameter();
                        var IdUsuarioParameter = new SqlParameter();

                        IdParteParameter.ParameterName = "@IdParte";
                        IdParteParameter.Direction = ParameterDirection.Input;
                        IdParteParameter.SqlDbType = SqlDbType.Int;
                        IdParteParameter.Value = entidad.IdParte;

                        //DataTable 
                        DataTable abastecimiento = new DataTable();
                        abastecimiento.Columns.Add(new DataColumn("IdCombustible", typeof(int)));
                        abastecimiento.Columns.Add(new DataColumn("Galones", typeof(double)));
                        abastecimiento.Columns.Add(new DataColumn("Horometro", typeof(double)));

                        foreach (var item in entidad.TablaCombustible)
                        {
                            DataRow row = abastecimiento.NewRow();
                            row["IdCombustible"] = item.IdCombustible;
                            row["Galones"] = item.Galones;
                            row["Horometro"] = item.Horometro;
                            abastecimiento.Rows.Add(row);
                        }

                        TablaCombustibleParameter.ParameterName = "@TablaCombustible";
                        TablaCombustibleParameter.Direction = ParameterDirection.Input;
                        TablaCombustibleParameter.SqlDbType = SqlDbType.Structured;
                        TablaCombustibleParameter.Value = abastecimiento;
                        TablaCombustibleParameter.TypeName = "TY_COMBUSTIBLE";

                        IdUsuarioParameter.ParameterName = "@IdUsuario";
                        IdUsuarioParameter.Direction = ParameterDirection.Input;
                        IdUsuarioParameter.SqlDbType = SqlDbType.SmallInt;
                        IdUsuarioParameter.Value = entidad.IdUsuario;

                        var obj = db.Database.SqlQuery<PDM_ABASTECIMIENTO>("dbo.[PR_PDM_COMBUSTIBLE_UPD] @IdParte, @TablaCombustible, @IdUsuario", IdParteParameter, TablaCombustibleParameter, IdUsuarioParameter).FirstOrDefault();
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

        public void Update(PDM_ABASTECIMIENTO entidad)
        {
            throw new NotImplementedException();
        }
    }
}