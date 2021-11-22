﻿using DeviceManager.Core.Proto;
using FluentValidation;

namespace DeviceManager.Api.Validators
{
    public class GetAllDevicesRequestValidator : AbstractValidator<GetAllDevicesRequest>
    {
        public GetAllDevicesRequestValidator()
        {
            RuleFor(r => r.UserId)
                .MustBeValidGuid()
                .Unless(r => string.IsNullOrWhiteSpace(r.UserId));
        }
    }
}