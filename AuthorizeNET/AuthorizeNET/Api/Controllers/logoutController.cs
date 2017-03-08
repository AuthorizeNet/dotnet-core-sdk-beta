namespace AuthorizeNET.Api.Controllers
{
    using System;
    using AuthorizeNET.Api.Contracts.V1;
    using AuthorizeNET.Api.Controllers.Bases;


    public class logoutController : ApiOperationBase<logoutRequest, logoutResponse> {

	    public logoutController(logoutRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
		    //if ( 0 == request.SearchType) throw new ArgumentException( "SearchType cannot be null");
		    //if ( null == request.Paging) throw new ArgumentException("Paging cannot be null");
		
		    //validate not-required fields		
	    }

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.logoutRequest(request);
        }
    }

}