namespace AuthorizeNet.Api.Controllers
{
    using System;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers.Bases;


    public class mobileDeviceLoginController : ApiOperationBase<mobileDeviceLoginRequest, mobileDeviceLoginResponse> {

	    public mobileDeviceLoginController(mobileDeviceLoginRequest apiRequest) : base(apiRequest) {
	    }
	    override protected void ValidateRequest() {
            var request = GetApiRequest();		   	
	    }
    }
}