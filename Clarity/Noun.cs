namespace Clarity
{
    public class Noun
    {
        public Service With<TService>() where TService : Service, new()
        {
            return new TService();
        }
    }
}