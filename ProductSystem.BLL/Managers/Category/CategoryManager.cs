 using ProductSystem.BLL.ViewModels;
using ProductSystem.DAL;
using ProductSystem.DAL.Data.Context;
using System.Threading.Tasks;

namespace ProductSystem.BLL.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoryListDTO>> GetDepartments()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var categoryList =  categories.Select(c => new CategoryListDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
            return categoryList;
        }

        public async Task<CategoryDetailsDTO> GetCategoryById(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetByIdAsync(id).Result;

            if (category == null)
                return null;

            return new CategoryDetailsDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task AddCategoryAsync(CategoryFormDTO vm)
        {
            Category category = new Category
            {
                Name = vm.Name
            };

            _unitOfWork.CategoryRepository.Add(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(CategoryFormDTO vm)
        {
            var category =   _unitOfWork.CategoryRepository.GetByIdAsync(vm.Id).Result;

            if (category == null) return;

            category.Name = vm.Name;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category =   _unitOfWork.CategoryRepository.GetByIdAsync(id).Result;

            if (category == null) return;

            _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}