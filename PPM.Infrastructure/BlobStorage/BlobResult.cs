using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Infrastructure.BlobStorage
{
    public class BlobResult
    {
        public string Url { get; private set; }
        public BlobResult(string url)
        {
            Url = url;
        }
    }
}
