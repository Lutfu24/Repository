namespace Repository.Exceptions.ProductExceptions;

public sealed class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message) : base(message)
    {
    }
}
