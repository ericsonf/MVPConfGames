using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MVPConfGamesTrigger
{
    public static class BlobTrigger
    {
        [FunctionName("BlobTriggerFunction")]
        public static void Run([BlobTrigger("images/{name}", Connection = "mvpconfstorage_STORAGE")]Stream myBlob, string name, [Blob("thumbnails/{name}", FileAccess.Write)] Stream outputBlob, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            using (var image = Image.Load(myBlob))
            {
                image.Mutate(x => x.Resize(640, 480));
                image.Save(outputBlob, new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder());
            }
        }
    }
}
