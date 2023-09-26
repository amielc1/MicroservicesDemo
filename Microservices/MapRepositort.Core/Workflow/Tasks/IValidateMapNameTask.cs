namespace MapRepository.Core.Workflow.Tasks;

public interface IValidateMapNameTask
{
    bool Validate(string mapname);
}
