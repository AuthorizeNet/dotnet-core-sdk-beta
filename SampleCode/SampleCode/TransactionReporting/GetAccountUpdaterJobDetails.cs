using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNET.Api.Contracts.V1;
using AuthorizeNET.Api.Controllers;
using AuthorizeNET.Api.Controllers.Bases;

namespace net.authorize.sample
{
    public class GetAccountUpdaterJobDetails
    {
        public static ANetApiResponse Run(String ApiLoginID, String ApiTransactionKey)
        {
            Console.WriteLine("Get Account Updater job details sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNET.Environment.SANDBOX;
            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = ApiLoginID,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = ApiTransactionKey,
            };

            // parameters for request
            string month = "2018-05";
            //AUJobTypeEnum.all = "all";

            var request = new getAUJobDetailsRequest();
            request.month = month;
            request.modifiedTypeFilter = AUJobTypeEnum.all;
            request.paging = new Paging
            {
                limit = 1000,
                offset = 1
            };

            // instantiate the controller that will call the service
            var controller = new getAUJobDetailsController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            if (response != null && response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.auDetails == null)
                    return response;

                foreach (var update in response.auDetails)
                {
                    Console.WriteLine("Profile ID / Payment Profile ID: {0} / {1}", update.customerProfileID, update.customerPaymentProfileID);
                    Console.WriteLine("Update Time (UTC): {0}", update.updateTimeUTC);
                    Console.WriteLine("Reason Code: {0}", update.auReasonCode);
                    Console.WriteLine("Reason Description: {0}", update.reasonDescription);

                    ////Fetching Subscription ID for AU Update
                    //if (update.subscriptionIds != null && update.subscriptionIds.Length > 0)
                    //{
                    //    Console.WriteLine("List of subscriptions : ");
                    //    for (int i = 0; i < update.subscriptionIds.Length; i++)
                    //        Console.WriteLine(update.subscriptionIds[i]);
                    //}
                }

                foreach (var delete in response.auDetails)
                {
                    Console.WriteLine("Profile ID / Payment Profile ID: {0} / {1}", delete.customerProfileID, delete.customerPaymentProfileID);
                    Console.WriteLine("Update Time (UTC): {0}", delete.updateTimeUTC);
                    Console.WriteLine("Reason Code: {0}", delete.auReasonCode);
                    Console.WriteLine("Reason Description: {0}", delete.reasonDescription);

                    ////Fetching Subscription ID for AU Delete
                    //if (delete.subscriptionIds != null && delete.subscriptionIds.Length > 0)
                    //{
                    //    Console.WriteLine("List of subscriptions : ");
                    //    for (int i = 0; i < delete.subscriptionIds.Length; i++)
                    //        Console.WriteLine(delete.subscriptionIds[i]);
                    //}
                }
            }
            else if (response != null)
            {
                Console.WriteLine("Error: " + response.messages.message[0].code + "  " +
                                    response.messages.message[0].text);
            }

            return response;
        }
    }
}
