namespace Clarity
{
    public class Sample : Server
    {
        public Sample()
        {
            Authenticated = new ConditionalRequest<Authenticate>(CheckCredentials);

            Register<Authenticate>(Handle);
        }

        protected ConditionalRequest<Authenticate> Authenticated { get; }

        private bool CheckCredentials(Authenticate o)
        {
            return o.Username == "bob" && o.Password == "bob123;";
        }

        private void Handle(Authenticate obj)
        {
            if (Authenticated.IsTrue(obj))
            {
                Session.RespondWith(new UserAuthenticated());
            }
            else
            {
                Session.RespondWith(new UserNotAuthenticated());
            }
        }
    }
}