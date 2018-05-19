namespace Clarity
{
    public class Status
    {
        public Condition With<TStatus>() where TStatus : Status
        {
            return new Condition();
        }
    }
}