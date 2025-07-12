namespace App.Services.Models.Product;
public record UpdateProductRequest(int Id, string Name, decimal Price, int Stock);

