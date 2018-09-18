namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class getCustomerShippingAddressController : ApiOperationBase<getCustomerShippingAddressRequest, getCustomerShippingAddressResponse> {

	    public getCustomerShippingAddressController(getCustomerShippingAddressRequest apiRequest) : base(apiRequest) {
	    }
	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    	
	    }
    }
}