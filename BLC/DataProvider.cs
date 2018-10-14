using Rabalski.HeadphoneCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rabalski.HeadphoneCatalog.BLC
{
    public class DataProvider
    {
        public IDAO DAO { get; set; }
        public IEnumerable<IHeadphone> Headphones
        {
            get { return DAO.GetAllHeadphone(); }
        }
        public IEnumerable<IProducer> Producers
        {
            get { return DAO.GetAllProducers(); }
        }

        public IProducer AddProducer()
        {
            return DAO.AddNewProducer();
        }

        public IHeadphone AddHeadphone()
        {
            return DAO.AddNewHeadphone();
        }

        public void SaveHeadphone(IHeadphone Headphone)
        {
            DAO.SaveHeadphone(Headphone);
        }

        public void SaveHeadphone(IHeadphone Headphone, int index)
        {
            DAO.SaveHeadphone(Headphone, index);
        }

        public void SaveProducer(IProducer producer)
        {
            DAO.SaveProducer(producer);
        }

        public void SaveProducer(IProducer producer, int index)
        {
            DAO.SaveProducer(producer, index);
        }


        public DataProvider(string libraryName)
        {
            Assembly assembly = Assembly.UnsafeLoadFrom(@"..\..\..\" + libraryName + @"\bin\Release\" + libraryName + ".dll");

            Type type = null;

            foreach (var a in assembly.GetTypes())
            {
                if (a.GetInterfaces().Contains<Type>(typeof(IDAO)))
                {
                    type = a;
                    break;
                }
            }

            try
            {
                ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { });
                DAO = (IDAO)constructorInfo.Invoke(new object[] { });
            }
            catch (NullReferenceException e){ throw e; }
        }
    }
}
