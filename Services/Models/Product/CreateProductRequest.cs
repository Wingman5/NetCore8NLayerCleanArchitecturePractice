namespace App.Services.Models.Product
{
    public record CreateProductRequest(string Name, decimal Price, int Stock);
}
