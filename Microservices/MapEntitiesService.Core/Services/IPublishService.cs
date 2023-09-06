using MapEntitiesService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEntitiesService.Core.Services
{
    public interface IPublishService
    {
        void Publish(MapEntityDto entity, string topic);
    }
}
