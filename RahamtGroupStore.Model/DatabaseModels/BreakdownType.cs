using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class BreakdownType : ModelBase, IDataErrorInfo,IEntity
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
        public virtual string TypeName
        {
            get { return _typeName; }
            set
            {
                _typeName = value;
                OnPeroertyChange("TypeName");
            }
        }

        #region Private Variables

        private string _typeName;
        private Int64 _id;

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
                    case "TypeName":
                        if (String.IsNullOrEmpty(TypeName) || String.IsNullOrWhiteSpace(TypeName))
                        {
                            errorMessagess = "Please enter Type UnitName.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}