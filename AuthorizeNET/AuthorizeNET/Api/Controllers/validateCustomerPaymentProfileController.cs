namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class validateCustomerPaymentProfileController : ApiOperationBase<validateCustomerPaymentProfileRequest, validateCustomerPaymentProfileResponse> {

	    public validateCustomerPaymentProfileController(validateCustomerPaymentProfileRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    	
	    }
    }

}