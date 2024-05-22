using HttpWebAPICore.BaseClasses;

namespace OpenBusDataAPI
{
    public class BusLocationAPI : APIBase<BusLocationRequest,BusLocationResponce>, IBusLocationAPI
    {
        public BusLocationAPI() : base(new BusLocationAPIEngineSerialiser())
        {

        }
    }
}
