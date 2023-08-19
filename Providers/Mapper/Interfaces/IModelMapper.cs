namespace GymAPI.Providers.Mapper.Interfaces;

public interface IModelMapper<Type, CreateDto, UpdateDto, IReadDto, ReadDto>
{
    Type ToModel(CreateDto createDto);

    Type ToModel(UpdateDto updateDto);

    Type ToExistentModel(UpdateDto updateDto, Type data);

    // ---------------------------------------------------------------------- //

    CreateDto ToCreateDto(UpdateDto updateDto);

    // ---------------------------------------------------------------------- //

    IReadDto ToReadDto(Type data);

    ICollection<ReadDto> ToReadDtoCollection(ICollection<Type> dataCollection);

    // ---------------------------------------------------------------------- //
    
    // Todo: Fix collection conversion problems to use read dto interface. 
}
