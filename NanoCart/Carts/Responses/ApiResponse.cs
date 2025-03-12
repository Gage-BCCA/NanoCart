using System.Collections;
using NanoCart.Carts.DTOs;

namespace NanoCart.Carts.Responses;

public class ApiResponse
{
    public Boolean IsSuccess { get; set; }
    public CartDTO Cart { get; set; }
    public string ErrorMessage { get; set; }

    public ApiResponse(String errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
        this.Cart = new CartDTO();
    }

    public ApiResponse(CartDTO cartDto)
    {
        this.IsSuccess = true;
        this.Cart = cartDto;
        this.ErrorMessage = string.Empty;
    }
}