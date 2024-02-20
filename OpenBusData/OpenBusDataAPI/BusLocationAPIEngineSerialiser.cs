using HttpWebAPICore;
using System.Xml;
using System.Xml.Serialization;

namespace OpenBusDataAPI
{
    internal class BusLocationAPIEngineSerialiser : HttpEngineSerialiser<BusLocationResponce>
    {
        public override async ValueTask<BusLocationResponce> DeserializeAsync(Stream rawResponce, CancellationToken cancellationToken)
        {
            SIRI_VM result;
            string line = await new StreamReader(rawResponce).ReadToEndAsync().ConfigureAwait(false);
            rawResponce.Seek(0, SeekOrigin.Begin);  
            using(XmlReader xmlReader = new XmlTextReader(rawResponce))
            {
                result = (SIRI_VM) new XmlSerializer(typeof(SIRI_VM)).Deserialize(xmlReader);
            }

            BusLocationResponce busLocationResponce = new BusLocationResponce()
            {
                ServiceDelivery = result.ServiceDelivery,
            };

            return busLocationResponce;
        }
    }
}
