using RahamtGroupStore.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class MachineBreakdownInformation : ModelBase, IDataErrorInfo,IEntity
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
        public virtual string ReportedBy
        {
            get { return _reportedby; }
            set
            {
                _reportedby = value;
                OnPeroertyChange("ReportedBy");
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
        public virtual string ProblemDescription
        {
            get { return _problemDescription; }
            set
            {
                _problemDescription = value;
                OnPeroertyChange("ProblemDescription");
            }
        }


        [Required]
        public virtual string ActionTaken
        {
            get { return _actionTaken; }
            set
            {
                _actionTaken = value;
                OnPeroertyChange("ActionTaken");
            }
        }


        public virtual byte[] Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPeroertyChange("Image");
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

        public virtual SparesInformation SparesInformation
        {
            get { return _sparesInformation; }
            set
            {
                _sparesInformation = value;
                OnPeroertyChange("SparesInformation");
            }
        }  

        public virtual BreakdownCause BreakdownCause { get; set; }
        public virtual BreakdownType BreakdownType { get; set; }
        public virtual OrdinaryType OrdinaryType { get; set; }

        #region Private Variables

        private string _actionTaken;
        private Int64 _id;
        private byte[] _image;
        private string _problemDescription;
        private string _reportedby;
        private DateTime _entryDate;
        private SparesInformation _sparesInformation;
        private MachineInformation _machineInformation;
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
                    case "ReportedBy":
                        if (String.IsNullOrEmpty(ReportedBy) || String.IsNullOrWhiteSpace(ReportedBy))
                        {
                            errorMessagess = "Please enter ReportedBy.";
                        }
                        break;
                    case "ProblemDescription":
                        if (String.IsNullOrEmpty(ProblemDescription) || String.IsNullOrWhiteSpace(ProblemDescription))
                        {
                            errorMessagess = "Please enter Problem Description.";
                        }
                        break;
                    case "ActionTaken":
                        if (String.IsNullOrEmpty(ActionTaken) || String.IsNullOrWhiteSpace(ActionTaken))
                        {
                            errorMessagess = "Please enter which Action will be Taken.";
                        }
                        break;
                }
                return errorMessagess;
            }
        }

        #endregion
    }
}