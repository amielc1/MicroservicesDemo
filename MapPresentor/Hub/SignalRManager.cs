using MapPresentor.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace MapPresentor
{
    public class SignalRManager
    {
        private readonly string hubUrl;
        public readonly HubConnection connection;

        public SignalRManager(string hubUrl)
        {
            this.hubUrl = hubUrl;
            connection = BuildHubConnection();
            StartConnection();
        }
         
        public void RegisterMapEntityHandler(Action<MapEntityDto> handler)
        {
            connection.On<MapEntityDto>("ReciveMapEntity", mapEntity => handler?.Invoke(mapEntity));
        }

        public void RegisterMissionMapChangedHandler(Action<string> handler)
        {
            connection.On<string>("MissionMapChanged", mapName => handler?.Invoke(mapName)); 
        }

        private async void StartConnection()
        {
            await connection.StartAsync();
            Console.WriteLine($"Connection state: {connection.State}");
        }

        private HubConnection BuildHubConnection()
        {
            return new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();
        }
    }
}
