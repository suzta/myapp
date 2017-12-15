using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelapp.models
{
    public class ItemResponse<T> : SuccessResponse
    {

        public T Item { get; set; }

    }
}
