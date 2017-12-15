using System.Collections.Generic;

namespace travelapp.models
{
    public class ItemsResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}
