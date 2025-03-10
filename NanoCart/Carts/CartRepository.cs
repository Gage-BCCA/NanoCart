using Dapper;
using NanoCart.Carts.Interfaces;
using NanoCart.Carts.Requests;
using NanoCart.Data;
using NanoCart.Entities;

namespace NanoCart.Carts;

public class CartRepository : ICartRepository
{
    private DatabaseContext context;

    public CartRepository(DatabaseContext context)
    {
        this.context = context;
    }

    public async Task<Cart> GetCart(CartViewRequest request)
    {
        var sql = @"
        SELECT * 
        FROM carts
        WHERE id = @id
        ";

        using var conn = context.CreateConnection();
        return await conn.QuerySingleAsync<Cart>(sql, new { id = request.Id });
    }
}