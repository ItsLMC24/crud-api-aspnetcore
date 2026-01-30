namespace CRUD_API.DTOs;

public record UserCreateDto(string FullName, string Email);
public record UserUpdateDto(string FullName, string Email);
public record UserReadDto(int Id, string FullName, string Email);
