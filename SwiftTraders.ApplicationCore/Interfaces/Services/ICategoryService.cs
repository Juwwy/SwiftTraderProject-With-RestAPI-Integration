using SwiftTraders.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.ApplicationCore.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategory(string id);
        Task<IEnumerable<CategoryDTO>> GetAllCategories(int count = 20);
        Task<string> AddCategory(CategoryDTO category);
        Task RemoveCategory(string id);
    }
}
