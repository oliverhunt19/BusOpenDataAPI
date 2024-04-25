// See https://aka.ms/new-console-template for more information
using GeneralUtils;
using OpenBusDataAPI;
using RoutePlanning.Geometry;
using System.Xml.Serialization;
using TransXChange.Common.Models;
using UnitsNet;

Console.WriteLine("Hello, World!");
string APIKey = "df3191ca1da34bb25d2072f60067eee9c00e2b22";

BusLocationRequest busLocationRequest = new BusLocationRequest(APIKey)
{
    Bounds = LatLngBounds.GetBoundingBox(new LatLng(51.443, -2.5849),Length.FromKilometers(10)),
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

//HttpClient httpClient = new HttpClient();
//var res = await httpClient.GetAsync("https://data.bus-data.dft.gov.uk/timetable/dataset/2059/download/");
//using(Stream stream = await res.Content.ReadAsStreamAsync())
//{
//    FileInfo fileInfo = new FileInfo("Test.zip");
//    using(Stream stream1 = fileInfo.Create())
//    {
//        await stream.CopyToAsync(stream1);
//    }
//}
//try
//{
//    using(ZipArchive zipArchive = ZipFile.OpenRead("Test.zip"))
//    {
//        zipArchive.ExtractToDirectory("TestZips");
//    }
//}
//catch
//{

//}


DirectoryInfo DirectoryInfo = new DirectoryInfo("TestZips");
TXCXmlTransXChange transX;
using(Stream stream2 = DirectoryInfo.GetFiles().First().Open( FileMode.Open))
{
    transX = (TXCXmlTransXChange) new XmlSerializer(typeof(TXCXmlTransXChange)).Deserialize(stream2);
}

    


    TimerAsync timerAsync = new TimerAsync(RunLocationIdent,TimeSpan.Zero, TimeSpan.FromSeconds(20));
await timerAsync.StartAsync();
Console.ReadLine();
await timerAsync.StopAsync();
Console.WriteLine("Stopped");
Console.ReadLine();
