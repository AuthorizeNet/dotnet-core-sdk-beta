﻿using System;
using System.Collections.Generic;
using AuthorizeNET.Api.Controllers;
using AuthorizeNET.Api.Contracts.V1;
using AuthorizeNET.Api.Controllers.Bases;

namespace net.authorize.sample
{
    public class CreateCustomerProfileFromTransaction
    {
        public static ANetApiResponse Run(string ApiLoginID, string ApiTransactionKey, string transactionId)
        {
            Console.WriteLine("CreateCustomerProfileFromTransaction Sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNET.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name            = ApiLoginID,
                ItemElementName = ItemChoiceType.transactionKey,
                Item            = ApiTransactionKey,
            };

            var customerProfile = new customerProfileBaseType
            {
                merchantCustomerId = "123212",
                email = "hello@castleblack.com",
                description = "This is a sample customer profile"
            };

            var request = new createCustomerProfileFromTransactionRequest 
            { 
                transId = transactionId,
                // You can either specify the customer information in form of customerProfileBaseType object
                customer = customerProfile
                //  OR   
                // You can just provide the customer Profile ID
                // customerProfileId = "123343"                
            };

            var controller = new createCustomerProfileFromTransactionController(request); 
            controller.Execute();

            createCustomerProfileResponse response = controller.GetApiResponse(); 
           
            //validate
            if (response != null && response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response != null && response.messages.message != null)
                {
                    Console.WriteLine("Success, CustomerProfileID : " + response.customerProfileId);

                    if (response.customerPaymentProfileIdList.Length > 0)
                        Console.WriteLine("Success, CustomerPaymentProfileID : " + response.customerPaymentProfileIdList[0]);

                    if (response.customerShippingAddressIdList.Length > 0)
                        Console.WriteLine("Success, CustomerShippingProfileID : " + response.customerShippingAddressIdList[0]);
                }
            }
            else if(response != null)
            {
                Console.WriteLine("Error: " + response.messages.message[0].code + "  " + response.messages.message[0].text);
            }

            return response;
        }
    }
}
