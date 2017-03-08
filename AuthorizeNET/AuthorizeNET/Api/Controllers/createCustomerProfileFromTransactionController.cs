namespace AuthorizeNET.Api.Controllers
{
    using System;
    using AuthorizeNET.Api.Contracts.V1;
    using AuthorizeNET.Api.Controllers.Bases;


    public class createCustomerProfileFromTransactionController : ApiOperationBase<createCustomerProfileFromTransactionRequest, createCustomerProfileResponse>
    {

        public createCustomerProfileFromTransactionController(createCustomerProfileFromTransactionRequest apiRequest)
            : base(apiRequest)
        {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
            if (null == request.transId) throw new ArgumentException("transactionId cannot be null");
		
		    //validate not-required fields		
	    }
    }

}