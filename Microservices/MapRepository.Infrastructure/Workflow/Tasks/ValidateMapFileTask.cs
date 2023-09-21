using MapRepository.Core.Workflow.Tasks;

namespace MapRepository.Infrastructure.Workflow.Tasks
{
    internal class ValidateMapFileTask : IValidateMapFileTask
    {
        public bool Validate(string mapname)
        {
            //file(MapFileValidation)-
            //1. not null
            //2. not bigger than 1 mb
            //3. jpeg / jpg / png / svg(file extenson)
            return true;
        }
    }
}
