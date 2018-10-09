namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class getBatchStatisticsController : ApiOperationBase<getBatchStatisticsRequest, getBatchStatisticsResponse> {

	    public getBatchStatisticsController(getBatchStatisticsRequest apiRequest) : base(apiRequest) {
	    }
	    override protected void ValidateRequest() {
            var request = GetApiRequest();		
		    	
	    }
    }
}