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
    public class PDM_CHECKLIST_SISTEMA_SERV : ICHECKLIST_SISTEMA
    {
        public void Delete(PDM_CHECKLIST_SISTEMA entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PDM_CHECKLIST_SISTEMA> Get(Byte IdParte)
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

                        var CheckListSistemas = db.Database.SqlQuery<PDM_CHECKLIST_SISTEMA>("dbo.[PR_PDM_CHECKLIST_QRY_Parte] @IdParte",
                            IdParteParameter
                            ).ToList();
                        ctxTrans.Commit(); //OK
                        return CheckListSistemas;
                    }
                    catch (Exception ex)
                    {
                        ctxTrans.Rollback(); //ERROR
                        throw ex;
                    }
                }
            }
        }

        public ICollection<PDM_CHECKLIST_SISTEMA> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(PDM_CHECKLIST_SISTEMA entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(PDM_CHECKLIST_SISTEMA entidad)
        {
            throw new NotImplementedException();
        }
    }
}