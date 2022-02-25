using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Repository
{
    class SupplierRepo
    {
        Fairtech_DataEntities context = new Fairtech_DataEntities();
        
        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = context.Suppliers.ToList();
            return suppliers;
        }
        public Supplier GetSupplier(string code)
        {
            Supplier supplier = context.Suppliers.Where(c => c.Sid == code).FirstOrDefault();
            return supplier;
        }

        public Result Create(Supplier supplier)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                   // var model = new Supplier();
                    int maxPid = Convert.ToInt32(context.Suppliers.Max(c => c.Sid));
                    maxPid += 1;
                    string pid = maxPid.ToString().PadLeft(4, '0');

                    supplier.Sid = pid;
                    //model.Sname = supplier.Sname;
                    //model.Staxid = supplier.Staxid;
                    //model.Sbranch = supplier.Sbranch;
                    //model.Sphone = supplier.Sphone;
                    //model.Semail = supplier.Semail;
                    //model.Saddress = supplier.Saddress;

                    context.Suppliers.Add(supplier);
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

        public Result Update(Supplier model, string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    Supplier supplier = context.Suppliers.Find(code);

                    supplier.Sname = model.Sname;
                    supplier.Staxid = model.Staxid;
                    supplier.Sbranch = model.Sbranch;
                    supplier.Sphone = model.Sphone;
                    supplier.Semail = model.Semail;
                    supplier.Saddress = model.Saddress;

                    context.Entry(supplier).State = System.Data.Entity.EntityState.Modified;

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
                    Supplier supplier = context.Suppliers.Find(code);

                    context.Suppliers.Remove(supplier);

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
