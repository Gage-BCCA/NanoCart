namespace NanoCart.Carts.Requests;

public class AddItemRequest
{
    public long CartId { get; set; }
    public long ProductId { get; set; }

    public AddItemRequest()
    {
    }
}