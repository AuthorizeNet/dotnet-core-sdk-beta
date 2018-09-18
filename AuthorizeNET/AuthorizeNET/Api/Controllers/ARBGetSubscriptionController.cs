namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class ARBGetSubscriptionController : ApiOperationBase<ARBGetSubscriptionRequest, ARBGetSubscriptionResponse> {

	    public ARBGetSubscriptionController(ARBGetSubscriptionRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
		    if ( request.subscriptionId == null) throw new ArgumentException( "Subscription ID cannot be null");
		}

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.ARBGetSubscriptionRequest(request);
        }
    }

}