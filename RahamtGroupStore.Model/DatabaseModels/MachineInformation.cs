using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class MachineInformation : ModelBase, IDataErrorInfo,IEntity
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
        public virtual string MadeBy
        {
            get { return _madeBy; }
            set
            {
                _madeBy = value;
                OnPeroertyChange("MadeBy");
            }
        }


        [Required]
        [MaxLength(100)]
        public virtual string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPeroertyChange("Model");
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
        [MaxLength(100)]
        public virtual string McSerialNo
        {
            get { return _mcSerialNo; }
            set
            {
                _mcSerialNo = value;
                OnPeroertyChange("McSerialNo");
            }
        }


        [Required]
        [MaxLength(100)]
        public virtual string Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                OnPeroertyChange("Origin");
            }
        }


        [Required]
        [MaxLength(100)]
        public virtual string Delivery
        {
            get { return _delivery; }
            set
            {
                _delivery = value;
                OnPeroertyChange("Delivery");
            }
        }


        [Required]
        public virtual int McQuentity
        {
            get { return _mcQuentity; }
            set
            {
                _mcQuentity = value;
                OnPeroertyChange("McQuentity");
            }
        }

        public virtual UnitInformation UnitInformation { get; set; }
        public virtual SectionInformation SectionInformation { get; set; }

        #region Private Variables

        private string _delivery;
        private DateTime _entryDate;
        private Int64 _id;
        private string _madeBy;
        private int _mcQuentity;
        private string _mcSerialNo;
        private string _model;
        private string _name;
        private string _origin;

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
                            errorMessagess = "Please enter Machine UnitName.";
                        }
                        break;
                    case "MadeBy":
                        if (String.IsNullOrEmpty(MadeBy) || String.IsNullOrWhiteSpace(MadeBy))
                        {
                            errorMessagess = "Please enter MadeBy.";
                        }
                        break;
                    case "Model":
                        if (String.IsNullOrEmpty(Model) || String.IsNullOrWhiteSpace(Model))
                        {
                            errorMessagess = "Please enter Model.";
                        }
                        break;
                    case "McSerialNo":
                        if (String.IsNullOrEmpty(McSerialNo) || String.IsNullOrWhiteSpace(McSerialNo))
                        {
                            errorMessagess = "Please enter MC Serial No.";
                        }
                        break;
                    case "Origin":
                        if (String.IsNullOrEmpty(Origin) || String.IsNullOrWhiteSpace(Origin))
                        {
                            errorMessagess = "Please enter Origin.";
                        }
                        break;
                    case "Delivery":
                        if (String.IsNullOrEmpty(Delivery) || String.IsNullOrWhiteSpace(Delivery))
                        {
                            errorMessagess = "Please enter Delivery.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}