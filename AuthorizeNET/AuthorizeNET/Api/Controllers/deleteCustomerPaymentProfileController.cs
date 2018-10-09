namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class deleteCustomerPaymentProfileController : ApiOperationBase<deleteCustomerPaymentProfileRequest, deleteCustomerPaymentProfileResponse> {

	    public deleteCustomerPaymentProfileController(deleteCustomerPaymentProfileRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();			    	
	    }
    }

}