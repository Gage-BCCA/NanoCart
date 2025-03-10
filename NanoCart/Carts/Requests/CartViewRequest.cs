namespace NanoCart.Carts.Requests;

public class CartViewRequest
{
    private readonly int _id;
    private readonly string _secret;
    
    public int Id => _id;
    public string Secret => _secret;

    public CartViewRequest(int id, string secret)
    {
        this._id = id;
        this._secret = secret;
    }
}