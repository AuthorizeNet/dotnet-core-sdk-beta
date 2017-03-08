namespace AuthorizeNET.Api.Controllers
{
    using System;
    using AuthorizeNET.Api.Contracts.V1;
    using AuthorizeNET.Api.Controllers.Bases;


    public class ARBGetSubscriptionListController : ApiOperationBase<ARBGetSubscriptionListRequest, ARBGetSubscriptionListResponse> {

	    public ARBGetSubscriptionListController(ARBGetSubscriptionListRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		}
    }

}