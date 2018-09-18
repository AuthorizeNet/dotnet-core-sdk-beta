namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class updateCustomerProfileController : ApiOperationBase<updateCustomerProfileRequest, updateCustomerProfileResponse> {

	    public updateCustomerProfileController(updateCustomerProfileRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
		    //validate required fields		
		    //if ( null == request.Paging) throw new ArgumentException("Paging cannot be null");
		
		    //validate not-required fields		
	    }
    }

}