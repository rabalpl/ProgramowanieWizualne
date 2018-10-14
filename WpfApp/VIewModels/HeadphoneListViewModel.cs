using Rabalski.HeadphoneCatalog.BLC;
using Rabalski.HeadphoneCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfApp.Properties;

namespace Rabalski.HeadphoneCatalog.WpfApp.ViewModels
{
    public class HeadphoneListViewModel : ViewModelBase
    {
        public ObservableCollection<HeadphoneViewModel> Headphones { get; set; } = new ObservableCollection<HeadphoneViewModel>();
        private ListCollectionView _view;
        Settings properties = new Settings();

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }
        public string FilterValue { get; set; }

        public HeadphoneListViewModel()
        {
            OnPropertyChanged("Headphones");
            GetAllHeadphones();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Headphones);
            _filterDataCommand = new RelayCommand(param => this.FilterData());
            _addNewHeadphoneCommand = new RelayCommand(param => this.AddNewHeadphone(), param => this.CanAddNewHeadphone());
            _saveHeadphoneCommand = new RelayCommand(param => this.SaveHeadphone(), param => this.CanSaveHeadphone());

            EditedHeadphone = Headphones[0];
            SelectedHeadphone = EditedHeadphone;
        }

        private void GetAllHeadphones()
        {
            Settings properties = new Settings();
            BLC.DataProvider dataProvider = null;
            try
            {
                dataProvider = new BLC.DataProvider(properties.libraryName);
            }
            catch (NullReferenceException) { Console.WriteLine("Creating DAO Failed!"); }

            List<IProducer> producers = (List<IProducer>)dataProvider.Producers;
            foreach (var Headphone in dataProvider.Headphones)
            {
                Headphones.Add(new HeadphoneViewModel(Headphone, producers));
            }
        }

        private void FilterData()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (b) => ((HeadphoneViewModel)b).Name.Contains(FilterValue);
            }
        }

        private HeadphoneViewModel _editedHeadphone;
        public HeadphoneViewModel EditedHeadphone
        {
            get => _editedHeadphone;
            set
            {
                _editedHeadphone = value;
                OnPropertyChanged(nameof(EditedHeadphone));
            }
        }

        private HeadphoneViewModel _selectedHeadphone;
        public HeadphoneViewModel SelectedHeadphone
        {
            get => _selectedHeadphone;
            set
            {
                _selectedHeadphone = value;
                EditedHeadphone = value;
                OnPropertyChanged(nameof(EditedHeadphone));
            }
        }

        private RelayCommand _saveHeadphoneCommand;

        public RelayCommand SaveHeadphoneCommand
        {
            get => _saveHeadphoneCommand;
        }

        private void SaveHeadphone()
        {
            if (!Headphones.Contains(EditedHeadphone))
            {
                Headphones.Add(EditedHeadphone);
                EditedHeadphone = null;
            }
            EditedHeadphone = null;
        }

        private bool CanSaveHeadphone()
        {
            if (EditedHeadphone != null && !EditedHeadphone.HasErrors)
            {
                return true;
            }
            return false;
        }

        private RelayCommand _addNewHeadphoneCommand;

        public RelayCommand AddNewHeadphoneCommand
        {
            get => _addNewHeadphoneCommand;
        }

        private void AddNewHeadphone()
        {
            Settings properties = new Settings();
            BLC.DataProvider dataProvider = null;
            try
            {
                dataProvider = new BLC.DataProvider(properties.libraryName);
            }
            catch (NullReferenceException) { Console.WriteLine("Creating DAO Failed!"); }

            IHeadphone newHeadphone = dataProvider.AddHeadphone();
            EditedHeadphone = new HeadphoneViewModel(newHeadphone, (List<IProducer>)dataProvider.Producers);
            EditedHeadphone.Validate();
        }

        private bool CanAddNewHeadphone()
        {
            if (EditedHeadphone != null)
                return false;
            return true;
        }

    }
}
