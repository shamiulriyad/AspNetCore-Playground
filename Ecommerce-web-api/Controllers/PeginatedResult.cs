using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asp_net_ecommerce_web_api.Models;
namespace asp_net_ecommerce_web_api.Controllers
{
    public  class PeginatedResult<T>
    
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }

        public int pageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages 
        { 
            get
            {
                return (int)Math.Ceiling((double)TotalCount / PageSize);
            }
        }
        
    }
}