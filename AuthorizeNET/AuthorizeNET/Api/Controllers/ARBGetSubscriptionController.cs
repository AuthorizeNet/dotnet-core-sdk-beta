namespace AuthorizeNET.Api.Controllers
{
    using System;
    using AuthorizeNET.Api.Contracts.V1;
    using AuthorizeNET.Api.Controllers.Bases;


    public class ARBGetSubscriptionController : ApiOperationBase<ARBGetSubscriptionRequest, ARBGetSubscriptionResponse> {

	    public ARBGetSubscriptionController(ARBGetSubscriptionRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
		    if ( request.subscriptionId == null) throw new ArgumentException( "Subscription ID cannot be null");
		    
            //if ( null == request.Paging) throw new ArgumentException("Paging cannot be null");
		
		    //validate not-required fields		
	    }

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.ARBGetSubscriptionRequest(request);
        }
    }

}