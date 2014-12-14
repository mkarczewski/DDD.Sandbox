using DDD.Sandbox.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.CrossCutting
{
    public interface ICanBrowseDictionaries
    {
        IDictionaryBrowser DictionaryBrowser { get; set; }
    }
}
