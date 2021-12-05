﻿using FluentValidation;
using Shared.Extensions;
using Shared.Proto.Location;

namespace DeviceManager.Api.Validation.LocationRequests
{
    public class UpdateLocationRequestValidator : AbstractValidator<UpdateLocationRequest>
    {
        public UpdateLocationRequestValidator()
        {
            RuleFor(r => r.UserId)
                .NotEmpty()
                .Guid();
        }
    }
}