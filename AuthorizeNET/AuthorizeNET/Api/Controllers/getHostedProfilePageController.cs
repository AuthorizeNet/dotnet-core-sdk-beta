namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class getHostedProfilePageController : ApiOperationBase<getHostedProfilePageRequest, getHostedProfilePageResponse> {

	    public getHostedProfilePageController(getHostedProfilePageRequest apiRequest) : base(apiRequest) {
	    }
	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    	
	    }
    }
}