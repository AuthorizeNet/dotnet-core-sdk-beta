namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class sendCustomerTransactionReceiptController : ApiOperationBase<sendCustomerTransactionReceiptRequest, sendCustomerTransactionReceiptResponse> {

	    public sendCustomerTransactionReceiptController(sendCustomerTransactionReceiptRequest apiRequest) : base(apiRequest) {
	    }
	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    		
	    }
    }

}