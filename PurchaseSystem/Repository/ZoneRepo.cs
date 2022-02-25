using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Repository
{
    class ZoneRepo
    {
        Fairtech_DataEntities context = new Fairtech_DataEntities();
       
        public List<Zone> GetZones()
        {
            List<Zone> zones = context.Zones.ToList();
            return zones;
        }
        public Zone GetZone(string code)
        {
            Zone zone = context.Zones.Where(c => c.Zid == code).FirstOrDefault();
            return zone;
        }


        public Result Create(Zone zone)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    var model = new Zone();
                    int maxPid = Convert.ToInt32(context.Zones.Max(c => c.Zid));
                    maxPid += 1;
                    string pid = maxPid.ToString().PadLeft(4, '0');

                    model.Zid = pid;
                    model.Zname = zone.Zname;
                    model.Zdetail = zone.Zdetail;

                    context.Zones.Add(model);
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

        public Result Update(Zone model, string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    Zone zone = context.Zones.Find(code);

                    zone.Zname = model.Zname;
                    zone.Zdetail = model.Zdetail;

                    context.Entry(zone).State = System.Data.Entity.EntityState.Modified;

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
                    Zone zone = context.Zones.Find(code);

                    context.Zones.Remove(zone);

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
