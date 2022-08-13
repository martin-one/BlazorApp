using BlazorApp.Models;

namespace BlazorApp.Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        CategoryDTO GetById(int id);
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO Create(CategoryDTO categoryDto);
        CategoryDTO Update(CategoryDTO categoryDto);
        int Delete(int id);
    }
}
