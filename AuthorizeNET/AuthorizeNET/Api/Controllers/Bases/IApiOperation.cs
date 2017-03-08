namespace AuthorizeNET.Api.Controllers.Bases
{
    using System.Collections.Generic;

    public interface IApiOperation<TQ, TS>
        where TQ : Contracts.V1.ANetApiRequest
        where TS : Contracts.V1.ANetApiResponse
    {
        TS GetApiResponse();
        Contracts.V1.ANetApiResponse GetErrorResponse();
        TS ExecuteWithApiResponse(Environment environment = null);
        void Execute(AuthorizeNET.Environment environment = null);
        AuthorizeNET.Api.Contracts.V1.messageTypeEnum GetResultCode();
        List<string> GetResults();
    }
}