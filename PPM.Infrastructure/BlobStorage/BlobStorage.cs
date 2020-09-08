using Microsoft.Azure.Storage.Blob;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PPM.Infrastructure.BlobStorage
{
    public class BlobStorage : IBlobStorage
    {

        private readonly CloudBlobContainer _blobCotainer;
        public BlobStorage(IBlobConnection blobConnection, string containerName)
        {
            _blobCotainer = blobConnection.GetContainer(containerName);
        }
        public async Task<BlobResult> SendAsBlob(Bitmap bitmap, string fileName)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                memoryStream.Position = 0;
                var cloudBlockBlob = _blobCotainer.GetBlockBlobReference(fileName);
                await cloudBlockBlob.UploadFromStreamAsync(memoryStream);
                return new BlobResult(_blobCotainer.Uri.AbsoluteUri);
            }
        }
    }
}
