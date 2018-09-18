namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;

    public class getCustomerProfileController : ApiOperationBase<getCustomerProfileRequest, getCustomerProfileResponse> {

	    public getCustomerProfileController(getCustomerProfileRequest apiRequest) : base(apiRequest) {
	    }
	    override protected void ValidateRequest() {
            var request = GetApiRequest();			   	
	    }
    }
}