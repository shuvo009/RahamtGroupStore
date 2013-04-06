using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class MachineLedger : ModelBase,IEntity
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
        [MaxLength(50)]
        public virtual string Parteculars
        {
            get { return _parteculars; }
            set
            {
                _parteculars = value;
                OnPeroertyChange("Parteculars");
            }
        }


        [Required]
        public virtual Int64 Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPeroertyChange("Quantity");
            }
        }


        [Required]
        [MaxLength(100)]
        public virtual string RequisitionNo
        {
            get { return _requisitionNo; }
            set
            {
                _requisitionNo = value;
                OnPeroertyChange("RequisitionNo");
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

        public virtual SparesInformation SparesInformation { get; set; }

        #region Private Variables

        private DateTime _entryDate;
        private Int64 _id;
        private string _parteculars;
        private Int64 _quantity;
        private string _requisitionNo;
        private MachineInformation _machineInformation;

        #endregion
    }
}