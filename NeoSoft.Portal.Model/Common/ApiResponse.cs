namespace NeoSoft.Portal.Model
{
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public object ResultData { get; set; }

        /// <summary>
        /// Gets or sets Error Log id.
        /// For internal use (Developer)
        /// </summary>
        /// <value>
        /// The Private status message.
        /// </value>
        public int ErrorLogId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the Public status message.
        /// For internal use (Developer)
        /// </summary>
        /// <value>
        /// The Private status message.
        /// </value>
        public string PublicStatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the Private status message.
        /// For internal use (Developer)
        /// </summary>
        /// <value>
        /// The Private status message.
        /// </value>
        public string PrivateStatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the Is Redirect to.
        /// </summary>
        /// <value>
        /// The Is Redirect to.
        /// </value>
        public bool IsRedirect { get; set; }

        /// <summary>
        /// Gets or sets the redirect to.
        /// </summary>
        /// <value>
        /// The redirect to.
        /// </value>
        public string RedirectUrl { get; set; }

        public string DebugInformation { get; set; }

    }
}
