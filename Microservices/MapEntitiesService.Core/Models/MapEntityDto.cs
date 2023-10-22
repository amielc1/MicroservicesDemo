namespace MapEntitiesService.Core.Models;

public class MapEntityDto
{
    public string Title { get; set; } = string.Empty;
    public float PointX { get; set; } = float.NaN;
    public float PointY { get; set; } = float.NaN;
}
