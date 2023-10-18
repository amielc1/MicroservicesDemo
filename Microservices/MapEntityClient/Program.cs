// See https://aka.ms/new-console-template for more information
using MapEntitiesService.Core.Models;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;


//Set connection
var builder = new HubConnectionBuilder()
    .WithUrl("https://localhost:51082/notification")
    .WithAutomaticReconnect();

var connection = builder.Build();

await connection.StartAsync();

Console.WriteLine($"connection.State {connection.State}");

connection.On<MapEntityDto>("ReciveMapEntity",
   (mapentity) =>
   {
       Console.WriteLine($"Message : {mapentity.Tile},{mapentity.PointX}, {mapentity.PointY}");
   });

Console.Read();
Console.WriteLine();