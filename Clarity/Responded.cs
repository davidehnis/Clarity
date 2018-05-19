namespace Clarity
{
    public class Responded : Condition
    {
        public Statement With<TResponse>()
        {
            return new Statement();
        }
    }
}