using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class RepairCompaneyInformation : ModelBase, IDataErrorInfo,IEntity
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
        [MaxLength(50)]
        public virtual string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPeroertyChange("Name");
            }
        }


        [Required]
        [MaxLength(100)]
        public virtual string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPeroertyChange("Address");
            }
        }


        [Required]
        [MaxLength(30)]
        public virtual string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPeroertyChange("Phone");
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


        [MaxLength(30)]
        public virtual string WebSite
        {
            get { return _webSite; }
            set
            {
                _webSite = value;
                OnPeroertyChange("WebSite");
            }
        }


        [MaxLength(50)]
        public virtual string ContractPerson
        {
            get { return _contractPerson; }
            set
            {
                _contractPerson = value;
                OnPeroertyChange("ContractPerson");
            }
        }

        #region Private Variables

        private string _address;
        private string _contractPerson;
        private string _email;
        private Int64 _id;
        private string _name;
        private string _phone;
        private string _webSite;

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
                    case "Name":
                        if (String.IsNullOrEmpty(Name) || String.IsNullOrWhiteSpace(Name))
                        {
                            errorMessagess = "Please enter Company Name.";
                        }
                        break;
                    case "Address":
                        if (String.IsNullOrEmpty(Address) || String.IsNullOrWhiteSpace(Address))
                        {
                            errorMessagess = "Please enter Company Address.";
                        }
                        break;
                    case "Phone":
                        if (String.IsNullOrEmpty(Phone) || String.IsNullOrWhiteSpace(Phone))
                        {
                            errorMessagess = "Please enter Phone Number.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}