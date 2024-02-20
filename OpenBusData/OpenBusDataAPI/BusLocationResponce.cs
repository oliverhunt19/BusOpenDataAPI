using HttpWebAPICore;
using HttpWebAPICore.Interfaces;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace OpenBusDataAPI
{
    public  class BusLocationResponce : SIRI_VM ,IResponse<BusLocationRequest>
    {
        [XmlIgnore]
        /// <inheritdoc />
        public virtual string RawJson { get; set; }

        [XmlIgnore]
        /// <inheritdoc />
        public virtual Uri? RequestUri { get; set; }

        [XmlIgnore]
        /// <inheritdoc />
        public virtual Status Status { get; set; }

        [XmlIgnore]
        /// <inheritdoc />
        [JsonPropertyName("error_message")]
        public virtual string ErrorMessage { get; set; }

        [XmlIgnore]
        public BusLocationRequest Request { get; set; }

        public virtual Task PostProcess()
        {
            return Task.CompletedTask;
            // Does nothing by default
        }
    }
}
