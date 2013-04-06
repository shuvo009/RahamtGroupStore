using RahamtGroupStore.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class ReceiptAndIssueCardInformation : ModelBase, IDataErrorInfo,IEntity
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

        
        [MaxLength(100)]
        public virtual string Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                OnPeroertyChange("Maximum");
            }
        }

       
        [MaxLength(100)]
        public virtual string Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                OnPeroertyChange("Minimum");
            }
        }

        
        [MaxLength(100)]
        public virtual string OrderPoint
        {
            get { return _orderPoint; }
            set
            {
                _orderPoint = value;
                OnPeroertyChange("OrderPoint");
            }
        }


        [MaxLength(100)]
        public virtual string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPeroertyChange("Location");
            }
        }

        [Required]
        [MaxLength(100)]
        public virtual string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPeroertyChange("Description");
            }
        }

        
        [MaxLength(100)]
        public virtual string Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                OnPeroertyChange("Unit");
            }
        }

        [Required]
        [MaxLength(100)]
        public virtual string CodeNo
        {
            get { return _codeNo; }
            set
            {
                _codeNo = value;
                OnPeroertyChange("CodeNo");
            }
        }

        [Required]
        public virtual int BalanceQuantity
        {
            get { return _balanceQuantity; }
            set
            {
                _balanceQuantity = value;
                OnPeroertyChange("BalanceQuantity");
            }
        }  

        public virtual List<ReceiptAndIssueCard> ReceiptAndIssueCards { get; set; }

        public virtual UnitInformation UnitInformation { get; set; }

        public virtual SectionInformation SectionInformation { get; set; }

        #region Private Variables

        private string _codeNo;
        private string _description;
        private Int64 _id;
        private string _location;
        private string _maximum;
        private string _minimum;
        private string _orderPoint;
        private string _unit;
        private int _balanceQuantity;
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
                    case "CodeNo":
                        if (String.IsNullOrEmpty(CodeNo) || String.IsNullOrWhiteSpace(CodeNo))
                        {
                            errorMessagess = "Please enter Code No.";
                        }
                        break;
                    case "Description":
                        if (String.IsNullOrEmpty(Description) || String.IsNullOrWhiteSpace(Description))
                        {
                            errorMessagess = "Please enter Description.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}