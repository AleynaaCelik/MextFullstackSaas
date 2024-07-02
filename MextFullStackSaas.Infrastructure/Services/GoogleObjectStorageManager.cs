using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullStackSaas.Infrastructure.Services
{
    public class GoogleObjectStorageManager : IObjectStorageService
    {
        private const string BucketName = "iconbuilderai-icon-us-aleyna";
        private readonly GoogleCredential _credential;

        public GoogleObjectStorageManager()
        {
            _credential = GoogleCredential.FromFile("C:\\Users\\DELL\\Desktop\\Storage\\capable-country-428107-i0-1b2aa5c59930.json");
        }

        public async Task<bool> RemoveAsync(string key, CancellationToken cancellationToken)
        {
            try
            {
                // Create a new Google Cloud Storage client
                using var storage = await StorageClient.CreateAsync(_credential);

                // Delete the file from Google Cloud Storage
                await storage.DeleteObjectAsync(BucketName, key, cancellationToken: cancellationToken);

                return true;
            }
            catch (Google.GoogleApiException e) when (e.HttpStatusCode == HttpStatusCode.NotFound)
            {
                // Object doesn't exist, which could be considered a successful deletion
                return true;
            }
            catch (Exception)
            {
                // Handle or log other exceptions as needed
                return false;
            }
        }

        public async  Task<bool> RemoveAsync(List<string> keys, CancellationToken cancellationToken)
        {
            using var storage = await StorageClient.CreateAsync(_credential);

            var deleteTasks = keys.Select(key => storage.DeleteObjectAsync(BucketName, key, cancellationToken: cancellationToken));

            await Task.WhenAll(deleteTasks);

            return true;
        }

        public async Task<string> UploadImageAsync(string imageData, CancellationToken cancellationToken)
        {
            // Convert the base64 string to byte array
            var imageBytes = Convert.FromBase64String(imageData);

            // Create a new MemoryStream
            using var imageStream = new MemoryStream(imageBytes);

            // Create a new Google Cloud Storage client
            var storage = await StorageClient.CreateAsync(_credential);

            // Generate a unique filename
            string fileName = $"{Guid.NewGuid()}.jpg";

            // Upload the file to Google Cloud Storage
            var uploadedObject = await storage.UploadObjectAsync(
                BucketName,
                fileName,
                "image/jpeg",
                imageStream,
                cancellationToken: cancellationToken);

            // Return the public URL of the uploaded image
            return $"https://storage.googleapis.com/{BucketName}/{fileName}";
        }

        public async Task<List<string>> UploadImagesAsync(List<string> imageDatas, CancellationToken cancellationToken)
        {
            var uploadTasks = imageDatas.Select(imageData => UploadImageAsync(imageData, cancellationToken));
            var results = await Task.WhenAll(uploadTasks);
            return results.ToList();
        }
    }
}
