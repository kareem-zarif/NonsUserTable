using NonsUserTable.APiDtos.Respose;
using NonsUserTable.Enums;

namespace NonsUserTable.Utilites
{
    public class ErrorCatcherUtlity<TRes>
        where TRes : class
    {
        private readonly BaseControlResponse<TRes> _errorBaseControllerResp;
        public ErrorCatcherUtlity()
        {
            _errorBaseControllerResp = new BaseControlResponse<TRes>();
        }

        public BaseControlResponse<TRes> CatchErrorAndReturnBaseControolerResponse(Guid errorId, string friendlyMsg, Exception ex)
        {
            _errorBaseControllerResp.ResponseResult = RespinseResultEnum.Failure;
            //for errorDetail
            var errDetails = new ErrorResponse
            {
                ErrorCode = errorId,
                FrindlyErrorMessage = friendlyMsg,
            };
            errDetails.TechErrorMessages.Add(ex.Message);
            while (ex.InnerException is not null)
            {
                errDetails.TechErrorMessages.Add(ex.InnerException.Message);
            }

            _errorBaseControllerResp.ErrorDetails = errDetails;

            //log exception

            return _errorBaseControllerResp;

        }

        public static void LogException(Guid errCode, Exception ex)
        {
            // TODO : HERE I WILL HANDLE LOG OF EXCEPTION.
            // I CAN TO SEND EMAIL ALSO FOR DEVELOPERS TO SOLVE IT.
        }
    }
}
