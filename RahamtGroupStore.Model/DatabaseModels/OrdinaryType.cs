using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class OrdinaryType : ModelBase, IDataErrorInfo,IEntity
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
        [MaxLength(100)]
        public virtual string OrdType
        {
            get { return _ordType; }
            set
            {
                _ordType = value;
                OnPeroertyChange("OrdType");
            }
        }

        #region Private Variables

        private Int64 _id;
        private string _ordType;

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
                    case "OrdType":
                        if (String.IsNullOrEmpty(OrdType) || String.IsNullOrWhiteSpace(OrdType))
                        {
                            errorMessagess = "Please enter Type.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}