namespace OnlineEngine.HttpEngine
{
    public interface IHttpEngine
    {
        object Get();
        object Post();
        object Delete();
        object Put();
        object Patch();

        void Configure(object configuration);
    }
}