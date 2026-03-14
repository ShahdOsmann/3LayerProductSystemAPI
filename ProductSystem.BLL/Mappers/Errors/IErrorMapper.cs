using FluentValidation.Results;
using ProductSystem.Common;

namespace ProductSystem.BLL.Mappers
{
    public interface IErrorMapper
    {
        Dictionary<string, List<Errors>> MapError(ValidationResult validationResult);
    }
}
