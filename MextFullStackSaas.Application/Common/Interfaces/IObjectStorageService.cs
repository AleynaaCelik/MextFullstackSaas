using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public interface IObjectStorageService
    {
        Task<string> UploadImageAsync(string imageData, CancellationToken cancellationToken);
        Task<List<string>> UploadImagesAsync(List<string> imageDatas, CancellationToken cancellationToken);

        Task<bool> RemoveAsync(string key, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(List<string> keys, CancellationToken cancellationToken);

    }
}
