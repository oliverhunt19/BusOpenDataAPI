// See https://aka.ms/new-console-template for more information
using OpenBusDataAPI;

Console.WriteLine("Hello, World!");
string APIKey = "df3191ca1da34bb25d2072f60067eee9c00e2b22";

BusLocationRequest busLocationRequest = new BusLocationRequest()
{
    Key = APIKey,
    Bounds = LatLngBounds.GetBoundingBox(new LatLng(50.723344, -3.595641),10),
};

BusLocationAPI busLocationAPI = new BusLocationAPI();
var resp = await busLocationAPI.QueryAsync(busLocationRequest);

Console.WriteLine();
