using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabalski.HeadphoneCatalog.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IHeadphone> GetAllHeadphone();
        IEnumerable<IProducer> GetAllProducers();

        IHeadphone AddNewHeadphone();
        IProducer AddNewProducer();
        void SaveHeadphone(IHeadphone Headphone);
        void SaveHeadphone(IHeadphone Headphone, int index);
        void SaveProducer(IProducer producer);
        void SaveProducer(IProducer producer, int index);
    }
}
