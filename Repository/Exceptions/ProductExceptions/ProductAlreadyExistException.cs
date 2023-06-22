namespace Repository.Exceptions.ProductExceptions;

public sealed class ProductAlreadyExistException : Exception
{
    public ProductAlreadyExistException(string message) : base(message)
    {
    }
}
