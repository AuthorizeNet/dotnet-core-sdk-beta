using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AuthorizeNET.Tests
{
    [TestClass]
    public class TransactionControllerTests
    {
        merchantAuthenticationType MerchantAuthentication => new merchantAuthenticationType()
        {
            name = "5KP3u95bQpv",
            ItemElementName = ItemChoiceType.transactionKey,
            Item = "346HZ32z3fP4hTG2",
        };


        [TestMethod]
        public async Task ChargeAsync()
        {
            var transaction = new transactionRequestType
            {
                amount = 123.45m,
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                payment = new paymentType
                {
                    Item = new creditCardType
                    {
                        cardNumber = "4111111111111111",
                        expirationDate = "0349",
                        cardCode = "123"
                    }
                },

                billTo = new customerAddressType
                {
                    firstName = "TestName",
                    lastName = "McTesterson",
                    address = "123 Here st.",
                    city = "Springville",
                    state = "WA",
                    zip = "00000"
                }
            };

            var fullRequest = new createTransactionRequest
            {
                merchantAuthentication = MerchantAuthentication,
                transactionRequest = transaction,
            };

            // Send the request.
            var controller = new createTransactionController(fullRequest);
            var response = await controller.ExecuteWithApiResponseAsync(AuthorizeNet.Environment.SANDBOX);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void ChargeSync()
        {
            var transaction = new transactionRequestType
            {
                amount = 123.45m,
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                payment = new paymentType
                {
                    Item = new creditCardType
                    {
                        cardNumber = "4111111111111111",
                        expirationDate = "0349",
                        cardCode = "123"
                    }
                },

                billTo = new customerAddressType
                {
                    firstName = "TestName",
                    lastName = "McTesterson",
                    address = "123 Here st.",
                    city = "Springville",
                    state = "WA",
                    zip = "00000"
                }
            };

            var fullRequest = new createTransactionRequest
            {
                merchantAuthentication = MerchantAuthentication,
                transactionRequest = transaction,
            };

            // Send the request.
            var controller = new createTransactionController(fullRequest);
            var response = controller.ExecuteWithApiResponse(AuthorizeNet.Environment.SANDBOX);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetMerchangeDetails()
        {
            var controller = new getMerchantDetailsController(new getMerchantDetailsRequest
            {
                merchantAuthentication = MerchantAuthentication,
            });

            var response = await controller.ExecuteWithApiResponseAsync(AuthorizeNet.Environment.SANDBOX);
            Assert.IsNotNull(response);
        }
    }
}
