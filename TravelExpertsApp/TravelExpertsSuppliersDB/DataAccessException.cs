namespace TravelExpertsSuppliersDB;

public class DataAccessException : Exception // Adds type handling to Exceptions
{
    public DataAccessException(string msg, string type) : base(msg) =>
        ErrorType = type;

    public string ErrorType { get; init; }

    public bool IsConcurrencyError => // Return true if its a concurrency error
        ErrorType.ToLower().Contains("concurrency");
}
