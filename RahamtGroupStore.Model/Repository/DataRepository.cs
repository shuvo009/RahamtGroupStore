using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.Model.Interfaces;

namespace RahamtGroupStore.Model.Repository
{
    public class DataRepository<T> : IRepository<T>, IDisposable
        where T : class, IEntity
    {
        private readonly RepositoryContext _repositoryContext;
        private DbSet<T> _dbSet;

        public DataRepository()
        {
            _repositoryContext = new RepositoryContext();
            _dbSet = _repositoryContext.Set<T>();
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_repositoryContext != null)
            {
                _repositoryContext.Dispose();
            }
            _dbSet = null;
        }

        #endregion

        #region IRepository<T> Members

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _repositoryContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _repositoryContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _repositoryContext.Entry(entity).State = EntityState.Modified;
            _repositoryContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _repositoryContext.Set<T>();
        }

        public T FindById(long id)
        {
            return _dbSet.Find(id);
        }

        public bool IsEntityExists(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Any(expression);
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }


        #endregion

        public UnitInformation GetUnitInfoById(Int64 id)
        {
            return _repositoryContext.UnitInformations.FirstOrDefault(x => x.Id == id);
        }

        public SectionInformation GetSectionInfoById(Int64 id)
        {
            return _repositoryContext.SectionInformations.FirstOrDefault(x => x.Id == id);
        }

        public MachineInformation GetMachineInfoById(Int64 id)
        {
            return _repositoryContext.MachineInformations.FirstOrDefault(x => x.Id == id);
        }

        public SparesInformation GetSparesInfoById(Int64 id)
        {
            return _repositoryContext.SparesInformations.FirstOrDefault(x => x.Id == id);
        }

        public SupplierInformation GetSupplierInfoById(Int64 id)
        {
            return _repositoryContext.SupplierInformations.FirstOrDefault(x => x.Id == id);
        }

        public RepairCompaneyInformation GetRepairCompanyById(Int64 id)
        {
            return _repositoryContext.RepairCompaneyInformations.FirstOrDefault(x => x.Id == id);
        }

        public MachineBreakdownInformation GetMachinBreakdownById(Int64 id)
        {
            return _repositoryContext.MachineBreakdownInformations.FirstOrDefault(x => x.Id == id);
        }

        public ReceiptAndIssueCardInformation GetReceiptIssueCardInfoById(Int64 id)
        {
            return _repositoryContext.ReceiptAndIssueCardInformations.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<ReceiptAndIssueCard> GetReceiptAndIssueCardsById(Int64 id)
        {
            return
                _repositoryContext.ReceiptAndIssueCardInformations.First(x => x.Id == id).ReceiptAndIssueCards.Take(10).AsQueryable();
        }

        public IQueryable<UnitInformation> GetUnits()
        {
            return _repositoryContext.UnitInformations.OrderBy(x=>x.UnitName);
        }

        public void ClearChanges(T entity)
        {
            _repositoryContext.Entry(entity).State = EntityState.Unchanged;
        }

        public IQueryable<BreakdownCause> GetBreakdownCauses()
        {
            return _repositoryContext.BreakdownCauses.OrderBy(x=>x.Cause);
        }

        public IQueryable<BreakdownType> GetBreakdownTypes()
        {
            return _repositoryContext.BreakdownTypes.OrderBy(x=>x.TypeName);
        }

        public IQueryable<OrdinaryType> GetOrdinaryTypes()
        {
            return _repositoryContext.OrdinaryTypes.OrderBy(x=>x.OrdType);
        }

        public IQueryable<UnitType> GetUnitTyes()
        {
            return _repositoryContext.UnitTypes.OrderBy(x => x.UnitName);
        }

        public void UpdateStockRegister(ObservableCollection<StockRegister> stockRegisters)
        {
            foreach (StockRegister stockRegister in stockRegisters)
            {
                stockRegister.SparesInformation.Quantity += stockRegister.Quantity;
                stockRegister.SparesInformation.Rate = stockRegister.Rate;
                stockRegister.SparesInformation.Amount = stockRegister.SparesInformation.Quantity*stockRegister.SparesInformation.Rate;
                stockRegister.Type = "Purchase";
                _repositoryContext.Entry(stockRegister).State = EntityState.Added;
            }
            _repositoryContext.SaveChanges();
        }

        public void UpdateSpareParts(ObservableCollection<IssueSpareParts> issueSparePartses)
        {
            foreach (IssueSpareParts issueSpare in issueSparePartses)
            {
                SparesInformation sparesInformation = issueSpare.SparesInformation;
                sparesInformation.Quantity -= issueSpare.Quantity;
                sparesInformation.Amount = sparesInformation.Quantity*sparesInformation.Rate;
                var stockReqister = new StockRegister
                                        {
                                            EntryDate = issueSpare.EntryDate,
                                            Quantity = issueSpare.Quantity,
                                            SparesInformation = issueSpare.SparesInformation,
                                            Type = "Issue",
                                            InvoiceNumber = "No Inv Num",
                                            Price = 0,
                                            Rate = 0
                                        };
                _repositoryContext.Entry(stockReqister).State = EntityState.Added;
                _repositoryContext.Entry(issueSpare).State = EntityState.Added;
            }
            _repositoryContext.SaveChanges();
        }

        public void AddMachinLedger(MachineLedger machineLedger)
        {
            _repositoryContext.Entry(machineLedger).State = EntityState.Added;
        }

        public void DeleteSendForRepairInfo(SendForRepair sendForRepair)
        {
            _repositoryContext.Entry(sendForRepair.MachineBreakdownInformation).State = EntityState.Deleted;
            _repositoryContext.Entry(sendForRepair).State = EntityState.Deleted;
            _repositoryContext.SaveChanges();
        }

        public void AddToFaultHistory(MachineBreakdownInformation machineBreakdownInformation)
        {
            var faultyHistory = new FaultSpareHistory
                                    {
                                        ActionTaken = machineBreakdownInformation.ActionTaken,
                                        BreakdownCause = machineBreakdownInformation.BreakdownCause,
                                        BreakdownType = machineBreakdownInformation.BreakdownType,
                                        EntryDate = machineBreakdownInformation.EntryDate,
                                        Image = machineBreakdownInformation.Image,
                                        MachineInformation = machineBreakdownInformation.MachineInformation,
                                        OrdinaryType = machineBreakdownInformation.OrdinaryType,
                                        ProblemDescription = machineBreakdownInformation.ProblemDescription,
                                        ReportedBy = machineBreakdownInformation.ReportedBy,
                                        SparesInformation = machineBreakdownInformation.SparesInformation
                                    };
            _repositoryContext.Entry(faultyHistory).State = EntityState.Added;
        }
    }
}