using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEntitiesService.Core.Models
{
    public class MapEntityDto
    {
        public string Tile { get; set; } = string.Empty;
        public float PointX { get; set; } = float.NaN;
        public float PointY { get; set; } = float.NaN;
    }
}
