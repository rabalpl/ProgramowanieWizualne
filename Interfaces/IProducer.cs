using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabalski.HeadphoneCatalog.Interfaces
{
    public interface IProducer
    {
        string Name { get; set; }
        string Country { get; set; }

    }
}
