using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation.API
{
    public class APIMultiResponse<T>
    {
        public IEnumerable<T> Value { get; set; }
    }
}
