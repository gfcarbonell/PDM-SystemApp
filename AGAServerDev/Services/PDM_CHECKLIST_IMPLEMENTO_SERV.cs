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
    public class PDM_CHECKLIST_IMPLEMENTO_SERV : ICHECKLIST_IMPLEMENTO
    {
        public void Delete(PDM_CHECKLIST_IMPLEMENTO entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_CHECKLIST_IMPLEMENTO> Get()
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_CHECKLIST_IMPLEMENTO> Get(Byte IdParte, string IdTipoImplemento)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var IdParteParameter = new SqlParameter();
                        var IdTipoImplementoParameter = new SqlParameter();

                        IdParteParameter.ParameterName = "@IdParte";
                        IdParteParameter.Direction = ParameterDirection.Input;
                        IdParteParameter.SqlDbType = SqlDbType.Int;
                        IdParteParameter.Value = IdParte;

                        IdTipoImplementoParameter.ParameterName = "@IdTipoImplemento";
                        IdTipoImplementoParameter.Direction = ParameterDirection.Input;
                        IdTipoImplementoParameter.SqlDbType = SqlDbType.VarChar;
                        IdTipoImplementoParameter.Value = IdTipoImplemento;

                        var CheckListImplementos = db.Database.SqlQuery<PDM_CHECKLIST_IMPLEMENTO>("dbo.[PR_PDM_CHECKLIST_QRY_ParteImplemento] @IdParte, @IdTipoImplemento",
                            IdParteParameter,
                            IdTipoImplementoParameter
                        ).ToList();
                        ctxTrans.Commit(); //OK
                        return CheckListImplementos;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); //ERROR
                        throw ex;
                    }
                }
            }
        }

        public void Save(PDM_CHECKLIST_IMPLEMENTO entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_CHECKLIST_IMPLEMENTO entidad)
        {
            throw new NotImplementedException();
        }
    }
}