using PurchaseSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Repository
{

    class TrackingRepo
    {
        Fairtech_DataEntities context = new Fairtech_DataEntities();

        public List<Tracking> GetTrackings()
        {
             
                List<Tracking> trackings = context.Trackings.ToList();
                return trackings;
           
        }
        //public List<TarckingList> GetTarckingLists()
        //{
        //    //using (var context = new BloggingContext())
        //    using (var context =new Fairtech_DataEntities())
        //    {
        //        List<TarckingList> tarckingLists = context.TarckingLists.ToList();
        //        return tarckingLists;
        //    }
               
        //}

        public List<TrackingPartial> GetTrackingsForAction()
        {
            
                List<TrackingPartial> trackings = context.Trackings.Where(c => c.Tstatus == "Active").Where(c => c.Tin == "-" || c.Tout == "-").OrderByDescending(c => c.Tid).Select(c => new TrackingPartial
                {
                    Tid = c.Tid,
                    Tdate = c.Tdate,
                    Tstatus = c.Tstatus,
                    Tper = c.Tper,
                    Tsid = c.Tsid,
                    Tsname = c.Tsname,
                    Tstaxid = c.Tstaxid,
                    Tsbranth = c.Tsbranth,
                    Tsphone = c.Tsphone,
                    Tsemail = c.Tsemail,
                    Tsaddress = c.Tsaddress,
                    Tsa = c.Tsa,
                    Tzid = c.Tzid,
                    Tzname = c.Tzname,
                    Tbank = c.Tbank,
                    Tbankdate = c.Tbankdate,
                    Ttotail = c.Ttotail,
                    Tvat = c.Tvat,
                    Tvattatoil = c.Tvattatoil,
                    Ttatoill = c.Ttatoill,
                    Tla = c.Tla,
                    Tlb = c.Tlb,
                    Tlc = c.Tlc,
                    Tdetail = c.Tdetail,
                    Tin = c.Tin,
                    Tout = c.Tout,
                    TResult = c.TResult,
                    Tf = c.Tf,
                    Tff = c.Tff,
                    Tdetaillist = c.Tdetaillist,
                    R1 = c.R1,
                    DocDate = c.DocDate,
                    ReceiptDate = c.ReceiptDate,
                    FirstBrand = c.TarckingLists.FirstOrDefault().Ta,
                    FirstProduct = c.TarckingLists.FirstOrDefault().Tb,
                    TarckingLists = c.TarckingLists
                }).ToList();
                return trackings;
             
        }
        public List<TrackingPartial> GetTrackingsAllForAction()
        {
           
                List<TrackingPartial> trackings = context.Trackings.Where(c => c.Tstatus == "Active").OrderByDescending(c=>c.Tid).Select(c => new TrackingPartial
                {
                    Tid = c.Tid,
                    Tdate = c.Tdate,
                    Tstatus = c.Tstatus,
                    Tper = c.Tper,
                    Tsid = c.Tsid,
                    Tsname = c.Tsname,
                    Tstaxid = c.Tstaxid,
                    Tsbranth = c.Tsbranth,
                    Tsphone = c.Tsphone,
                    Tsemail = c.Tsemail,
                    Tsaddress = c.Tsaddress,
                    Tsa = c.Tsa,
                    Tzid = c.Tzid,
                    Tzname = c.Tzname,
                    Tbank = c.Tbank,
                    Tbankdate = c.Tbankdate,
                    Ttotail = c.Ttotail,
                    Tvat = c.Tvat,
                    Tvattatoil = c.Tvattatoil,
                    Ttatoill = c.Ttatoill,
                    Tla = c.Tla,
                    Tlb = c.Tlb,
                    Tlc = c.Tlc,
                    Tdetail = c.Tdetail,
                    Tin = c.Tin,
                    Tout = c.Tout,
                    TResult = c.TResult,
                    Tf = c.Tf,
                    Tff = c.Tff,
                    Tdetaillist = c.Tdetaillist,
                    R1 = c.R1,
                    DocDate = c.DocDate,
                    ReceiptDate = c.ReceiptDate,
                    FirstBrand = c.TarckingLists.FirstOrDefault().Ta,
                    FirstProduct = c.TarckingLists.FirstOrDefault().Tb,
                    TarckingLists = c.TarckingLists
                }).ToList();
                return trackings;
            
        }

        //public List<TrackingPartial> GetTrackingsAll()
        //{
        //    using (var context = new Fairtech_DataEntities())
        //    {
        //        List<TrackingPartial> trackings = context.Trackings.Where(c => c.Tstatus == "Active").OrderByDescending(c => c.Tid).Select(c => new TrackingPartial
        //        {
        //            Tid = c.Tid,
        //            Tdate = c.Tdate,
        //            Tstatus = c.Tstatus,
        //            Tper = c.Tper,
        //            Tsid = c.Tsid,
        //            Tsname = c.Tsname,
        //            Tstaxid = c.Tstaxid,
        //            Tsbranth = c.Tsbranth,
        //            Tsphone = c.Tsphone,
        //            Tsemail = c.Tsemail,
        //            Tsaddress = c.Tsaddress,
        //            Tsa = c.Tsa,
        //            Tzid = c.Tzid,
        //            Tzname = c.Tzname,
        //            Tbank = c.Tbank,
        //            Tbankdate = c.Tbankdate,
        //            Ttotail = c.Ttotail,
        //            Tvat = c.Tvat,
        //            Tvattatoil = c.Tvattatoil,
        //            Ttatoill = c.Ttatoill,
        //            Tla = c.Tla,
        //            Tlb = c.Tlb,
        //            Tlc = c.Tlc,
        //            Tdetail = c.Tdetail,
        //            Tin = c.Tin,
        //            Tout = c.Tout,
        //            TResult = c.TResult,
        //            Tf = c.Tf,
        //            Tff = c.Tff,
        //            Tdetaillist = c.Tdetaillist,
        //            R1 = c.R1,
        //            DocDate = c.DocDate,
        //            ReceiptDate = c.ReceiptDate,
        //            FirstBrand = c.TarckingLists.FirstOrDefault().Ta,
        //            FirstProduct = c.TarckingLists.FirstOrDefault().Tb,
        //            TarckingLists = c.TarckingLists
        //        }).ToList();
        //        return trackings;
        //    }
        //}

        public Tracking GetTrackingByID(string code)
        {
            
                Tracking tracking = context.Trackings.Where(c => c.Tid == code).First();

                return tracking;
          
        }


        public Result Create(Tracking tracking)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                   // var model = new Tracking();

                    string maxPidStr = context.Trackings.Where(c => c.DocDate.Value.Year == DateTime.Now.Year && c.DocDate.Value.Month == DateTime.Now.Month).Max(c => c.Tid);

                    //มีรายการอยู่แล้วหรือเปล่าในเดือนนี้ 
                    if (maxPidStr == null)
                    {
                        //ยังไม่เคยมีรายการ
                        maxPidStr = "PO-" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + "0001";
                    }
                    else
                    {
                        string runningNumber = maxPidStr.Substring(maxPidStr.Length - 4, 4);
                        int maxPid = Convert.ToInt32(runningNumber);

                        maxPid += 1;
                        maxPidStr = "PO-" + DateTime.Now.Year + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + maxPid.ToString().PadLeft(4, '0');
                    }

                    tracking.Tid = maxPidStr;
                    tracking.Tff = GlobalVar.PathFolder + maxPidStr;
                    

                    context.Trackings.Add(tracking);
                    //detail 
                    foreach (var item in tracking.TarckingLists)
                    {
                        item.ID = maxPidStr;
                        context.TarckingLists.Add(item);
                    }

                   
                    context.SaveChanges();
                    trans.Commit();

                    result.Code = maxPidStr;
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

        public Result Update(Tracking model, string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {

                    //detail
                    Fairtech_DataEntities contextItem = new Fairtech_DataEntities();
                    List<TarckingList> list = contextItem.TarckingLists.Where(c => c.ID == code).ToList();
                     
                    foreach (var item in list)
                    {
                        contextItem.TarckingLists.Remove(item);
                        contextItem.SaveChanges();
                    }

                    //head;
                    Tracking tracking = context.Trackings.Find(code);

                    tracking.Tsid = model.Tsid;
                    tracking.Tsname = model.Tsname;
                    tracking.Tstaxid = model.Tstaxid;
                    tracking.Tsbranth = model.Tsbranth;
                    tracking.Tsphone = model.Tsphone;
                    tracking.Tsemail = model.Tsemail;
                    tracking.Tsaddress = model.Tsaddress;
                    tracking.Tsa = model.Tsa;
                    tracking.Tzid = model.Tzid;
                    tracking.Tzname = model.Tzname;
                    tracking.Tbank = model.Tbank;
                    tracking.ReceiptDate = model.ReceiptDate;
                    tracking.Tbankdate = model.Tbankdate;
                    tracking.Ttotail = model.Ttotail;
                    tracking.Tvat = model.Tvat;
                    tracking.Tvattatoil = model.Tvattatoil;
                    tracking.Ttatoill = model.Ttatoill;
                    tracking.Tla = model.Tla;
                    tracking.Tlb = model.Tlb;
                    tracking.Tlc = model.Tlc;
                    tracking.Tdetaillist = model.Tdetaillist;
                    tracking.Tdetail = model.Tdetail;
                    tracking.Tin = model.Tin;
                    tracking.Tout = model.Tout;
                    tracking.Tf = model.Tf;
                    //tracking.Tff = txtPathFile.Text;//รู้ตอนบันทึก
                    tracking.TResult = model.TResult;

                   

                    tracking.TarckingLists = model.TarckingLists;
                    
                    //for (int i = 0; i < dgvList.Rows.Count - 1; i++)
                    //{
                    //    TarckingList tarckingList = new TarckingList();
                    //    tarckingList.Tb = dgvList.Rows[i].Cells["Tb"].Value.ToString();
                    //    tarckingList.Ta = dgvList.Rows[i].Cells["Ta"].Value.ToString() == "" ? "-" : dgvList.Rows[i].Cells["Ta"].Value.ToString();
                    //    tarckingList.Tc = dgvList.Rows[i].Cells["Tc"].Value.ToString();
                    //    tarckingList.Td = dgvList.Rows[i].Cells["Td"].Value.ToString();
                    //    tarckingList.Te = dgvList.Rows[i].Cells["Te"].Value.ToString();
                    //    tarckingList.Tf = dgvList.Rows[i].Cells["Tf"].Value.ToString();

                    //    tracking.TarckingLists.Add(tarckingList);
                    //}

                    context.Entry(tracking).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();
                    trans.Commit();
                    result.Flag = true;
                    return result;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result.Flag = false;
                    return result;
                }
            }
        }

        public Result Delete( string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    Tracking tracking = context.Trackings.Find(code);
                    tracking.Tstatus = "Delete";


                    context.Entry(tracking).State = System.Data.Entity.EntityState.Modified;

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
