using NeoSoft.Portal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NeoSoft.Portal.Data.Interface
{
    public interface IMasterRepository
    {
       

        #region Location
        SuccessModel<object> GetCountryList();
        SuccessModel<object> GetStateList(int countryId);
        SuccessModel<object> GetCityList(int stateId);

        #endregion

    }
}
