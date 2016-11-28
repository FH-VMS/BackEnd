using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductModel:BaseModel
    {
        
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
