using System;
using System.Collections.Generic;
using System.Text;

namespace NeoSoft.Portal.Model
{
    public class SuccessModel<T>
    {
        public T Data { get; set; }

        public bool Status { get; set; }
        public string ErrorMessage { get; set; }

    }

    public class LoginSuccessModel<T>
    {
        public T Data { get; set; }
        public T Token { get; set; }
        public string ErrorMessage { get; set; }

    }

    public class SuccessModelNew<T>
    {
        public T Data { get; set; }
        public T Records { get; set; }
        public string ErrorMessage { get; set; }

    }


    public class DataValidationModel<T> : SuccessModel<T>
    {
        public bool IsExist { get; set; }
    }
}
