namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class getCustomerPaymentProfileController : ApiOperationBase<getCustomerPaymentProfileRequest, getCustomerPaymentProfileResponse> {

	    public getCustomerPaymentProfileController(getCustomerPaymentProfileRequest apiRequest) : base(apiRequest) {
	    }
	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    		
	    }
    }
}