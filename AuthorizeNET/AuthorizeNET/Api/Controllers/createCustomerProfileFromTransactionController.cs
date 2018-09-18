namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


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
	    }
    }

}