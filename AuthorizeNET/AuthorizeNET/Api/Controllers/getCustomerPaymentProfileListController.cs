namespace AuthorizeNET.Api.Controllers
{
    using System;
    using AuthorizeNET.Api.Contracts.V1;
    using AuthorizeNET.Api.Controllers.Bases;


    public class getCustomerPaymentProfileListController : ApiOperationBase<getCustomerPaymentProfileListRequest, getCustomerPaymentProfileListResponse> {

	    public getCustomerPaymentProfileListController(getCustomerPaymentProfileListRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
            if (request.searchType < 0) throw new ArgumentException("SearchType cannot be null");
            if (request.month == null) throw new ArgumentException("month cannot be null");

		    //if ( null == request.Paging) throw new ArgumentException("Paging cannot be null");
		
		    //validate not-required fields		
	    }

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.getCustomerPaymentProfileListRequest(request);
        }
    }

}