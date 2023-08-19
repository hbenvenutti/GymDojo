namespace GymAPI.Services.Interfaces;

public interface IModelService<Type, CreateDto, UpdateDto, IReadDto, ReadDto>
{
    Task<IReadDto> CreateAsync(CreateDto createDto);
    Task<IReadDto> GetByIdAsync(int id);
    ICollection<ReadDto> List();
    Task<IReadDto> UpdateAsync(int id, UpdateDto updateDto);
    Task DeleteByIdAsync(int id);
}
