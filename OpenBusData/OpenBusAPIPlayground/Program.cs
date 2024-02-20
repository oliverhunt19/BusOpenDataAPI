// See https://aka.ms/new-console-template for more information
using OpenBusDataAPI;

Console.WriteLine("Hello, World!");
string APIKey = "df3191ca1da34bb25d2072f60067eee9c00e2b22";

BusLocationRequest busLocationRequest = new BusLocationRequest()
{
    Key = APIKey,
    Bounds = LatLngBounds.GetBoundingBox(new LatLng(50.824217, -3.423283),10),
    LineRef = "1",
};

BusLocationAPI busLocationAPI = new BusLocationAPI();
var resp = await busLocationAPI.QueryAsync(busLocationRequest);

async Task RunLocationIdent(CancellationToken cancellationToken)
{
    BusLocationResponce resp = await busLocationAPI.QueryAsync(busLocationRequest, cancellationToken);
    Console.Write(resp.ServiceDelivery.VehicleMonitoringDelivery.FirstOrDefault()?.MonitoredVehicleJourney?.VehicleLocation.Latitude + " ");
    Console.WriteLine(resp.ServiceDelivery.VehicleMonitoringDelivery.FirstOrDefault()?.MonitoredVehicleJourney?.VehicleLocation.Longitude);
}

TimerAsync timerAsync = new TimerAsync(RunLocationIdent,TimeSpan.Zero, TimeSpan.FromSeconds(30));
timerAsync.Start();
Console.ReadLine();
await timerAsync.Stop();
Console.WriteLine("Stopped");
Console.ReadLine();
