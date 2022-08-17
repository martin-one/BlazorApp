using BlazorApp.Models;

namespace BlazorApp.Business.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<ProductDTO> GetById(int id);
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> Create(ProductDTO productDto);
        Task<ProductDTO> Update(ProductDTO productDto);
        Task<int> Delete(int id);
    }
}
