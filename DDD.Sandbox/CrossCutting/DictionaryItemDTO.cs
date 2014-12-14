using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.CrossCutting
{
    public struct DictionaryItemDTO
    {
        public long Id { get; set; }
        public string Display { get; set; }
        public Type DictionaryItemType { get; set; }
    }

}
