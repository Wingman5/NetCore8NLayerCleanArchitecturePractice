namespace App.Services.Models
{
    // The record automatically provides the properties with init accessors
    // so we don't need to define them explicitly here.
    // If you want to add custom logic or methods, you can do so within this record.
    public record ProductDto(int Id, string Name, decimal Price, int Stock);
 
    //public record ProductDto
    //{
    //    public int Id { get; init; }
    //    public string Name { get; init; } = default!;
    //    public decimal Price { get; init; }
    //    public int Stock { get; init; }
    //}
}
