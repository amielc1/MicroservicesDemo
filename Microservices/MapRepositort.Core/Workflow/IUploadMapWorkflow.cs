using MapRepository.Core.Models;

namespace MapRepository.Core.Workflow
{
    public interface IUploadMapWorkflow
    {
        Task<ResultModel> UploadMap(string mapname, string pathToMap);
    }

}
