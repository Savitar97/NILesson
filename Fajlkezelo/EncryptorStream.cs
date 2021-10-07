using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fajlkezelo
{
    public class EncryptorStream : Stream
    {
        private readonly Stream _basestream;
        private readonly byte _mask;

        public EncryptorStream(Stream baseStream,byte mask)
        {
            _basestream = baseStream;
            _mask = mask;

        }
        public override bool CanRead => _basestream.CanRead;

        public override bool CanSeek => _basestream.CanSeek;

        public override bool CanWrite => _basestream.CanWrite;

        public override long Length => _basestream.Length;

        public override long Position { get => _basestream.Position; set => _basestream.Position=value; }

        public override void Flush()
        {
            _basestream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var readLength=_basestream.Read(buffer, offset, count);
            for(int i = offset; i < offset + readLength; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ _mask);
            }
            return readLength;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _basestream.Seek(offset,origin);
        }

        public override void SetLength(long value)
        {
            _basestream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var encryptedBuffer = new byte[buffer.Length];
            for(int i=offset;i<=offset+count;i++)
            {
                encryptedBuffer[i] = (byte)(buffer[i] ^ _mask);
            }
            _basestream.Write(encryptedBuffer, offset, count);
        }
    }
}
