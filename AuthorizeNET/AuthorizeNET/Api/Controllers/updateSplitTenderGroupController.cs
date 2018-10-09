namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class updateSplitTenderGroupController : ApiOperationBase<updateSplitTenderGroupRequest, updateSplitTenderGroupResponse> {

	    public updateSplitTenderGroupController(updateSplitTenderGroupRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();		    	
	    }
    }

}