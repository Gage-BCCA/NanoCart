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
            DROP TABLE IF EXISTS companies;
            DROP TABLE IF EXISTS carts;
            DROP TABLE IF EXISTS carts_to_items;

            CREATE TABLE companies (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL
            );

            CREATE TABLE carts (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                company_id INTEGER NOT NULL,
                creation_date DATETIME NOT NULL,
                expiration_date DATETIME NOT NULL,
                last_modified_date DATETIME NOT NULL
                
            );

            CREATE TABLE carts_to_items (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                cart_id INTEGER NOT NULL,
                product_id INTEGER NOT NULL
            );
            ";

        using var connection = this.CreateConnection();
        await connection.ExecuteAsync(sql);
        
    }
}