using System.Collections;

namespace NanoCart.Entities;

public class Cart
{
    private readonly string _cartSecret;

    public Cart(string cartSecret, long cartId, int companyId, DateTime cartCreationDate,
        DateTime cartExpirationDate, DateTime cartLastModifiedDate, ArrayList cartItems)
    {
        _cartSecret = cartSecret;
        _cartId = cartId;
        _companyId = companyId;
        _cartCreationDate = cartCreationDate;
        _cartExpirationDate = cartExpirationDate;
        _cartLastModifiedDate = cartLastModifiedDate;
        _cartItems = cartItems;
    }

    public Cart()
    {
    }

    private readonly long _cartId;
    private readonly int _companyId;
    private readonly DateTime _cartCreationDate;
    private DateTime _cartExpirationDate;
    private DateTime _cartLastModifiedDate;
    private DateTime _cartLastAccessedDate;
    private ArrayList _cartItems;

    public bool compareSecret(string cartSecret)
    {
        return _cartSecret == cartSecret;
    }
}