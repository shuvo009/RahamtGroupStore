using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class CompanyInformation : ModelBase, IDataErrorInfo,IEntity
    {
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
        [MaxLength(30)]
        public virtual string CompaneyName
        {
            get { return _companeyName; }
            set
            {
                _companeyName = value;
                OnPeroertyChange("CompaneyName");
            }
        }


        [Required]
        [MaxLength(100)]
        public virtual string AddressOne
        {
            get { return _addressOne; }
            set
            {
                _addressOne = value;
                OnPeroertyChange("AddressOne");
            }
        }


        [MaxLength(100)]
        public virtual string AddressTwo
        {
            get { return _addressTwo; }
            set
            {
                _addressTwo = value;
                OnPeroertyChange("AddressTwo");
            }
        }


        [Required]
        [MaxLength(100)]
        public virtual string ContractDetails
        {
            get { return _contractDetails; }
            set
            {
                _contractDetails = value;
                OnPeroertyChange("ContractDetails");
            }
        }


        [MaxLength(30)]
        public virtual string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPeroertyChange("Email");
            }
        }


        public virtual string Web
        {
            get { return _web; }
            set
            {
                _web = value;
                OnPeroertyChange("Web");
            }
        }


        [Required]
        public virtual byte[] Logo
        {
            get { return _logo; }
            set
            {
                _logo = value;
                OnPeroertyChange("Logo");
            }
        }

        #region Private Variables

        private string _addressOne;
        private string _addressTwo;
        private string _companeyName;
        private string _contractDetails;
        private string _email;
        private Int64 _id;
        private byte[] _logo;
        private string _web;

        #endregion

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
                    case "CompaneyName":
                        if (String.IsNullOrEmpty(CompaneyName) || String.IsNullOrWhiteSpace(CompaneyName))
                        {
                            errorMessagess = "Please enter Companey UnitName.";
                        }
                        break;
                    case "AddressOne":
                        if (String.IsNullOrEmpty(AddressOne) || String.IsNullOrWhiteSpace(AddressOne))
                        {
                            errorMessagess = "Please enter Address.";
                        }
                        break;
                    case "ContractDetails":
                        if (String.IsNullOrEmpty(ContractDetails) || String.IsNullOrWhiteSpace(ContractDetails))
                        {
                            errorMessagess = "Please enter Contract Details.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}