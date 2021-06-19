using SwiftTraders.ApplicationCore.DTOs;
using SwiftTraders.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.ApplicationCore.Interfaces.Services
{
    public interface IAdvertService
    {
        Task<AdvertDTO> GetAdvert(string id);
        Task<IEnumerable<AdvertDTO>> GetAllAds(int count = 20);
        Task<string> AddAdvert(AdvertDTO ad);
        Task RemoveAdvert(string id);
    }
}
