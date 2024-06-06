using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models.OpenAI;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MextFullstackSaas.Domain.Enums;

namespace MextFullStackSaas.Infrastructure.Services
{
    public class OpenAIManager : IOpenAIServices
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly OpenAI.Interfaces.IOpenAIService _openAiService;
        public async Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken)
        {
            var imageResult = await _openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = "Laser cat eyes",
                N = requestDto.Quantity,
                Size = GetSize(requestDto.Size),
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = _currentUserService.UserId.ToString()
            }, cancellationToken);;
            return imageResult.Results.Select(x => x.Url).ToList();
        }
        private string GetSize(IconSize size)
            {
            return size switch
            {
                IconSize.Small => StaticValues.ImageStatics.Size.Size256,
                IconSize.Medium => StaticValues.ImageStatics.Size.Size512,
                IconSize.Large => StaticValues.ImageStatics.Size.Size1024,
                _=>StaticValues.ImageStatics.Size.Size256
            } ;
}
    }
}
