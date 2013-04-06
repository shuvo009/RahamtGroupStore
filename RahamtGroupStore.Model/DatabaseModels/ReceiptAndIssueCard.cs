using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class ReceiptAndIssueCard : ModelBase, IDataErrorInfo,IEntity
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
        public virtual string MrrOrSrNo
        {
            get { return _mrrorSrNo; }
            set
            {
                _mrrorSrNo = value;
                OnPeroertyChange("MrrOrSrNo");
            }
        }


        [Required]
        public virtual int Received
        {
            get { return _received; }
            set
            {
                _received = value;
                OnPeroertyChange("Received");
            }
        }


        [Required]
        public virtual int Issued
        {
            get { return _issued; }
            set
            {
                _issued = value;
                OnPeroertyChange("Issued");
            }
        }


        [Required]
        public virtual int Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                OnPeroertyChange("Balance");
            }
        }

        public virtual ReceiptAndIssueCardInformation ReceiptAndIssueCardInformation { get; set; }

        #region Private Variables

        private int _balance;
        private DateTime _entryDate;
        private Int64 _id;
        private int _issued;
        private string _mrrorSrNo;
        private int _received;

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
                    case "MrrOrSrNo":
                        if (String.IsNullOrEmpty(MrrOrSrNo) || String.IsNullOrWhiteSpace(MrrOrSrNo))
                        {
                            errorMessagess = "Please enter MRR/SR No.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}