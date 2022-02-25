using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Repository
{
    class CustomerRepo
    {
        Fairtech_DataEntities context = new Fairtech_DataEntities();

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = context.Customers.ToList();
            return customers;
        }
        public Customer GetCustomer(string code)
        {
            Customer customer = context.Customers.Where(c => c.Cid == code).FirstOrDefault();
            return customer;
        }

        public Result Create(Customer customer)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                   // var model = new Customer();
                    int maxPid = Convert.ToInt32(context.Customers.Max(c => c.Cid));
                    maxPid += 1;
                    string pid = maxPid.ToString().PadLeft(4, '0');

                    customer.Cid = pid;
                    //model.Cname = customer.Cname;
                    //model.Czone = customer.Czone;

                    context.Customers.Add(customer);
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

        public Result Update(Customer model, string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    Customer customer = context.Customers.Find(code);

                    customer.Cname  = model.Cname;
                    customer.Czone = model.Czone;

                    context.Entry(customer).State = System.Data.Entity.EntityState.Modified;

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
                    Customer customer = context.Customers.Find(code);

                    context.Customers.Remove(customer);

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
