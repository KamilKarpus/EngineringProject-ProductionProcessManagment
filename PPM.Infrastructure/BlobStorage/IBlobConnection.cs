using Microsoft.Azure.Storage.Blob;

namespace PPM.Infrastructure.BlobStorage
{
    public interface IBlobConnection
    {
        CloudBlobContainer GetContainer(string cointainerName);
    }
}
