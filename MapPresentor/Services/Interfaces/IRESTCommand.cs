using System.Threading.Tasks;

namespace MapPresentor.Services.Interfaces;
 
public interface IRESTCommand
{
    Task SendPostRequest(string ApiUrl, string data);
    Task<string> SendGetRequest(string ApiUrl);
}
