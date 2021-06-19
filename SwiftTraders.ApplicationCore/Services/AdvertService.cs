using SwiftTraders.ApplicationCore.DTOs;
using SwiftTraders.ApplicationCore.Entities;
using SwiftTraders.ApplicationCore.Interfaces.Repositories;
using SwiftTraders.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.ApplicationCore.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly string[] includes = new string[] { };

        public AdvertService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddAdvert(AdvertDTO ad)
        {
            var ads = new AdvertModel
            {
                SwiftTraderAdVert = ad.SwiftTraderAdVert
            };

            await unitOfWork.Adverts.Add(ads);
            await unitOfWork.Complete();

            return ads.Id;

        }

        public async Task<AdvertDTO> GetAdvert(string id)
        {
            return Map(await unitOfWork.Adverts.Get(a => a.Id == id, includes));
        }

        public async Task<IEnumerable<AdvertDTO>> GetAllAds(int count = 20)
        {
            var ad = await unitOfWork.Adverts.GetAll(includes);
            return ad.Select(a => Map(a)).ToList();
        }

        public async Task RemoveAdvert(string id)
        {
            var ad = await unitOfWork.Adverts.Find(id);
            unitOfWork.Adverts.Remove(ad);
            await unitOfWork.Complete();
        }

        private static AdvertDTO Map(AdvertModel model)
        {
            return new AdvertDTO
            {
                Id = model.Id,
                SwiftTraderAdVert = model.SwiftTraderAdVert
            };
        }
    }
}
