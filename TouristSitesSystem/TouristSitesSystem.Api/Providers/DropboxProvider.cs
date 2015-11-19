namespace TouristSitesSystem.Api.Providers
{
    using Spring.IO;
    using Spring.Social.Dropbox.Api;
    using Spring.Social.Dropbox.Connect;
    using Spring.Social.OAuth1;
    using System.Threading;

    public class DropboxProvider : ICloudProvider
    {
        private const string AppKey = "kuu2a87yki1vjrs";
        private const string AppSecret = "awtmxmqpqtvwngk";

        private static string dropboxAccessToken = "yrucyumw3k9q2yp2";
        private static string dropboxSecret = "48pf5ozh29uicmq";

        private static DropboxServiceProvider dropboxServiceProvider =
            new DropboxServiceProvider(AppKey, AppSecret, AccessLevel.AppFolder);

        private static OAuthToken oauthAccessToken = new OAuthToken(dropboxAccessToken, dropboxSecret);

        private IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

        public string UploadFile(byte[] file, string path)
        {
            var resource = new ByteArrayResource(file);
            Entry uploadFileEntry = dropbox.UploadFileAsync(
                   resource, path, true, null, CancellationToken.None).Result;

            //var src = dropbox.GetMediaLinkAsync(path).Result.Url;

            var src = GetSrc(path);

            //var a = dropbox.GetShareableLinkAsync(path).Result.Url;

            return src;
        }

        public string GetSrc(string path)
        {
            var src = dropbox.GetMediaLinkAsync(path).Result.Url;

            return src;
        }
    }
}