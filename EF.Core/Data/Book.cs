using System;

namespace EF.Core.Data
{
   public class Book : BaseEntity
    {
       public string Title { get; set; }
       public string Author { get; set; }
       public string ISBN { get; set; }
       public DateTime Published { get; set; }
    }
}
