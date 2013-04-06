using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RahamtGroupStore.Model.Interfaces;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class UserAccount : ModelBase, IDataErrorInfo, IEntity
    {
        private string _conformPassword;
        private Int64 _id;
        private string _userPassword;
        private bool _readOnly;
        private string _userName;

        [MaxLength(100)]
        [Required]
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPeroertyChange("UserName");
            }
        }

        [Required]
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                OnPeroertyChange("UserPassword");
            }
        }

        [Required]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                OnPeroertyChange("ReadOnly");
            }
        }


        [NotMapped]
        public string ConformPassword
        {
            get { return _conformPassword; }
            set
            {
                _conformPassword = value;
                OnPeroertyChange("ConformPassword");
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
                    case "UserName":
                        if (String.IsNullOrEmpty(UserName) || String.IsNullOrWhiteSpace(UserName))
                        {
                            errorMessagess = "Please enter User Name.";
                        }
                        break;
                    case "UserPassword":
                        if (String.IsNullOrEmpty(UserPassword) || String.IsNullOrWhiteSpace(UserPassword))
                        {
                            errorMessagess = "Please enter UserPassword.";
                        }
                        break;
                    case "ConformPassword":
                        if (String.IsNullOrEmpty(ConformPassword) || String.IsNullOrWhiteSpace(ConformPassword))
                        {
                            errorMessagess = "Please enter Conform Password.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion

        #region IEntity Members

        [Key]
        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPeroertyChange("Id");
            }
        }

        #endregion
    }
}