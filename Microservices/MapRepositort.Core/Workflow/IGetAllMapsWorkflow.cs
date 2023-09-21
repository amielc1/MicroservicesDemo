namespace MapRepository.Core.Workflow
{
    public interface IGetAllMapsWorkflow
    {
        Task<List<string>> GetAllMaps();
    }
}
