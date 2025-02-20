﻿using FluentValidation;
using MextFullstackSaas.Domain.Common;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Translations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MextFullstackSaaS.WebApi.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly IStringLocalizer<CommonTranslations> _localizer;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);

            var response = new ResponseDto<string>();

            switch (context.Exception)
            {
                case ValidationException validationException:

                    var message = _localizer[CommonTranslationKeys.GeneralValidationExceptionMessage];

                    List<ErrorDto> errors = new List<ErrorDto>();

                    var propertyNames = validationException
                        .Errors
                        .Select(x => x.PropertyName)
                        .Distinct();

                    foreach (var propertyName in propertyNames)
                    {
                        var propertyFailures = validationException
                            .Errors
                            .Where(x => x.PropertyName == propertyName)
                            .Select(x => x.ErrorMessage)
                            .ToList();

                        errors.Add(new ErrorDto(propertyName, propertyFailures));
                    }

                    response.Message = message;

                    response.Errors = errors;

                    context.Result = new BadRequestObjectResult(response); // 400 response

                    break;

                default:

                    response.Message = _localizer[CommonTranslationKeys.GeneralServerExceptionMessage];

                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = (int)StatusCodes.Status500InternalServerError
                    };

                    break;
            }
        }
    }
}