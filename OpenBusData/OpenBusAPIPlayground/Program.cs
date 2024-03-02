// See https://aka.ms/new-console-template for more information
using GeneralUtils;
using OpenBusDataAPI;
using RoutePlanning;
using UnitsNet;

Console.WriteLine("Hello, World!");
string APIKey = "df3191ca1da34bb25d2072f60067eee9c00e2b22";

BusLocationRequest busLocationRequest = new BusLocationRequest(APIKey)
{
    Bounds = LatLngBounds.GetBoundingBox(new LatLng(50.824217, -3.423283),Length.FromKilometers(10)),
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

TimerAsync timerAsync = new TimerAsync(RunLocationIdent,TimeSpan.Zero, TimeSpan.FromSeconds(20));
await timerAsync.StartAsync();
Console.ReadLine();
await timerAsync.StopAsync();
Console.WriteLine("Stopped");
Console.ReadLine();
