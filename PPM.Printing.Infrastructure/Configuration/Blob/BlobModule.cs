using Autofac;
using PPM.Infrastructure.BlobStorage;

namespace PPM.Printing.Infrastructure.Configuration.Blob
{
    public class BlobModule : Autofac.Module
    {
        private readonly string _blobConnectionString;
        private readonly string _qrCollection;
        public BlobModule(string blobConnectionString, string qrCollection)
        {
            _blobConnectionString = blobConnectionString;
            _qrCollection = qrCollection;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlobConnection>()
                  .AsImplementedInterfaces()
                  .WithParameter("connectionString", _blobConnectionString);

            builder.RegisterType<BlobStorage>()
                .AsImplementedInterfaces()
                .WithParameter("containerName", _qrCollection);
        }
    }
}
