namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class deleteCustomerProfileController : ApiOperationBase<deleteCustomerProfileRequest, deleteCustomerProfileResponse> {

	    public deleteCustomerProfileController(deleteCustomerProfileRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    
	    }
    }

}