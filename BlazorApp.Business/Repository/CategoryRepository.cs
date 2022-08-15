using AutoMapper;
using BlazorApp.Business.Repository.IRepository;
using BlazorApp.DataAccess;
using BlazorApp.DataAccess.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                return _mapper.Map<CategoryDTO>(category);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories = _db.Categories;
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> Create(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.CreatedDate = DateTime.Now;

            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDto)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == categoryDto.Id);
            if (category != null)
            {
                category.Name = categoryDto.Name;
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
                return _mapper.Map<CategoryDTO>(category);
            }
            return categoryDto;
        }

        public async Task<int> Delete(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
    }
}