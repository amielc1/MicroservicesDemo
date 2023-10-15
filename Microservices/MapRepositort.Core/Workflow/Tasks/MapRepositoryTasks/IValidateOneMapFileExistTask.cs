namespace MapRepository.Core.Workflow.Tasks;

public interface IValidateOneMapFileExistTask
{
    Task<bool> Validate(string mapname,string bucket);
}
