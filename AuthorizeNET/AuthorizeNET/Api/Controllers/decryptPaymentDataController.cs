namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class decryptPaymentDataController : ApiOperationBase<decryptPaymentDataRequest, decryptPaymentDataResponse> {

	    public decryptPaymentDataController(decryptPaymentDataRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();		   	
	    }

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.decryptPaymentDataRequest(request);
        }
    }

}