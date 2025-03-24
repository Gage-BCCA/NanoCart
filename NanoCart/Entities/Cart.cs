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
    
}