﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceManager.Core.Models;

namespace DeviceManager.Core.Services
{
    public interface ISensorService
    {
        Task<IEnumerable<Sensor>> GetAllSensors(Guid? userId = null);
        Task<IEnumerable<Sensor>> GetAllSensorsWithType(Guid? userId = null);

        Task<Sensor> GetSensor(long sensorId);
        Task<Sensor> GetSensorWithType(long sensorId);

        Task<Sensor> CreateSensor(Sensor newSensor);
        Task UpdateSensor(Sensor sensorToBeUpdated, Sensor sensor);
        Task DeleteSensor(Sensor sensor);
    }
}