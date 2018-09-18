namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class getUnsettledTransactionListController : ApiOperationBase<getUnsettledTransactionListRequest, getUnsettledTransactionListResponse> {

	    public getUnsettledTransactionListController(getUnsettledTransactionListRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    
	    }
    }
}