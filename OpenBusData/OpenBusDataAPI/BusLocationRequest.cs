using HttpWebAPICore;

namespace OpenBusDataAPI
{
    public class BusLocationRequest : BaseRequest
    {
        /// <summary>
        /// API key
        /// </summary>
        public virtual string Key { get; set; }

        public string? LineRef { get; set; }

        public LatLngBounds? Bounds { get; set; }

        protected override string BaseUrl => "data.bus-data.dft.gov.uk/api/v1/datafeed/";

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            IList < KeyValuePair<string, string?> > parameters = base.GetQueryStringParameters();
            parameters.Add("api_key", Key);
            parameters.AddNullable("lineRef", LineRef);
            if(Bounds != null)
            {
                string latlngboundStr = $"{Bounds.Value.SouthWest.Lng},{Bounds.Value.SouthWest.Lat},{Bounds.Value.NorthEast.Lng},{Bounds.Value.NorthEast.Lat}";
                parameters.Add("boundingBox", latlngboundStr);
            }
            return parameters;
        }
    }
}
