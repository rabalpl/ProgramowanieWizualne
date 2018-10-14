using Rabalski.HeadphoneCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabalski.HeadphoneCatalog.DAOMock2.BO
{
    public class Producer : IProducer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
