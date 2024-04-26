using HttpWebAPICore.BaseClasses;

namespace OpenBusDataAPI
{
    public class BusLocationAPI : APIBase<BusLocationRequest,BusLocationResponce>
    {
        public BusLocationAPI() : base(new BusLocationAPIEngineSerialiser())
        {

        }
    }
}
