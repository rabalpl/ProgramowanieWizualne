using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rabalski.HeadphoneCatalog.Core;

namespace Rabalski.HeadphoneCatalog.Interfaces
{
    public interface IHeadphone
    {
        IProducer Producer { get; set; }
        string Name { get; set; }
        float Price { get; set; }
        Color ColorType { get; set; }

    }
}
