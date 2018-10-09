namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class getTransactionDetailsController : ApiOperationBase<getTransactionDetailsRequest, getTransactionDetailsResponse> {

	    public getTransactionDetailsController(getTransactionDetailsRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    
	    }
    }

}