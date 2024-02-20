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
