namespace TouristSitesSystem.Api.Providers
{
    public interface ICloudProvider
    {
        string UploadFile(byte[] file, string path);
    }
}
