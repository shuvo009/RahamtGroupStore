using System.Data.Entity;
using RahamtGroupStore.Model.Migrations;

namespace RahamtGroupStore.Model.DatabaseModels
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
            : base("RaGrStoreDatabase")
        {
            
        }
        public DbSet<BreakdownCause> BreakdownCauses { get; set; }
        public DbSet<BreakdownType> BreakdownTypes { get; set; }
        public DbSet<CompanyInformation> CompaneyInformations { get; set; }
        public DbSet<MachineBreakdownInformation> MachineBreakdownInformations { get; set; }
        public DbSet<MachineInformation> MachineInformations { get; set; }
        public DbSet<MachineLedger> MachineLedgers { get; set; }
        public DbSet<OrdinaryType> OrdinaryTypes { get; set; }
        public DbSet<ReceiptAndIssueCard> ReceiptAndIssueCards { get; set; }
        public DbSet<ReceiptAndIssueCardInformation> ReceiptAndIssueCardInformations { get; set; }
        public DbSet<RepairCompaneyInformation> RepairCompaneyInformations { get; set; }
        public DbSet<SectionInformation> SectionInformations { get; set; }
        public DbSet<SendForRepair> SendForRepairs { get; set; }
        public DbSet<SparesInformation> SparesInformations { get; set; }
        public DbSet<StockRegister> StockRegisters { get; set; }
        public DbSet<SupplierInformation> SupplierInformations { get; set; }
        public DbSet<UnitInformation> UnitInformations { get; set; }
        public DbSet<IssueSpareParts> IssueSparePartses { get; set; }
        public DbSet<FaultSpareHistory> FaultSpareHistories { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RepositoryContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}