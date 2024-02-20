namespace OpenBusDataAPI
{
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

    public class VehicleMonitoringDelivery
    {
        public DateTime ResponseTimestamp { get; set; }

        public string RequestMessageRef { get; set; }

        public DateTime ValidUntil { get; set; }

        public string ShortestPossibleCycle { get; set; }

        public VehicleActivity VehicleActivity {get;set;}
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
        public string LineRef { get; set; }
        public string DirectionRef { get; set; }
        public string PublishedLineName { get; set; }
        public string OperatorRef { get; set; }
        public string OriginRef { get; set; }
        public string OriginName { get; set; }
        public string DestinationRef { get; set; }
        public string DestinationName { get; set; }

        public VehicleLocation VehicleLocation { get; set; }

        public double Bearing { get; set; }
        public string BlockRef { get; set; }
        public string VehicleRef { get; set; }
    }

    public class VehicleLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
