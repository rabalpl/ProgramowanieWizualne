using Rabalski.HeadphoneCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabalski.HeadphoneCatalog.DAOMock2
{
    public class DAO : IDAO
    {
        private List<IProducer> _producers;
        private List<IHeadphone> _Headphones;

        public DAO()
        {
            _producers = new List<IProducer>()
            {
                new BO.Producer {Name="Jays", Country="Sweden"},
                new BO.Producer {Name="HyperX", Country="United States"},
                new BO.Producer {Name="Creative", Country="Singapore"},
                new BO.Producer {Name="SteelSeries", Country="Dennmark"}
            };

            _Headphones = new List<IHeadphone>()
            {
                new BO.Headphone {Name="Jays SIX", Producer = _producers[0], ColorType = Core.Color.Light, Price = 349.5f},
                new BO.Headphone {Name="Cloud II", Producer = _producers[1], ColorType = Core.Color.Light, Price = 401f},
                new BO.Headphone {Name="SB Tactic3D", Producer = _producers[2], ColorType = Core.Color.Dark, Price = 120f},
                new BO.Headphone {Name="Siberia V2", Producer = _producers[3], ColorType = Core.Color.Light, Price = 190f}
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
