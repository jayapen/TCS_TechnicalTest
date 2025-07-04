using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcsTest.Utilities.Helpers.Interfaces
{
    public interface IJsonFileHelper
    {
        Task<List<T>> ReadAsync<T>(string filePath);
        Task WriteAsync<T>(string filePath, IEnumerable<T> items);
    }
}
