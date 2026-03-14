 using ProductSystem.BLL.ViewModels;

namespace ProductSystem.BLL
{
    public interface ICategoryManager
    {
        Task<IEnumerable<CategoryListDTO>> GetDepartments();
        Task<CategoryDetailsDTO> GetCategoryById(int id);
        Task AddCategoryAsync(CategoryFormDTO vm); 
        Task Update(CategoryFormDTO vm); 
        Task Delete(int id);
    }
}