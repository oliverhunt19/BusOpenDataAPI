using HttpWebAPICore;
using System.Xml;
using System.Xml.Serialization;

namespace OpenBusDataAPI
{
    internal class BusLocationAPIEngineSerialiser : HttpEngineSerialiser<BusLocationResponce>
    {
        public override ValueTask<BusLocationResponce> DeserializeAsync(Stream rawResponce, CancellationToken cancellationToken)
        {
            BusLocationResponce result;
            using(XmlReader xmlReader = new XmlTextReader(rawResponce))
            {
                result = (BusLocationResponce) new XmlSerializer(typeof(BusLocationResponce)).Deserialize(xmlReader);
            }

            return ValueTask.FromResult(result);
        }
    }
}
