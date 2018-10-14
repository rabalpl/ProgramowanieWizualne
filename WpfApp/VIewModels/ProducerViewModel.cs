using Rabalski.HeadphoneCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabalski.HeadphoneCatalog.WpfApp.ViewModels
{
    public class ProducerViewModel : ViewModelBase
    {
        private IProducer _producer;
        public IProducer Producer
        {
            get => _producer;
        }

        public ProducerViewModel(IProducer producer)
        {
            _producer = producer;
        }

        [Required(ErrorMessage = "Nazwa wymagana")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Długość nazwy musi być w przedziale <3,20>")]
        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                Validate();
                OnPropertyChanged("Name");
            }
        }

        [Required(ErrorMessage = "Podaj pochodzenie firmy")]
        [RegularExpression(@"^[a-zA-z\ ]*", ErrorMessage = "Dozwolone wyłącznie litery")]
        public string Country
        {
            get => _producer.Country;
            set
            {
                _producer.Country = value;
                Validate();
                OnPropertyChanged("Country");
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
