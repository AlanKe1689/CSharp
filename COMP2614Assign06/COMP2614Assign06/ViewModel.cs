using BusinessLib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign06
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string clientCode;
        private string companyName;
        private string address1;
        private string address2;
        private string city;
        private string province;
        private string postalCode;
        private decimal ytdSales;
        private bool creditHold;
        private string notes;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ClientCollection Clients { get; set; }

        public ViewModel(ClientCollection clients)
        {
            this.Clients = clients;
        }

        public string ClientCode
        {
            get { return clientCode; }
            set
            {
                clientCode = value;
                OnPropertyChanged();
            }
        }

        public string CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                OnPropertyChanged();
            }
        }

        public string Address1
        {
            get { return address1; }
            set
            {
                address1 = value;
                OnPropertyChanged();
            }
        }

        public string Address2
        {
            get { return address2; }
            set
            {
                address2 = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }

        public string Province
        {
            get { return province; }
            set
            {
                province = value;
                OnPropertyChanged();
            }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                OnPropertyChanged();
            }
        }

        public decimal YTDSales
        {
            get { return ytdSales; }
            set
            {
                ytdSales = value;
                OnPropertyChanged();
            }
        }

        public bool CreditHold
        {
            get { return creditHold; }
            set
            {
                creditHold = value;
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged();
            }
        }

        public void SetDisplayClients(Customer client)
        {
            this.ClientCode = client.ClientCode;
            this.CompanyName = client.CompanyName;
            this.Address1 = client.Address1;
            this.Address2 = client.Address2;
            this.City = client.City;
            this.Province = client.Province;
            this.PostalCode = client.PostalCode;
            this.YTDSales = client.YTDSales;
            this.CreditHold = client.CreditHold;
            this.Notes = client.Notes;
        }

        public Customer SaveClient(int index)
        {
            this.Clients[index].ClientCode = this.ClientCode;
            this.Clients[index].CompanyName = this.CompanyName;
            this.Clients[index].Address1 = this.Address1;
            this.Clients[index].Address2 = this.Address2;
            this.Clients[index].City = this.City;
            this.Clients[index].Province = this.Province;
            this.Clients[index].PostalCode = this.PostalCode;
            this.Clients[index].YTDSales = this.YTDSales;
            this.Clients[index].CreditHold = this.CreditHold;
            this.Clients[index].Notes = this.Notes;

            return this.Clients[index];
        }

        public Customer GetDisplayCustomer()
        {
            return new Customer(this.ClientCode, this.CompanyName, this.Address1, this.Address2, this.City, this.Province, this.PostalCode, this.YTDSales, this.CreditHold, this.Notes);
        }
    }
}
