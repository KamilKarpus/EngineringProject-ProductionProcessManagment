using System.Drawing;
using System.Threading.Tasks;

namespace PPM.Infrastructure.BlobStorage
{
    public interface IBlobStorage
    {
        Task<BlobResult> SendAsBlob(Bitmap bitmap, string fileName);
    }
}
