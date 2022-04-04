using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IScanner
    {
        Task<string> ScanAsync();
    }
}
