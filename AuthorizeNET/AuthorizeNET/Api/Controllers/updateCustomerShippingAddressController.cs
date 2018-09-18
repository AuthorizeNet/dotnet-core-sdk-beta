namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class updateCustomerShippingAddressController : ApiOperationBase<updateCustomerShippingAddressRequest, updateCustomerShippingAddressResponse> {

	    public updateCustomerShippingAddressController(updateCustomerShippingAddressRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    	
	    }
    }

}