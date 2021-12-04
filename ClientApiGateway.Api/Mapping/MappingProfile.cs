﻿using AutoMapper;
using ClientApiGateway.Api.Resources.Device;
using ClientApiGateway.Api.Resources.Group;
using ClientApiGateway.Api.Resources.Location;
using ClientApiGateway.Api.Resources.Sensor;
using ClientApiGateway.Api.Resources.SensorType;
using ClientApiGateway.Api.Resources.User;
using DeviceManager.Core.Proto;
using UserIdentity.Core.Proto;

namespace ClientApiGateway.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // device
            CreateMap<CreateDeviceResource, CreateDeviceRequest>();
            CreateMap<UpdateDeviceResource, UpdateDeviceRequest>();

            // location
            CreateMap<CreateLocationResource, CreateLocationRequest>();
            CreateMap<LocationDto, GetLocationResource>();
            CreateMap<LocationExtendedDto, GetLocationResource>();
            CreateMap<UpdateLocationResource, UpdateLocationRequest>();

            // sensor
            CreateMap<SaveSensorResource, CreateSensorRequest>();
            CreateMap<SaveSensorResource, UpdateSensorRequest>();

            // sensor type
            CreateMap<UpdateSensorTypeResource, UpdateSensorTypeRequest>();

            // user
            CreateMap<UpdateUserDetailsResource, UpdateUserDetailsRequest>();

            //group 
            CreateMap<CreateGroupResource, CreateGroupRequest>();
            CreateMap<UpdateGroupResource, UpdateGroupRequest>();
        }
    }
}