using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class IssueSpareParts : ModelBase, IDataErrorInfo,IEntity,ICloneable
    {
        #region Private Variables

        private Int64 _id;
        private MachineInformation _machinInformation;
        private int _quantity;
        private SparesInformation _sparesInformation;
        private DateTime _entry;
        private UnitInformation _unitInformation;
        private SectionInformation _sectionInformation;
        private decimal _rate;
        private decimal _amount;
        private BreakdownCause _breakDownCause;
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
        public virtual DateTime EntryDate
        {
            get { return _entry; }
            set
            {
                _entry = value;
                OnPeroertyChange("EntryDate");
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
        public virtual decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPeroertyChange("Amount");
            }
        }

        [MaxLength(300)]
        public virtual string Note
        {
            get { return _note; }
            set
            {
                _note = value;
                OnPeroertyChange("Note");
            }
        }    

        public virtual MachineInformation MachineInformation
        {
            get { return _machinInformation; }
            set
            {
                _machinInformation = value;
                OnPeroertyChange("MachineInformation");
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

        public virtual UnitInformation UnitInformation
        {
            get { return _unitInformation; }
            set
            {
                _unitInformation = value;
                OnPeroertyChange("UnitInformation");
            }
        }

        public virtual SectionInformation SectionInformation
        {
            get { return _sectionInformation; }
            set
            {
                _sectionInformation = value;
                OnPeroertyChange("SectionInformation");
            }
        }

        public virtual BreakdownCause BreakDownCause
        {
            get { return _breakDownCause; }
            set
            {
                _breakDownCause = value;
                OnPeroertyChange("BreakDownCause");
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