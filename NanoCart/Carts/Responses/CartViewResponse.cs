using System.Collections;

namespace NanoCart.Carts.Responses;

public class CartViewResponse
{
    private string _cartId;
    private DateTime _cartExpirationDate;
    private DateTime _cartCreatedDate;
    private DateTime _cartLastModifiedDate;
    private int _cartQuantity;
    private ArrayList _cartItems;
}