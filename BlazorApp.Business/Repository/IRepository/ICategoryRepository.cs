using BlazorApp.Models;

namespace BlazorApp.Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<CategoryDTO> GetById(int id);
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> Create(CategoryDTO categoryDto);
        Task<CategoryDTO> Update(CategoryDTO categoryDto);
        Task<int> Delete(int id);
    }
}
