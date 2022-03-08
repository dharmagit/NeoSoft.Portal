using HDFC.Core.Common;
using System;
using System.Runtime.Serialization;

namespace NeoSoft.Portal.Model
{
    /// <summary>
    /// This modle will use for list page base class.
    /// </summary>
    public abstract class BaseListModel
    {
        /// <summary>
        /// Gets or sets the Total Records.
        /// </summary>
        /// <value>
        /// The Total Records.
        /// </value>
        [DataMember]
        public int TotalRecords { get; set; }

        /// <summary>
        /// Gets or sets the user Modified By.
        /// </summary>
        /// <value>
        /// The user Tags.
        /// </value>
        [DataMember]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the user Modified Date.
        /// </summary>
        /// <value>
        /// The user Tags.
        /// </value>
        [DataMember]
        public DateTime ModifiedDate { get; set; }

        public string ModifiedOn
        {
            get
            {
                return ModifiedDate.ToString(ConfigHelper.GetAppSettingValue("DateFormat", string.Empty));
            }
        }
    }
}
