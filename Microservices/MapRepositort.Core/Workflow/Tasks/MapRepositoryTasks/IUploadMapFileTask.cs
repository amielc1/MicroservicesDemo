namespace MapRepository.Core.Workflow.Tasks;

public interface IUploadMapFileTask
{
    Task<bool> UploadMap(string mapname,Stream mapstream);
}
