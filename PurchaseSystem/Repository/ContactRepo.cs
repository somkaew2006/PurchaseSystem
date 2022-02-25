using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Repository
{
    class ContactRepo
    {
        Fairtech_DataEntities context = new Fairtech_DataEntities();

        public List<SupplierA> GetContacts()
        {
            List<SupplierA> contacts = context.SupplierAs.ToList();
            return contacts;
        }
        public List<SupplierA> GetContacts(string code)
        {
            List<SupplierA> contacts = context.SupplierAs.Where(c=>c.ID==code).ToList();
            return contacts;
        }
        public SupplierA GetContact(string code)
        {
            SupplierA contact = context.SupplierAs.Where(c => c.Aid == code).FirstOrDefault();
            return contact;
        }


        public Result Create(SupplierA contact)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    //var model = new SupplierA();
                    int maxPid = Convert.ToInt32(context.SupplierAs.Max(c => c.Aid));
                    maxPid += 1;
                    string pid = maxPid.ToString().PadLeft(4, '0');

                    contact.Aid = pid;
                    //model.Aname = contact.Aname;
                    //model.Aphone = contact.Aphone;
                    //model.Aemail = contact.Aemail;
                    //model.Adetail = contact.Adetail;
                    //model.ID = contact.ID;
                    //model.Name = contact.Name;
                    //model.Aline = contact.Aline;

                    context.SupplierAs.Add(contact);
                    context.SaveChanges();
                    trans.Commit();

                    result.Flag = true;
                    result.Code = pid;
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
        public Result Update(SupplierA model, string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    SupplierA contact = context.SupplierAs.Find(code);

                    contact.Aname = model.Aname;
                    contact.Aphone = model.Aphone;
                    contact.Aemail = model.Aemail;
                    contact.Adetail = model.Adetail;
                    contact.ID = model.ID;
                    contact.Name = model.Name;
                    contact.Aline = model.Aline;

                    context.Entry(contact).State = System.Data.Entity.EntityState.Modified;

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

        public Result Delete(string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    SupplierA contact = context.SupplierAs.Find(code);

                    context.SupplierAs.Remove(contact);

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
