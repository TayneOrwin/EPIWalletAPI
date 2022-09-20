﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
    public interface IEmployeeAddressRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<IEnumerable<EmployeeAddress>> Search(string name);
        Task<bool> SaveChangesAsync();
        Task<EmployeeAddress[]> getAllEmployeeAddress();
        Task<EmployeeAddress> getEmployeeAddress(int id);

    }
}
