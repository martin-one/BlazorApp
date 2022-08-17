using AutoMapper;
using BlazorApp.Business.Repository.IRepository;
using BlazorApp.DataAccess;
using BlazorApp.DataAccess.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Business.Repository
{
    public class ProductRepositor : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepositor(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var product = await _db.Products.Include(u => u.Category).FirstOrDefaultAsync(c => c.Id == id);
            if (product != null)
            {
                return _mapper.Map<ProductDTO>(product);
            }
            return new ProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var product = _db.Products.Include(u => u.Category);
            return _mapper.Map<IEnumerable<ProductDTO>>(product);
        }

        public async Task<ProductDTO> Create(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Update(ProductDTO productDto)
        {
            var product = await _db.Products.FirstOrDefaultAsync(c => c.Id == productDto.Id);
            if (product != null)
            {
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.ShopFavorites = productDto.ShopFavorites;
                product.CustomerFavorites = productDto.CustomerFavorites;
                product.Color = productDto.Color;
                product.ImageUrl = productDto.ImageUrl;
                product.CategoryId = productDto.CategoryId;
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return _mapper.Map<ProductDTO>(product);
            }
            return productDto;
        }

        public async Task<int> Delete(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (product != null)
            {
                _db.Products.Remove(product);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
    }
}