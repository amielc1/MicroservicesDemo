namespace MapRepository.Core.Workflow.Tasks;

public interface IValidateMapFileTask
{
    bool Validate(string mapname);
}
