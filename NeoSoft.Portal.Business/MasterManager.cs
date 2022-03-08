using HDFC.Core.Logging;
using NeoSoft.Portal.Data.Interface;
using NeoSoft.Portal.Model;
using System;
using System.Collections.Generic;

namespace NeoSoft.Portal.Business
{
    public class MasterManager
    {
        private readonly IMasterRepository _masterRepository;
        public MasterManager(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        #region Location
        public SuccessModel<object> GetCountryList()
        {
            NLogManager.Info("MasterManager - GetCountryList started");
            return _masterRepository.GetCountryList();
        }

        public SuccessModel<object> GetStateList(int row_Id)
        {
            NLogManager.Info("MasterManager - GetCountryList started");
            return _masterRepository.GetStateList(row_Id);
        }

        public SuccessModel<object> GetCityList(int row_Id)
        {
            NLogManager.Info("MasterManager - GetCountryList started");
            return _masterRepository.GetCityList(row_Id);
        }
        #endregion

    }
}
 
