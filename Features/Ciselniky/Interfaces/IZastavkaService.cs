// File: Interfaces/IZastavkaService.cs
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Models.Entities;
using DHL.Server.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DHL.Server.Features.Ciselniky.Interfaces
{
    public interface IZastavkaService
    {
        Task<List<ZastavkaDto>> GetAllAsync();
        Task<ZastavkaDto?> GetByIdAsync(int id);
        Task<ZastavkaDto> CreateAsync(ZastavkaDto dto);
        Task<ZastavkaDto?> UpdateAsync(int id, ZastavkaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}