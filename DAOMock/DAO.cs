using Rabalski.HeadphoneCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabalski.HeadphoneCatalog.DAOMock
{
    public class DAO : IDAO
    {
        private List<IProducer> _producers;
        private List<IHeadphone> _Headphones;

        public DAO()
        {
            _producers = new List<IProducer>()
            {
                new BO.Producer {Name="Sennheiser", Country="Germany"},
                new BO.Producer {Name="Sony", Country="Japan"},
                new BO.Producer {Name="AKG", Country="Austria"},
            };

            _Headphones = new List<IHeadphone>()
            {
                new BO.Headphone {Name="CX Sport", Producer = _producers[0], ColorType = Core.Color.Light, Price = 520f},
                new BO.Headphone {Name="GSP 600", Producer = _producers[0], ColorType = Core.Color.Dark, Price = 900f},
                new BO.Headphone {Name="MDR-1A", Producer = _producers[1], ColorType = Core.Color.Light, Price = 720.2f},
                new BO.Headphone {Name="Y 30", Producer = _producers[2], ColorType = Core.Color.Dark, Price = 200f}
            };
        }

        public IHeadphone AddNewHeadphone()
        {
            IHeadphone Headphone = new BO.Headphone();
            Headphone.Name = "";
            Headphone.Price = 0.0f;
            return Headphone;
        }

        public IProducer AddNewProducer()
        {
            IProducer producer = new BO.Producer();
            producer.Name = "";
            producer.Country = "";
            return producer;
        }

        public IEnumerable<IHeadphone> GetAllHeadphone()
        {
            return _Headphones;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producers;
        }

        public void SaveHeadphone(IHeadphone Headphone)
        {
            _Headphones.Add(Headphone);
        }

        public void SaveHeadphone(IHeadphone Headphone, int index)
        {
            _Headphones[index] = Headphone;
        }

        public void SaveProducer(IProducer producer)
        {
            _producers.Add(producer);
        }

        public void SaveProducer(IProducer producer, int index)
        {
            _producers[index] = producer;
        }
    }
}
