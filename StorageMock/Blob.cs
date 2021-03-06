﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StorageMock
{
    public class Blob
    {
        private Stream _content;
        
        public DateTime LastModified { get; private set; }

        public string ETag { get; private set; }

        // If client does not validate, it's faster to use a static mock than compute the actual values
        public string ContentMD5 => "1IbBQxpftsNd4a6CAVvHIQ==";

        // If client does not validate, it's faster to use a static mock than compute the actual values
        public string ContentCrc64 => "8Od48H1qTIQ=";

        public Stream Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;

                LastModified = DateTime.Now;

                // "0x8D74828B7C5A4F7" (include quotes)
                // ETags are often generated by hashing the content, but I think generating a new GUID on every write is also valid
                ETag = "\"0x" + Guid.NewGuid().ToString("N").Substring(0, 15) + "\"";
            }
        }

    }
}
