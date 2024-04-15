using HttpWebAPICore.BaseClasses;
using HttpWebAPICore.Utilities;
using RoutePlanning;
using RoutePlanning.Geometry;

namespace OpenBusDataAPI
{
    public class BusLocationRequest : BaseRequest
    {
        public BusLocationRequest(string key)
        {
            Key = key;
        }

        /// <summary>
        /// API key
        /// </summary>
        public virtual string Key { get; set; }

        public string? LineRef { get; set; }

        public LatLngBounds? Bounds { get; set; }

        public IEnumerable<string>? OperatorRef { get; set; }

        public string? OriginRef { get; set; }

        public string? DestinationRef { get; set; }

        public string? VehicleRef { get; set; }

        protected override string BaseUrl => "data.bus-data.dft.gov.uk/api/v1/datafeed/";

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            IList < KeyValuePair<string, string?> > parameters = base.GetQueryStringParameters();
            parameters.Add("api_key", Key);
            parameters.AddNullable("lineRef", LineRef);
            parameters.AddNullable("originRef", OriginRef);
            parameters.AddNullable("destinationRef", DestinationRef);
            parameters.AddNullable("vehicleRef", VehicleRef);

            if(Bounds != null)
            {
                string latlngboundStr = $"{Bounds.Value.SouthWest.Lng},{Bounds.Value.SouthWest.Lat},{Bounds.Value.NorthEast.Lng},{Bounds.Value.NorthEast.Lat}";
                parameters.Add("boundingBox", latlngboundStr);
            }
            if(OperatorRef != null)
            {
                string opRefStr = string.Join(",", OperatorRef);
                parameters.Add("operatorRef", opRefStr);
            }
            return parameters;
        }

        public override HttpRequestMessage GetHttpRequestMessage()
        {
            HttpRequestMessage request = base.GetHttpRequestMessage();
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Headers.Add("Accept-Language", "en-GB,en;q=0.9,en-US;q=0.8");
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            return request;
        }
    }
}
