using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace NanoCart.Entities;

public class Cart
{
    private readonly string _cartSecret;
    private readonly long _cartId;
    private readonly int _companyId;
    private readonly DateTime _cartCreationDate;
    
    private DateTime _cartExpirationDate;
    private DateTime _cartLastModifiedDate;
    private DateTime _cartLastAccessedDate;
    private ArrayList _cartItems;

    public string Secret => _cartSecret;
    public long Id => _cartId;
    public int CompanyId => _companyId;
    public DateTime CartCreationDate => _cartCreationDate;
    public DateTime CartExpirationDate => _cartExpirationDate;
    public DateTime CartLastModifiedDate => _cartLastModifiedDate;
    public DateTime CartLastAccessedDate => _cartLastAccessedDate;
    public ArrayList CartItems => _cartItems;
    
    
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
    
    public bool CompareSecret(string cartSecret)
    {
        return _cartSecret == cartSecret;
    }
}