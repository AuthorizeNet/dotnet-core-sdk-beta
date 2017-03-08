namespace AuthorizeNET.Api.Controllers
{
    using System;
    using AuthorizeNET.Api.Contracts.V1;
    using AuthorizeNET.Api.Controllers.Bases;


    public class ARBCreateSubscriptionController : ApiOperationBase<ARBCreateSubscriptionRequest, ARBCreateSubscriptionResponse> {

	    public ARBCreateSubscriptionController(ARBCreateSubscriptionRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
            if (null == request.subscription) throw new ArgumentException("subscription cannot be null");
		    //if ( null == request.Paging) throw new ArgumentException("Paging cannot be null");
		
		    //validate not-required fields		
	    }

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.ARBCreateSubscriptionRequest(request);
        }
    }

}