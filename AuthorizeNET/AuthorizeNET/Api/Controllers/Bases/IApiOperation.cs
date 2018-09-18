namespace AuthorizeNet.Api.Controllers.Bases
{
    using System.Collections.Generic;

    public interface IApiOperation<TQ, TS>
        where TQ : Contracts.V1.ANetApiRequest
        where TS : Contracts.V1.ANetApiResponse
    {
        TS GetApiResponse();
        Contracts.V1.ANetApiResponse GetErrorResponse();
        TS ExecuteWithApiResponse(Environment environment = null);
        void Execute(AuthorizeNet.Environment environment = null);
        AuthorizeNet.Api.Contracts.V1.messageTypeEnum GetResultCode();
        List<string> GetResults();
    }
}