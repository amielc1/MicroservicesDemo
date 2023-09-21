namespace MapRepository.Core.Workflow.Tasks
{
    public interface IValidateMapFileExistTask
    {
        Task<bool> Validate(string mapname);
    }
}
