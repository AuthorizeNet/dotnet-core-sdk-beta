namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class getCustomerProfileIdsController : ApiOperationBase<getCustomerProfileIdsRequest, getCustomerProfileIdsResponse> {

	    public getCustomerProfileIdsController(getCustomerProfileIdsRequest apiRequest) : base(apiRequest) {
	    }
	    override protected void ValidateRequest() {
            var request = GetApiRequest();			   	
	    }
    }
}