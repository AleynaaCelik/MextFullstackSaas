using MextFullStackSaas.Application.Common.Models.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public interface IOpenAIServices
    {
        Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken);


    }
}
