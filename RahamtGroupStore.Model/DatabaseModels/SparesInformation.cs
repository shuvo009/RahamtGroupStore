using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RahamtGroupStore.Model.Interfaces;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class SparesInformation : ModelBase, IDataErrorInfo, IEntity
    {
        [Required]
        [MaxLength(100)]
        public virtual string Partno
        {
            get { return _partNo; }
            set
            {
                _partNo = value;
                OnPeroertyChange("Partno");
            }
        }


        [Required]
        [MaxLength(100)]
        public virtual string PartName
        {
            get { return _partName; }
            set
            {
                _partName = value;
                OnPeroertyChange("PartName");
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

        


        public virtual decimal Rate
        {
            get { return _rate; }
            set
            {
                _rate = value; 
               OnPeroertyChange("Rate");
               
            }
        }


        public virtual decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPeroertyChange("Amount");
            }
        }

        //[Required]

        //public virtual string Type
        //{
        //    get { return _type; }
        //    set
        //    {
        //        _type = value;
        //        OnPeroertyChange("Type");
        //    }
        //}

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

        public virtual MachineInformation MachineInformation
        {
            get { return _machineInformation; }
            set
            {
                _machineInformation = value;
                OnPeroertyChange("MachineInformation");
            }
        }

        private UnitType _unit;

        public virtual UnitType Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                OnPeroertyChange("Unit");
            }
        }  

        #region Private Variables

        private decimal _amount;
        private Int64 _id;
        private MachineInformation _machineInformation;
        private string _partName;
        private string _partNo;
        private int _quantity;
        private decimal _rate;
        private SectionInformation _sectionInformation;
        private UnitInformation _unitInformation;
        //private string _type;

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
                    case "Partno":
                        if (String.IsNullOrEmpty(Partno) || String.IsNullOrWhiteSpace(Partno))
                        {
                            errorMessagess = "Please enter Part No.";
                        }
                        break;
                    case "PartName":
                        if (String.IsNullOrEmpty(PartName) || String.IsNullOrWhiteSpace(PartName))
                        {
                            errorMessagess = "Please enter Part UnitName.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion

        #region IEntity Members

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

        #endregion
    }
}