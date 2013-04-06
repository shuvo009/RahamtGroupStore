using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class SupplierInformation : ModelBase, IDataErrorInfo,IEntity
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


        [MaxLength(20)]
        public virtual string TelePhone
        {
            get { return _telePhone; }
            set
            {
                _telePhone = value;
                OnPeroertyChange("TelePhone");
            }
        }


        [Required]
        [MaxLength(20)]
        public virtual string Mobile
        {
            get { return _mobile; }
            set
            {
                _mobile = value;
                OnPeroertyChange("Mobile");
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

        #region Private Variables

        private string _address;
        private string _email;
        private Int64 _id;
        private string _mobile;
        private string _name;
        private string _telePhone;
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
                            errorMessagess = "Please enter Supplier Name.";
                        }
                        break;
                    case "Address":
                        if (String.IsNullOrEmpty(Address) || String.IsNullOrWhiteSpace(Address))
                        {
                            errorMessagess = "Please enter Supplier Address.";
                        }
                        break;
                    case "Mobile":
                        if (String.IsNullOrEmpty(Mobile) || String.IsNullOrWhiteSpace(Mobile))
                        {
                            errorMessagess = "Please enter Mobile Number.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}