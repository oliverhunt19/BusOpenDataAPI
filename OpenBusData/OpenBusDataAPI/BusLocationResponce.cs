using HttpWebAPICore;
using HttpWebAPICore.Interfaces;
using System.Text.Json.Serialization;

namespace OpenBusDataAPI
{
    public  class BusLocationResponce : SIRI_VM ,IResponse<BusLocationRequest>
    {
        /// <inheritdoc />
        public virtual string RawJson { get; set; }

        /// <inheritdoc />
        public virtual Uri? RequestUri { get; set; }

        /// <inheritdoc />
        public virtual Status Status { get; set; }

        /// <inheritdoc />
        [JsonPropertyName("error_message")]
        public virtual string ErrorMessage { get; set; }

        public BusLocationRequest Request { get; set; }

        public virtual void PostProcess()
        {
            // Does nothing by default
        }
    }
}
