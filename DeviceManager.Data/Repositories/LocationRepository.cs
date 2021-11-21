﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Core.Models;
using DeviceManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private DeviceManagerContext DeviceManagerContext => Context as DeviceManagerContext;

        public LocationRepository(DeviceManagerContext context) : base(context)
        {
        }

        public async Task<Location> GetByIdAsync(Guid userId, string locationName)
        {
            return await DeviceManagerContext.Locations
                .SingleOrDefaultAsync(l => l.UserId == userId && l.Name == locationName);
        }

        public async Task<IEnumerable<Location>> GetAllAsync(Guid userId)
        {
            return await DeviceManagerContext.Locations
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }


        public async Task<IEnumerable<Location>> GetAllWithDevicesAsync(Guid? userId = null)
        {
            var include = DeviceManagerContext.Locations
                .Include(l => l.Devices);

            if (userId is null)
            {
                return await include.ToListAsync();
            }

            return await include
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<Location> GetWithDevicesByIdAsync(Guid userId, string locationName)
        {
            return await DeviceManagerContext.Locations
                .Include(l => l.Devices)
                .SingleOrDefaultAsync(l => l.UserId == userId && l.Name == locationName);
        }
    }
}