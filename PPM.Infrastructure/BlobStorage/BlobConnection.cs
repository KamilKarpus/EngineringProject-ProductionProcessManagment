using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace PPM.Infrastructure.BlobStorage
{
    public class BlobConnection : IBlobConnection
    {
        private readonly string _connectionString;
        public BlobConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CloudBlobContainer GetContainer(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(_connectionString);

            var blobClient = storageAccount.CreateCloudBlobClient();

            var cloudBlobContainer = blobClient.GetContainerReference(containerName);
            return cloudBlobContainer;
        }
    }
}
