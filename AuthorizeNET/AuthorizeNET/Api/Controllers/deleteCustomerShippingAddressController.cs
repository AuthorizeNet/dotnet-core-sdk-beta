namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class deleteCustomerShippingAddressController : ApiOperationBase<deleteCustomerShippingAddressRequest, deleteCustomerShippingAddressResponse> {

	    public deleteCustomerShippingAddressController(deleteCustomerShippingAddressRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();			    	
	    }
    }

}