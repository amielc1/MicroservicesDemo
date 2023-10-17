using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace MapPresentor
{
    public class SignalRManager
    {
        private readonly string hubUrl;
        private readonly HubConnection connection;

        public SignalRManager(string hubUrl)
        {
            this.hubUrl = hubUrl;
            connection = BuildHubConnection();
        }

        public async void StartConnection(Action onMissionMapChanged)
        {
            await connection.StartAsync();
            Console.WriteLine($"Connection state: {connection.State}");

            connection.On<string>("MissionMapChanged", mapName =>
            {
                onMissionMapChanged?.Invoke();
            });
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
