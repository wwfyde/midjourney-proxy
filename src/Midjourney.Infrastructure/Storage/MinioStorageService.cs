using Minio;
using Minio.DataModel.Args;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

using ILogger = Serilog.ILogger;

namespace Midjourney.Infrastructure.Storage
{
    public class MinioStorageService : IStorageService
    {
        private readonly IMinioClient _minioClient;
        private readonly MinioOptions _minioOptions;
        private readonly string _bucketName;

        private readonly ILogger _logger;

        public MinioStorageService()
        {
            var minioOptions = GlobalConfiguration.Setting.MinioStorage;
            _minioOptions = minioOptions;

            _minioClient = new MinioClient()
                .WithEndpoint(_minioOptions.Endpoint)
                .WithCredentials(_minioOptions.AccessKey, _minioOptions.SecretKey)
                .Build();

            _bucketName = minioOptions.BucketName;
            _logger = Log.Logger;
        }
        public MinioOptions Options => _minioOptions;
        public UploadResult SaveAsync(Stream mediaBinaryStream, string key, string mimeType)
        {
            _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(key)
                .WithStreamData(mediaBinaryStream)
                .WithObjectSize(mediaBinaryStream.Length)
                .WithContentType(mimeType));

            var result = new UploadResult
            {
                Key = key,
                Size = mediaBinaryStream.Length,
                ContentType = mimeType
            };
            return result;
        }

        public async Task DeleteAsync(bool isDeleteMedia = false, params string[] keys)
        {
            foreach (var key in keys)
            {
                await _minioClient.RemoveObjectAsync(new RemoveObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(key));
            }
        }

        public Stream GetObject(string key)
        {
            var memoryStream = new MemoryStream();
            _minioClient.GetObjectAsync(new GetObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(key)
                .WithCallbackStream(async (stream) =>
                {
                    await stream.CopyToAsync(memoryStream);
                })).Wait();

            memoryStream.Position = 0;
            return memoryStream;
        }

        public async Task MoveAsync(string key, string newKey, bool isCopy = false)
        {
            if (isCopy)
            {
                var copyArgs = new CopyObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(newKey).WithCopyObjectSource(
                new CopySourceObjectArgs().WithBucket(_bucketName).WithObject(key)
            );
                await _minioClient.CopyObjectAsync(new CopyObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(newKey)
                    .WithCopyObjectSource(new CopySourceObjectArgs().WithBucket(_bucketName).WithObject(key))
                    );
            }
            else
            {
                await _minioClient.CopyObjectAsync(new CopyObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(newKey)
                    .WithCopyObjectSource(new CopySourceObjectArgs().WithBucket(_bucketName).WithObject(key))
                    );
                await DeleteAsync(false, key);
            }
        }

        public async Task<bool> ExistsAsync(string key)
        {
            try
            {
                await _minioClient.StatObjectAsync(new StatObjectArgs()
                    .WithBucket(_bucketName)
                    .WithObject(key));
                return true;
            }
            catch (Minio.Exceptions.MinioException)
            {
                return false;
            }
        }

        public void Overwrite(Stream mediaBinaryStream, string key, string mimeType)
        {
            SaveAsync(mediaBinaryStream, key, mimeType);
        }




    }


}