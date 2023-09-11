using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Core.Interfaces
{
    public interface INotificationService 
    {
        Task Subscribe(string topic, Action<string> OnMessageArrived);
    }
}
