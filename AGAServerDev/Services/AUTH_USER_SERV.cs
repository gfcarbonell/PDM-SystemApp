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
    public class AUTH_USER_SERV : IAUTHUSER
    {
        public void Delete(AUTH_USER entidad)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<AUTH_USER> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(AUTH_USER entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(AUTH_USER entidad)
        {
            throw new NotImplementedException();
        }
       
        public int Permisos(AUTH_USER auth_user)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var UsuarioParameter = new SqlParameter();
                        var ModuleParameter = new SqlParameter();

                        UsuarioParameter.ParameterName = "@CodUsuario";
                        UsuarioParameter.Direction = ParameterDirection.Input;
                        UsuarioParameter.SqlDbType = SqlDbType.SmallInt;
                        UsuarioParameter.Value = auth_user.CodUsuario;

                        ModuleParameter.ParameterName = "@CodModulo";
                        ModuleParameter.Direction = ParameterDirection.Input;
                        ModuleParameter.SqlDbType = SqlDbType.VarChar;
                        ModuleParameter.Value = auth_user. CodModulo;

                        var permiso = db.Database.SqlQuery<Int16>("CLC.dbo.PR_SEG_USUARIO_VAL_Permiso @CodUsuario, @CodModulo",
                            UsuarioParameter,
                            ModuleParameter
                            ).FirstOrDefault();

                        ctxTrans.Commit(); // OK
                        return permiso;
                    }
                    catch (InvalidOperationException ex)
                    {
                        ctxTrans.Rollback(); // ERROR
                        throw ex;
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

        public AUTH_USER Login(AUTH_USER auth_user)
        {
            using (DBContextPDM db = new DBContextPDM())
            {
                using (var ctxTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var UsuarioParameter = new SqlParameter();
                        var PasswordParameter = new SqlParameter();
                        var ModuleParameter = new SqlParameter();

                        UsuarioParameter.ParameterName = "@Usuario";
                        UsuarioParameter.Direction = ParameterDirection.Input;
                        UsuarioParameter.SqlDbType = SqlDbType.VarChar;
                        UsuarioParameter.Value = auth_user.Usuario;

                        PasswordParameter.ParameterName = "@Contrasenia";
                        PasswordParameter.Direction = ParameterDirection.Input;
                        PasswordParameter.SqlDbType = SqlDbType.VarChar;
                        PasswordParameter.Value = auth_user.Contrasenia;

                        ModuleParameter.ParameterName = "@CodModulo";
                        ModuleParameter.Direction = ParameterDirection.Input;
                        ModuleParameter.SqlDbType = SqlDbType.VarChar;
                        ModuleParameter.Value = auth_user.CodModulo;

                        var user = db.Database.SqlQuery<AUTH_USER>("CLC.[dbo].[PR_SEG_USUARIO_VAL_Logueo] @Usuario, @Contrasenia, @CodModulo",
                            UsuarioParameter,
                            PasswordParameter,
                            ModuleParameter
                            ).FirstOrDefault();
                        ctxTrans.Commit(); // OK
                        return user;
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

       
    }
}