﻿using DeviceManager.Core.Proto;
using MediatR;

namespace DeviceManager.Api.Queries
{
    public class GetDeviceQuery : IRequest<DeviceDtoExtended>
    {
        public GenericGetRequest QueryParameters { get; }

        public GetDeviceQuery(GenericGetRequest queryParameters)
        {
            QueryParameters = queryParameters;
        }
    }
}