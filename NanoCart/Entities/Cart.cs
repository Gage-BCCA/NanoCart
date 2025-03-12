using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace NanoCart.Entities;

public class Cart
{
    public long Id { get; set; }
    public DateTime CartCreationDate { get; set;  }
    public DateTime CartExpirationDate { get; set; }
    public DateTime CartLastModifiedDate { get; set; }
    public DateTime CartLastAccessedDate { get; set; }
    public ArrayList CartItems { get; set; } = new ArrayList();

    public Cart()
    {
        
    }
    
    // public Cart(DateTime currentTime)
    // {
    //     CartCreationDate = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
    //     CartExpirationDate = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
    //     CartLastModifiedDate = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
    //     CartLastAccessedDate = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
    // }
    
}