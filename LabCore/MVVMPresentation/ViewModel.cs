using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;
using LabCore.BusinessLayer.Interfaces;
using LabCore.BusinessLayer.BaseType;


namespace LabCore.MVVMPresentation
{
    class ViewModel : INotifyPropertyChanged
    {
        private IWorkshopService workshopService;
        private Dictionary<string, int> order;
        private ObservableCollection<string> baugetteNames;
        private ObservableCollection<string> orderNames;
        private ObservableCollection<string> nessMaterialNames;
        private string selectedBaugetteNames;
        private string enoughMaterials;
        private int count;
        private RelayCommand addOrderCommand;
        private RelayCommand calcCommand;
        private RelayCommand clearOrderCommand;

        public ViewModel(IWorkshopService workshopService)
        {
            this.workshopService = workshopService;
            baugetteNames = (ObservableCollection<string>)workshopService.GetBaugetteNames();
            order = new Dictionary<string, int>();
            orderNames = new ObservableCollection<string>();
            nessMaterialNames = new ObservableCollection<string>();
        }

        public ObservableCollection<string> BaugetteNames
        {
            get => baugetteNames;
            set
            {
                baugetteNames = value;
                OnPropertyChanged("BaugetteNames");
            }
        }

        public string SelectedBaugetteNames
        {
            get => selectedBaugetteNames;
            set
            {
                selectedBaugetteNames = value;
                OnPropertyChanged("BaugetteNames");

                baugetteNames = baugetteNames ?? (ObservableCollection<string>)workshopService.GetBaugetteNames();
            }
        }

        public ObservableCollection<string> OrderNames
        {
            get => orderNames;
            set
            {
                orderNames = value;
                OnPropertyChanged("OrderNames");
            }
        }

        public ObservableCollection<string> NessMaterialNames
        {
            get => nessMaterialNames;
            set
            {
                nessMaterialNames = value;
                OnPropertyChanged("NessMaterialNames");
            }
        }

        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public string EnoughMaterials
        {
            get => enoughMaterials;
            set
            {
                enoughMaterials = value;
                OnPropertyChanged("EnoughMaterials");
            }
        }

        public RelayCommand AddOrderCommand
        {
            get
            {
                return addOrderCommand ?? (addOrderCommand = new RelayCommand(obj =>
                {
                    order.Add(selectedBaugetteNames, count);
                    orderNames.Add(selectedBaugetteNames + "\t\t\t" + count.ToString());
                }));
            }
        }

        public RelayCommand CalcCommand
        {
            get
            {
                return calcCommand ?? (calcCommand = new RelayCommand(obj =>
                {
                    nessMaterialNames.Clear();
                    List<MaterialCount> nessMaterials = (List<MaterialCount>)workshopService.GetNessMaterials(order);
                    if (nessMaterials.Count == 0)
                        EnoughMaterials = "Матеріалів вистачає";
                    else
                        EnoughMaterials = "Матеріалів не вистачає";

                    foreach (var n in nessMaterials)
                    {
                        nessMaterialNames.Add(n.Name + "\t\t" + n.Count.ToString());
                    }
                }));
            }
        }

        public RelayCommand ClearOrderCommand
        {
            get
            {
                return clearOrderCommand ?? (clearOrderCommand = new RelayCommand(obj =>
                {
                    order.Clear();
                    orderNames.Clear();
                    nessMaterialNames.Clear();
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
