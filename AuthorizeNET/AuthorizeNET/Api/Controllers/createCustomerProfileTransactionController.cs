namespace AuthorizeNET.Api.Controllers
{
    using System;
    using AuthorizeNET.Api.Contracts.V1;
    using AuthorizeNET.Api.Controllers.Bases;


    public class createCustomerProfileTransactionController : ApiOperationBase<createCustomerProfileTransactionRequest, createCustomerProfileTransactionResponse> {

	    public createCustomerProfileTransactionController(createCustomerProfileTransactionRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
            if (null == request.transaction) throw new ArgumentException("transaction cannot be null");
		
		    //validate not-required fields		
	    }
    }

}