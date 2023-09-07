
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker.Core.Interfaces
{
    public interface ISubscriber
    {
        Task Subscribe(string topic, Action<string> OnMessageArrived);
    }
}
