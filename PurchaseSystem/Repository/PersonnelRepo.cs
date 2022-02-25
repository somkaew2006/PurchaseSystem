using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Repository
{

    class PersonnelRepo
    {
       // Fairtech_DataEntities context = new Fairtech_DataEntities();
        public Personnel Login(string userName, string password)
        {
            using (var context = new Fairtech_DataEntities())
            {
                Personnel personal = context.Personnels.Where(c => c.Puser == userName && c.Ppass == password).FirstOrDefault();
                return personal;
            }
        }
        public List<Personnel> GetPersonnels()
        {
            using (var context = new Fairtech_DataEntities())
            {
                List<Personnel> personals = context.Personnels.ToList();
                return personals;
            }
        }
        public Personnel GetPersonnel(string code)
        {
            using (var context = new Fairtech_DataEntities())
            {
                Personnel personal = context.Personnels.Where(c => c.Pid == code).FirstOrDefault();
                return personal;
            }
        }


        public Result Create(Personnel personnel)
        {
            using (var context = new Fairtech_DataEntities())
            {
                Result result = new Result();
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        // var model = new Personnel();
                        int maxPid = Convert.ToInt32(context.Personnels.Max(c => c.Pid));
                        maxPid += 1;
                        string pid = maxPid.ToString().PadLeft(4, '0');

                        personnel.Pid = pid;
                        //model.Pname = personnel.Pname;
                        //model.Puser = personnel.Puser;
                        //model.Ppass = personnel.Ppass;

                        context.Personnels.Add(personnel);
                        context.SaveChanges();
                        trans.Commit();

                        result.Flag = true;
                        return result;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        result.Flag = false;
                        result.Message = ex.ToString();
                        return result;
                    }

                }
            }
        }

        public Result Update(Personnel model, string code)
        {
            using (var context = new Fairtech_DataEntities())
            {
                Result result = new Result();
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        Personnel personnel = context.Personnels.Find(code);

                        personnel.Pname = model.Pname;
                        personnel.Puser = model.Puser;
                        personnel.Ppass = model.Ppass;

                        context.Entry(personnel).State = System.Data.Entity.EntityState.Modified;

                        context.SaveChanges();
                        trans.Commit();
                        result.Flag = true;
                        return result;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        result.Flag = false;
                        return result;
                    }
                }
            }
        }
        public Result Delete( string code)
        {
            using (var context = new Fairtech_DataEntities())
            {
                Result result = new Result();
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        Personnel personnel = context.Personnels.Find(code);

                        context.Personnels.Remove(personnel);

                        context.SaveChanges();
                        trans.Commit();
                        result.Flag = true;
                        return result;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        result.Flag = false;
                        return result;
                    }
                }
            }
        }
    }
}
