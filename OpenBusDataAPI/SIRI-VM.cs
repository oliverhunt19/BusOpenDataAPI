using RoutePlanning;
using RoutePlanning.Geometry;
using System.Xml.Serialization;

namespace OpenBusDataAPI
{
    [XmlRoot("Siri", Namespace = "http://www.siri.org.uk/siri", IsNullable = false)]
    public class SIRI_VM
    {
        public ServiceDelivery ServiceDelivery { get; set; }
    }

    public class ServiceDelivery
    {
        public DateTime ResponseTimestamp { get; set; }

        public string ProducerRef { get; set; }

        public VehicleMonitoringDelivery VehicleMonitoringDelivery { get; set; }
    }

    public class VehicleMonitoringDelivery : List<VehicleActivity>
    {
        public DateTime ResponseTimestamp { get; set; }

        public string RequestMessageRef { get; set; }

        public DateTime ValidUntil { get; set; }

        public string ShortestPossibleCycle { get; set; }

    }

    public class VehicleActivity
    {
        public DateTime RecordedAtTime { get; set; }

        public string ItemIdentifier { get; set; }

        public DateTime ValidUntilTime { get; set; }

        public MonitoredVehicleJourney MonitoredVehicleJourney { get; set; }
    }

    public class MonitoredVehicleJourney
    {
        public MonitoredVehicleJourney()
        {
            LineRef = string.Empty;
            DirectionRef = string.Empty;
            PublishedLineName = string.Empty;

        }
        public string LineRef { get; set; }
        public string DirectionRef { get; set; }
        public string PublishedLineName { get; set; }
        public string OperatorRef { get; set; }
        public string OriginRef { get; set; }
        public string OriginName { get; set; }
        public string DestinationRef { get; set; }
        public string DestinationName { get; set; }

        public DateTime? OriginAimedDepartureTime { get; set; }

        public VehicleLocation VehicleLocation { get; set; }

        public double Bearing { get; set; }
        public string BlockRef { get; set; }
        public string VehicleRef { get; set; }

        public FramedVehicleJourneyRef FramedVehicleJourneyRef { get; set; }
    }

    public class VehicleLocation : ICoordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LatLng Coordinates => new LatLng(Latitude, Longitude);
    }

    public class  FramedVehicleJourneyRef
    {
        public string DatedVehicleJourneyRef { get; set; }
    }
}
