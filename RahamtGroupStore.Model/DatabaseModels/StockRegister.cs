using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class StockRegister : ModelBase, IDataErrorInfo, IEntity, ICloneable
    {
        #region Private Variables
        private Int64 _id;
        private string _invoiceNumber;
        private decimal _price;
        private int _quantity;
        private SparesInformation _sparesInformation;
        private SupplierInformation _supplierInformation;
        private DateTime _entryDate;
        private decimal _rate;
        private string _type;
        private string _note;
        #endregion

        [Key]
        public virtual Int64 Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPeroertyChange("Id");
            }
        }

        [Required]
        [MaxLength(50)]
        public virtual string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set
            {
                _invoiceNumber = value;
                OnPeroertyChange("InvoiceNumber");
            }
        }

        [Required]
        public virtual decimal Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPeroertyChange("Rate");
            }
        }
        [Required]
        public virtual int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPeroertyChange("Quantity");
            }
        }

        [Required]
        public virtual decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPeroertyChange("Price");
            }
        }

        [Required]
        public virtual DateTime EntryDate
        {
            get { return _entryDate; }
            set
            {
                _entryDate = value;
                OnPeroertyChange("EntryDate");
            }
        }

        [Required]
        [MaxLength(30)]
        public virtual string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPeroertyChange("Type");
            }
        }

        [MaxLength(200)]
        public string Note
        {
            get { return _note; }
            set
            {
                _note = value;
                OnPeroertyChange("Note");
            }
        }


        public virtual SupplierInformation SupplierInformation
        {
            get { return _supplierInformation; }
            set
            {
                _supplierInformation = value;
                OnPeroertyChange("SupplierInformation");
            }
        }

        public virtual SparesInformation SparesInformation
        {
            get { return _sparesInformation; }
            set
            {
                _sparesInformation = value;
                OnPeroertyChange("SparesInformation");
            }
        }

        #region Data Error Information

        public string Error
        {
            get { return String.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                string errorMessagess = String.Empty;
                switch (columnName)
                {
                    case "InvoiceNumber":
                        if (String.IsNullOrEmpty(InvoiceNumber) || String.IsNullOrWhiteSpace(InvoiceNumber))
                        {
                            errorMessagess = "Please enter Invoice Number.";
                        }
                        break;
                    case "Rate":
                        if (Rate <= 0)
                        {
                            errorMessagess = "Please enter Rate.";
                        }
                        break;
                    case "Quantity":
                        if (Quantity <= 0)
                        {
                            errorMessagess = "Please enter Quantity.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}