namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class getCustomerPaymentProfileListController : ApiOperationBase<getCustomerPaymentProfileListRequest, getCustomerPaymentProfileListResponse> {

	    public getCustomerPaymentProfileListController(getCustomerPaymentProfileListRequest apiRequest) : base(apiRequest) {
	    }
	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
            if (request.searchType < 0) throw new ArgumentException("SearchType cannot be null");
            if (request.month == null) throw new ArgumentException("month cannot be null");		    	
	    }
        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.getCustomerPaymentProfileListRequest(request);
        }
    }

}