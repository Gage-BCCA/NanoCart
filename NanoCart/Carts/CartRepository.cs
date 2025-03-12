using System.Collections;
using Dapper;
using NanoCart.Carts.Interfaces;
using NanoCart.Carts.Requests;
using NanoCart.Data;
using NanoCart.Entities;

namespace NanoCart.Carts;

public class CartRepository : ICartRepository
{
    private readonly DatabaseContext _context;

    public CartRepository(DatabaseContext context)
    {
        this._context = context;
    }

    public async Task<Cart> GetCart(long id)
    {
        var sql = """
                  SELECT    id as Id,
                            creation_date as CartCreationDate,
                            expiration_date as CartExpirationDate,
                            last_modified_date as CartLastModifiedDate,
                            last_accessed_date as CartLastAccessedDate
                    FROM    carts
                   WHERE    id = @id
                  """;

        using var conn = _context.CreateConnection();
        return await conn.QuerySingleAsync<Cart>(sql, new { id = id });
    }

    public async Task AddItemsToCart(long cartId, long productId)
    {
        var sql = """
                  INSERT INTO carts_to_items (cart_id, product_id)
                  VALUES (@cartId, @productId);
                  """;
        
        using var conn = _context.CreateConnection();
        await conn.ExecuteAsync(sql, new { cartId = cartId, productId = productId });
    }

    public async Task RemoveItemFromCart(long cartId, long productId)
    {
        var sql = """
                  DELETE FROM carts_to_items WHERE cart_id = @id 
                  AND product_id = @productId
                  """;
        using var conn = _context.CreateConnection();
        await conn.ExecuteAsync(sql, new { cartId = cartId, productId = productId });
    }

    public async Task FlushCart(long cartId)
    {
        var sql = """
                  DELETE FROM carts_to_items 
                   WHERE cart_id = @id
                  """;
        using var conn = _context.CreateConnection();
        await conn.ExecuteAsync(sql, new { cartId = cartId });
    }

    public async Task<Cart> CreateCart()
    {
        Cart cart = new Cart()
        {
            CartCreationDate = DateTime.Now.ToUniversalTime(),
            CartExpirationDate = DateTime.Now.ToUniversalTime(),
            CartLastModifiedDate = DateTime.Now.ToUniversalTime(),
            CartLastAccessedDate = DateTime.Now.ToUniversalTime(),
        };
        
        var insertSql = """
                  INSERT INTO carts (creation_date, 
                                     expiration_date, 
                                     last_modified_date,
                                     last_accessed_date)
                  VALUES (@CreationDate, 
                          @ExpirationDate, 
                          @LastModifiedDate,
                          @LastAccessedDate)
                  """;
        using var conn = _context.CreateConnection();
        await conn.ExecuteAsync(insertSql, new
        {
            CreationDate = cart.CartCreationDate,
            ExpirationDate = cart.CartExpirationDate,
            LastModifiedDate = cart.CartLastModifiedDate,
            LastAccessedDate = cart.CartLastAccessedDate
        });

        var getInsertedRecordSql = """
                                   SELECT id as Id,
                                          creation_date as CartCreationDate,
                                          expiration_date as CartExpirationDate,
                                          last_modified_date as CartLastModifiedDate,
                                          last_accessed_date as CartLastAccessedDate
                                   FROM carts
                                   ORDER BY id DESC
                                   """;
        Cart targetCart = await conn.QueryFirstAsync<Cart>(getInsertedRecordSql);
        targetCart.CartItems = new ArrayList();
        return targetCart;
    }

    public async Task DeleteCart(long cartId)
    {
        var sql = """
                  DELETE FROM carts WHERE cart_id = @id
                  """;
        using var conn = _context.CreateConnection();
        await conn.ExecuteAsync(sql, new { cartId = cartId });
    }
}