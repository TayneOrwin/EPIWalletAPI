﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IVendorAddressRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<VendorAddress[]> getAllVendorAddressesAsync();
        Task<VendorAddress> getVendorAddress(string VendorName);
    }
}