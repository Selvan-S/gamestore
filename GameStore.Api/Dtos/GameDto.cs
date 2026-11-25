namespace GameStore.Api.Dtos;

// A DTO (Data Transfer Object) is a simple object that is used to transfer data between layers of an application. In this case, the GameDto class is likely used to represent a game in the GameStore API. It may contain properties such as the game's title, description, price, and other relevant information. The record class syntax indicates that this class is immutable and provides value-based equality comparisons. (This is by AI)

// A DTO is a contract between the client and server since it represents 
// a shared agreement about how data will be transferred and used.
public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
