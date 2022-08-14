using AutoMapper;
using BlazorApp.Business.Repository.IRepository;
using BlazorApp.DataAccess;
using BlazorApp.DataAccess.Data;
using BlazorApp.Models;

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

        public CategoryDTO GetById(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                return _mapper.Map<CategoryDTO>(category);
            }
            return new CategoryDTO();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var categories = _db.Categories.ToList();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public CategoryDTO Create(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.CreatedDate = DateTime.Now;

            _db.Categories.Add(category);
            _db.SaveChanges();

            return _mapper.Map<CategoryDTO>(category);
        }

        public CategoryDTO Update(CategoryDTO categoryDto)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == categoryDto.Id);
            if (category != null)
            {
                category.Name = categoryDto.Name;
                _db.Categories.Update(category);
                _db.SaveChanges();
                return _mapper.Map<CategoryDTO>(category);
            }
            return categoryDto;
        }

        public int Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                return _db.SaveChanges();
            }
            return 0;
        }
    }
}