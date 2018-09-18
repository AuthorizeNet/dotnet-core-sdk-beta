namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class ARBGetSubscriptionStatusController : ApiOperationBase<ARBGetSubscriptionStatusRequest, ARBGetSubscriptionStatusResponse> {

	    public ARBGetSubscriptionStatusController(ARBGetSubscriptionStatusRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		}
    }

}