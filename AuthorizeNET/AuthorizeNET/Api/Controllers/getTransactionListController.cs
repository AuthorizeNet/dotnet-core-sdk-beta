namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class getTransactionListController : ApiOperationBase<getTransactionListRequest, getTransactionListResponse> {

	    public getTransactionListController(getTransactionListRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();				    	
	    }
    }
}