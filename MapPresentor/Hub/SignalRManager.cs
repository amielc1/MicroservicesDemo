using MapEntitiesService.Core.Models;
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
