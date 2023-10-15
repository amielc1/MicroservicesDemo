using MapRepository.Core.Workflow.Tasks;

namespace MapRepository.Infrastructure.Workflow.Tasks.MapRepositoryTasks;

internal class ValidateMapNameTask : IValidateMapNameTask
{
    //    name - (MapNameValidation) 
    //1. name not empty or null
    //2. unique name
    //3. only char or numbers, no space

    public bool Validate(string mapname)
    {
        return true;
    }
}
