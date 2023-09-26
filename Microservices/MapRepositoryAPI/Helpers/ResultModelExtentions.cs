using MapRepository.Core.Models;
using MapRepositoryAPI.DTOs;

namespace MapRepositoryAPI.Helpers
{
    public static class ResultModelExtensions
    {
        public static ResultDto ToDto(this ResultModel resultModel)
        {
            return new ResultDto
            {
                Success = resultModel.Success,
                ErrorMessage = resultModel.ErrorMessage
            };
        }
    }
}
