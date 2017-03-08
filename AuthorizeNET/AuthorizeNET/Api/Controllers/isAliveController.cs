namespace AuthorizeNET.Api.Controllers
{
    using System;
    using AuthorizeNET.Api.Contracts.V1;
    using AuthorizeNET.Api.Controllers.Bases;


    public class isAliveController : ApiOperationBase<ANetApiRequest, isAliveResponse>
    {

        public isAliveController(ANetApiRequest apiRequest)
            : base(apiRequest)
        {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
	    }

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.isAliveRequest(request);
        }
    }

}