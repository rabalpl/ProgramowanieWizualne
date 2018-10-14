using Rabalski.HeadphoneCatalog.Interfaces;
using System;
using Rabalski.HeadphoneCatalog.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;


namespace Rabalski.HeadphoneCatalog.WpfApp.ViewModels
{
    public class HeadphoneViewModel : ViewModelBase
    {
        private IHeadphone _Headphone;
        public IHeadphone Headphone
        {
            get => _Headphone;
        }

        private ObservableCollection<IProducer> _producers;
        public ObservableCollection<IProducer> Producers
        {
            get => _producers;
        }

        public HeadphoneViewModel(IHeadphone Headphone, List<IProducer> producers)
        {
            _Headphone = Headphone;
            _producers = new ObservableCollection<IProducer>(producers);
        }


        [Required(ErrorMessage = "Nazwa wymagana")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Dlugosc nazwy musi byc z przedzialu <3,20>")]
        public string Name
        {
            get => _Headphone.Name;
            set
            {
                _Headphone.Name = value;
                Validate();
                OnPropertyChanged("Name");
            }
        }


        [Required(ErrorMessage = "Cena wymagana")]
        [Range(0, 15000, ErrorMessage = "Cena od 0 do 15000")]
        public float Price
        {
            get => _Headphone.Price;
            set
            {
                _Headphone.Price = value;
                Validate();
                OnPropertyChanged("Price");
            }
        }

        [Required(ErrorMessage = "Podaj producenta")]
        public IProducer Producer
        {
            get => _Headphone.Producer;
            set
            {
                _Headphone.Producer = value;
                Validate();
                OnPropertyChanged("Producer");
            }
        }

        public Color HeadphoneColor
        {
            get => _Headphone.ColorType;
            set
            {
                _Headphone.ColorType = value;
                Validate();
                OnPropertyChanged("Color");
            }

        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);


            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    RaiseErrorChanged(kv.Key);
                }
            }

            var q = from r in validationResults
                    from m in r.MemberNames
                    group r by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);
                RaiseErrorChanged(prop.Key);
            }
        }
    }
}
