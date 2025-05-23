﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels;
using TechStore.BLL.DtoModels.Ram;
using TechStore.Data.Entity;

namespace TechStore.BLL.Interfaces
{
    public interface IRamService
    {
        Task<IEnumerable<RamDto>> GetRams(CancellationToken token=default);
        Task<RamDto?> GetRamById(int ramId, CancellationToken token = default);
        Task<IEnumerable<RamDto>> GetRamsByCategoryId(int categoryId, CancellationToken token = default);
        Task<Result> AddRam(RamAddDto ramAddDto, CancellationToken token = default);
        Task<Result> UpdateRam(int ramId, RamUpdateDto ramUpdateDto, CancellationToken token = default);
        Task<Result> DeleteRam(int ramId, CancellationToken token = default);
    }
}