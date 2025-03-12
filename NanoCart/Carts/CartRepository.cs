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
        var sql = """
                  SELECT * 
                  FROM carts
                  WHERE id = @id
                  """;

        using var conn = context.CreateConnection();
        return await conn.QuerySingleAsync<Cart>(sql, new { id = request.Id });
    }

    public async Task AddItemsToCart(long cartId, long productId)
    {
        var sql = """
                  INSERT INTO carts_to_items (cart_id, product_id)
                  VALUES (@cartId, @productId);
                  """;
        
        using var conn = context.CreateConnection();
        await conn.ExecuteAsync(sql, new { cartId = cartId, productId = productId });
    }

    public async Task RemoveItemFromCart(long cartId, long productId)
    {
        var sql = """
                  DELETE FROM carts_to_items WHERE cart_id = @id 
                  AND product_id = @productId
                  """;
        using var conn = context.CreateConnection();
        await conn.ExecuteAsync(sql, new { cartId = cartId, productId = productId });
    }

    public async Task FlushCart(long cartId)
    {
        var sql = """
                  DELETE FROM carts_to_items WHERE cart_id = @id
                  """;
        using var conn = context.CreateConnection();
        await conn.ExecuteAsync(sql, new { cartId = cartId });
    }

    public async Task<long> CreateCart(Cart cart)
    {
        var insertSql = """
                  INSERT INTO carts (creation_date, 
                                     expiration_date, 
                                     last_modified_date,
                                     last_accessed_date)
                  VALUES (@cart.CreationDate, 
                          @cart.ExpirationDate, 
                          @cart.LastModifiedDate,
                          @cart.LastAccessedDate)
                  """;
        using var conn = context.CreateConnection();
        await conn.ExecuteAsync(insertSql, cart);

        var getInsertedRecordSql = """
                                   SELECT * 
                                   FROM carts
                                   ORDER BY id DESC
                                   """;
        Cart targetCart = await conn.QueryFirstAsync<Cart>(getInsertedRecordSql);
        return targetCart.Id;
    }

    public async Task DeleteCart(long cartId)
    {
        var sql = """
                  DELETE FROM carts WHERE cart_id = @id
                  """;
        using var conn = context.CreateConnection();
        await conn.ExecuteAsync(sql, new { cartId = cartId });
    }
}