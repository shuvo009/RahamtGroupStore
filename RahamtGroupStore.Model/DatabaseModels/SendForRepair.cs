using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class SendForRepair : ModelBase, IDataErrorInfo,IEntity
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
        [MaxLength(100)]
        public virtual string RequsitionNo
        {
            get { return _requsitionNo; }
            set
            {
                _requsitionNo = value;
                OnPeroertyChange("RequsitionNo");
            }
        }


        [Required]
        public virtual int SendQuantity
        {
            get { return _senQuantity; }
            set
            {
                _senQuantity = value;
                OnPeroertyChange("SendQuantity");
            }
        }

        public virtual int ReceiveQuantity
        {
            get { return _receiveQuantity; }
            set
            {
                _receiveQuantity = value;
                OnPeroertyChange("ReceiveQuantity");
            }
        }  
        
        public virtual string Note
        {
            get { return _note; }
            set
            {
                _note = value;
                OnPeroertyChange("Note");
            }
        }  
        public virtual RepairCompaneyInformation RepairCompaneyInformation
        {
            get { return _repairCompaneyInformation; }
            set
            {
                _repairCompaneyInformation = value;
                OnPeroertyChange("RepairCompaneyInformation");
            }
        }

        public virtual MachineBreakdownInformation MachineBreakdownInformation
        {
            get { return _machineBreakdownInformation; }
            set
            {
                _machineBreakdownInformation = value;
                OnPeroertyChange("MachineBreakdownInformation");
            }
        }

        [NotMapped]
        public int ReceivedQuantity { get; set; }

        #region Private Variables

        private DateTime _entryDate;
        private int _receiveQuantity;
        private Int64 _id;
        private string _note;
        private string _requsitionNo;
        private int _senQuantity;
        private RepairCompaneyInformation _repairCompaneyInformation;
        private MachineBreakdownInformation _machineBreakdownInformation;

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
                    case "RequsitionNo":
                        if (String.IsNullOrEmpty(RequsitionNo) || String.IsNullOrWhiteSpace(RequsitionNo))
                        {
                            errorMessagess = "Please enter Requsition No.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}