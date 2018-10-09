namespace AuthorizeNet
{
    public class App
    {

        public const string CpVersion = "1.0";  // card present version 
        protected Environment Environment { get; set; }
        protected string Login { get; set; }
        protected string TransactionKey { get; set; }

        private App()
        {
            Environment = Environment.SANDBOX;
        }

        public static App CreateApp(Environment environment, string login, string transactionKey)
        {
            var merchant = new App { Environment = environment, Login = login, TransactionKey = transactionKey };

            return merchant;
        }

        public bool IsSandboxEnvironment()
        {
            return (Environment != null &&
                (Environment.SANDBOX == Environment));
        }
    }
}