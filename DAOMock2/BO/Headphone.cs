using Rabalski.HeadphoneCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabalski.HeadphoneCatalog.DAOMock2.BO
{
    public class Headphone : IHeadphone
    {
        public IProducer Producer { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Rabalski.HeadphoneCatalog.Core.Color ColorType { get; set; }
    }
}
