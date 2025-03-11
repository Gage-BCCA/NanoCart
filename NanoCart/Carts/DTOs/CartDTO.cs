using System.Collections;
using NanoCart.Entities;

namespace NanoCart.Carts.DTOs;

public class CartDTO
{
    public long CartId { get; set; }
    public DateTime CartExpirationDate { get; set; }
    public DateTime CartCreationDate { get; set; }
    public DateTime CartLastModifiedDate { get; set; }
    public int CartQuantity { get; set; }
    public ArrayList CartItems { get; set; }

    public CartDTO()
    {
    }

    public CartDTO(Cart cart)
    {
        this.CartId = cart.Id;
        this.CartExpirationDate = cart.CartExpirationDate;
        this.CartCreationDate = cart.CartCreationDate;
        this.CartLastModifiedDate = CartLastModifiedDate;
        this.CartItems = cart.CartItems;
        this.CartQuantity = this.CartItems.Count;
        
    }
}