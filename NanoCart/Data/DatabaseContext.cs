using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace NanoCart.Data;

public class DatabaseContext
{
    private IConfiguration _configuration;
    private readonly String _connectionString;
    private readonly String _startupMode;

    public DatabaseContext(IConfiguration configuration)
    {
        this._configuration = configuration;
        this._connectionString = this._configuration.GetConnectionString("DefaultConnection");
        this._startupMode = this._configuration.GetSection("StartupMode").Value;
    }
    
    public IDbConnection CreateConnection()
        => new SQLiteConnection(_connectionString);

    public async Task Init()
    {
       await _initializeDatabase();
    }

    private async Task _initializeDatabase()
    {
        var sql = @"
            DROP TABLE IF EXISTS carts;
            DROP TABLE IF EXISTS carts_to_items;

            CREATE TABLE carts (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                creation_date DATETIME NOT NULL,
                expiration_date DATETIME NOT NULL,
                last_modified_date DATETIME NOT NULL,
                last_accessed_date DATETIME NOT NULL
                
            );

            CREATE TABLE carts_to_items (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                cart_id INTEGER NOT NULL,
                product_id INTEGER NOT NULL,
                FOREIGN KEY (cart_id) REFERENCES carts(id) ON DELETE CASCADE
            );
            ";

        using var connection = this.CreateConnection();
        await connection.ExecuteAsync(sql);
        
    }
}