using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Application.TourAndTravel.Web.Models;

namespace Application.TourAndTravel.Models
{
    public class RechargeRepositories
    {
        private readonly DBAccessVM _dbAccessVM;
        public RechargeRepositories()
        {
            _dbAccessVM = new DBAccessVM();
        }
        public int RechargeInfiSave(RechargeInfo rechargeInfo)
        {
            int i = 0;
            rechargeInfo.CreatedDate = DateTime.Now;
            rechargeInfo.ModifiedDate = DateTime.Now;
            _dbAccessVM.Recharge.Add(rechargeInfo);
            if (_dbAccessVM.SaveChanges() > 0)
            {
                i = 0;
                return i;
            }
            else {
                return i;
            }
        }
        public int DeleteRechargeInfo(int? rechargeID)
        {
            int i = 0;
            var coll = _dbAccessVM.Recharge.Where(a => a.RechargeID == rechargeID).FirstOrDefault();
            if (coll != null)
            {
                coll.IsDelete = true;
                _dbAccessVM.SaveChanges();
                i = 1;
                return i;
            }
            else
            {
                return i;
            }
        }
        public RechargeInfo getRechargeTypeDataById(int? rechargeID)
        {
            RechargeInfo data = new TourAndTravel.RechargeInfo();
            if (rechargeID != null)
            {
                data = _dbAccessVM.Recharge.Where(a => a.RechargeID == rechargeID).FirstOrDefault();

                return data;
            }
            else
            { return data; }
        }

        public int UpdateRechargeInfo(RechargeInfo model)
        {
            int i = 0;
            RechargeInfo data = null;
            if (model != null)
            {
                data = _dbAccessVM.Recharge.Where(a => a.RechargeID == model.RechargeID).FirstOrDefault();
                data.TravellerID = model.TravellerID;
                data.TravelAgentName = model.TravelAgentName;
                data.TravelAgentEmail = model.TravelAgentEmail;
                data.WalletBalance = model.WalletBalance;
                data.CreatedDate = DateTime.Now;               
                data.ModifiedDate = DateTime.Now;
                data.ModifiedBy = "";
                if (_dbAccessVM.SaveChanges() > 0)
                {
                    i = 1;
                    return i;
                }
                return i;
            }
            else
            { return i; }
        }
    }
}