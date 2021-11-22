﻿using System;
using System.Threading.Tasks;
using DeviceManager.Core.Repositories;

namespace DeviceManager.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDeviceRepository Devices { get; }
        ILocationRepository Locations { get; }
        ISensorRepository Sensors { get; }
        ISensorTypeRepository SensorTypes { get; }

        Task<int> CommitAsync();
    }
}