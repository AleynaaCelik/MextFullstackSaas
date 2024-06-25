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
    public class OpenAIManager : IOpenAIService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly OpenAI.Interfaces.IOpenAIService _openAiService;

        public OpenAIManager(ICurrentUserService currentUserService, OpenAI.Interfaces.IOpenAIService openAiService)
        {
            _currentUserService = currentUserService;
            _openAiService = openAiService;
        }

        public async Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken)
        {
            var imageResult = await _openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = CreateIconPrompt(requestDto),
                N = requestDto.Model==AIModelType.DallE3?1 :requestDto.Quantity,
                Size = GetSize(requestDto.Size),
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = _currentUserService.UserId.ToString(),
                Model = Models.Dall_e_3
            }, cancellationToken);
            // TODO: Add error handling / If the model is Dall-e-3, Image size must be at least 1024
            if (!imageResult.Successful)
            {

            }

            return imageResult
                .Results
                .Select(x => x.Url)
                .ToList();
        }
        private string GetSize(IconSize size)
            {
            return size switch
            {
                IconSize.Small => StaticValues.ImageStatics.Size.Size256,
                IconSize.Medium => StaticValues.ImageStatics.Size.Size512,
                IconSize.Large => StaticValues.ImageStatics.Size.Size1024,
                _ => StaticValues.ImageStatics.Size.Size256
            };
        }
        private string CreateIconPrompt(DallECreateIconRequestDto request)
        {
            var promptBuilder = new StringBuilder();

            promptBuilder.Append(
             $"You're a World-class Icon Designer AI, Please generate an icon for a mobile app.Make sure  the Icon is fit  the full width and height .  Generate icon with the following specifications below. I'll tip you 1000$ for your work, if I like it.");

            promptBuilder.Append(
                "$<DesignType>{request.DesignType}</DesignType>"
                );
            promptBuilder.Append(
                "$<Colour>{request.ColourCode}<Colour>"
                );
            promptBuilder.Append(
               "$<Shape>{request.Shape}<Shape>"
               );
            promptBuilder.Append(
              "$<Description>{request.Description}<Description>"
              );
            promptBuilder.Append(
                $"Design Type: {request.DesignType}, Colour Code (Hex Code): {request.ColourCode}, Shape: {request.Shape}, Description:{request.Description} ");

            

            return promptBuilder.ToString();
        }

    }
}
