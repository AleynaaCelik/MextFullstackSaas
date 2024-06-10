using MextFullStackSaas.Application.Common.Interfaces;

namespace MextFullStackSaas.WebApi.Services
{
    public class RootPathManager : IRoothPathService
    {
        private readonly string _rootPath;

        public RootPathManager(string rootPath)
        {
            _rootPath = rootPath;
        }

        public string GetRoothPath()=>_rootPath;
        
    }
}
