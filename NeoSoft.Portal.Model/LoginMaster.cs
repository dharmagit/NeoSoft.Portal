using System.Runtime.Serialization;

namespace NeoSoft.Portal.Model
{
   
    public class LoginMaster
    {
        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        /// <value>
        /// The UserName.
        /// </value>
        /// 
        [DataMember]
        public object UserName { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        /// <value>
        /// The Password.
        /// </value>
        /// 
        [DataMember]
        public object Password { get; set; }
    }

    public class LoginResponseModel
    {
        public object Data { get; set; }
        public bool IsExist { get; set; }
    }


}
