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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly string[] includes = new string[] {  };

        public CategoryService(IUnitOfWork unitOfWork )
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddCategory(CategoryDTO model)
        {
            var cate = new Category
            {
                CategoryName = model.CategoryName,
                Description = model.Description,
                ImgUrl = model.ImgUrl,
                

            };

            await unitOfWork.Categories.Add(cate);
            await unitOfWork.Complete();

            return cate.Id;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories(int count = 20)
        {
            var cate = await unitOfWork.Categories.GetAll(includes);
            return cate.Select(c => Map(c)).ToList();
        }

        public async Task<CategoryDTO> GetCategory(string id)
        {
            return Map(await unitOfWork.Categories.Get(c => c.Id == id, includes));
        }

        public async Task RemoveCategory(string id)
        {
            var cate = await unitOfWork.Categories.Find(id);
            unitOfWork.Categories.Remove(cate);
            await unitOfWork.Complete();
        }

        private static CategoryDTO Map(Category model)
        {
            return new CategoryDTO
            {
                CatId = model.Id,
                CategoryName = model.CategoryName,
                ImgUrl = model.ImgUrl,
                Description = model.Description,

            };
        }
    }
}
