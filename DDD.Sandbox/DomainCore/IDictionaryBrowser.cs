using DDD.Sandbox.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.DomainCore
{
    public interface IDictionaryBrowser
    {
        TDict Find<TDict>(long id) where TDict : DictionaryItem;
        DictionaryItemDTO FindDTO<TDict>(long id) where TDict : DictionaryItem;
        DictionaryItemDTO ConvertToDTO<TDict>(TDict item) where TDict : DictionaryItem;
    }
}
