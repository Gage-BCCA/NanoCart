namespace NanoCart.Carts.Requests;

public class RemoveItemRequest
{
    public readonly long CartId;
    public readonly long ProductId;

    public RemoveItemRequest()
    {
        
    }
}