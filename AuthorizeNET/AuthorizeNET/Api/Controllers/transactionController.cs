namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class transactionController
    
    {
	    public transactionController(transactionRequestType apiRequest) 
           
        {
	    }

	    //override
        protected void ValidateRequest() {           	
	    }

        
        protected void BeforeExecute()
        {            
        }
    }

}