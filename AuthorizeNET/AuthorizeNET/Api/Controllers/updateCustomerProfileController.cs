namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class updateCustomerProfileController : ApiOperationBase<updateCustomerProfileRequest, updateCustomerProfileResponse> {

	    public updateCustomerProfileController(updateCustomerProfileRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    	
	    }
    }

}