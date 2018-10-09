namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class ARBCreateSubscriptionController : ApiOperationBase<ARBCreateSubscriptionRequest, ARBCreateSubscriptionResponse> {

	    public ARBCreateSubscriptionController(ARBCreateSubscriptionRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
            if (null == request.subscription) throw new ArgumentException("subscription cannot be null");		
		}

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.ARBCreateSubscriptionRequest(request);
        }
    }

}