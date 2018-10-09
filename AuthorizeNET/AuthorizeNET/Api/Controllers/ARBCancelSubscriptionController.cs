namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class ARBCancelSubscriptionController : ApiOperationBase<ARBCancelSubscriptionRequest, ARBCancelSubscriptionResponse> {

	    public ARBCancelSubscriptionController(ARBCancelSubscriptionRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();	
		}
    }

}