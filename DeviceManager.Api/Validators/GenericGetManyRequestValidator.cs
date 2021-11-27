﻿using DeviceManager.Core.Proto;
using FluentValidation;

namespace DeviceManager.Api.Validators
{
    public class GenericGetManyRequestValidator : AbstractValidator<GenericGetManyRequest>
    {
        public GenericGetManyRequestValidator()
        {
            RuleFor(r => r.Parameters)
                .SetValidator(new GetRequestParametersValidator());

            RuleFor(r => r.PageSize)
                .GreaterThan(0);

            RuleFor(r => r.PageNumber)
                .GreaterThanOrEqualTo(1);
        }
    }
}