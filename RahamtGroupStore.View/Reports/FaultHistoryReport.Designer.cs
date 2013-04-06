using RahamtGroupStore.Model.DatabaseModels;

namespace RahamtGroupStore.View.Reports
{
    partial class FaultHistoryReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.FaultHistoryDataSource = new Telerik.Reporting.ObjectDataSource();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.group2 = new Telerik.Reporting.Group();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.group3 = new Telerik.Reporting.Group();
            this.groupHeaderSection3 = new Telerik.Reporting.GroupHeaderSection();
            this.groupFooterSection3 = new Telerik.Reporting.GroupFooterSection();
            this.textBox9 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003969967365265D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14});
            this.detail.Name = "detail";
            // 
            // FaultHistoryDataSource
            // 
            this.FaultHistoryDataSource.DataSource = typeof(FaultSpareHistory);
            this.FaultHistoryDataSource.Name = "FaultHistoryDataSource";
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Name = "group1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox1,
            this.textBox6,
            this.textBox5,
            this.textBox2,
            this.textBox4,
            this.textBox3});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            this.groupHeaderSection1.PrintOnEveryPage = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.92500019073486328D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87492120265960693D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox7.StyleName = "GroupHeaderStyle";
            this.textBox7.Value = "Date";
            // 
            // textBox1
            // 
            this.textBox1.Docking = Telerik.Reporting.DockingStyle.Top;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.0807762145996094D), Telerik.Reporting.Drawing.Unit.Inch(0.29988190531730652D));
            this.textBox1.StyleName = "HeaderStyle";
            this.textBox1.Value = "Faulty History";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2062501907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87452572584152222D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox6.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.StyleName = "GroupHeaderStyle";
            this.textBox6.Value = "Model";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9041669368743896D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999210357666016D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox5.StyleName = "GroupHeaderStyle";
            this.textBox5.Value = "Machin Name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8790876865386963D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0250003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox2.StyleName = "GroupHeaderStyle";
            this.textBox2.Value = "Part No";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0749211311340332D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox4.StyleName = "GroupHeaderStyle";
            this.textBox4.Value = "Part Name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.92000001668930054D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox3.StyleName = "GroupHeaderStyle";
            this.textBox3.Value = "Unit / Section";
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:d}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.92500019073486328D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87492114305496216D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox10.StyleName = "DetailsStyle";
            this.textBox10.Value = "=Fields.EntryDate";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(3.9577484130859375E-05D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0749210119247437D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox11.StyleName = "DetailsStyle";
            this.textBox11.Value = "=Fields.SparesInformation.PartName";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8790876865386963D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0250002145767212D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox12.StyleName = "DetailsStyle";
            this.textBox12.Value = "=Fields.SparesInformation.Partno";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9041669368743896D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999210357666016D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox13.StyleName = "DetailsStyle";
            this.textBox13.Value = "=Fields.MachineInformation.Name";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2062506675720215D), Telerik.Reporting.Drawing.Unit.Inch(3.9577484130859375E-05D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.874485969543457D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox14.StyleName = "DetailsStyle";
            this.textBox14.Value = "=Fields.MachineInformation.Model";
            // 
            // group2
            // 
            this.group2.GroupFooter = this.groupFooterSection2;
            this.group2.GroupHeader = this.groupHeaderSection2;
            this.group2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("= Fields.MachineInformation.UnitInformation.UnitName")});
            this.group2.Name = "group2";
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20007880032062531D);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox8});
            this.groupHeaderSection2.Name = "groupHeaderSection2";
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection2.Name = "groupFooterSection2";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(7.8757606388535351E-05D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.92000013589859009D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox8.StyleName = "GroupingStyle";
            this.textBox8.Value = "=Fields.MachineInformation.UnitInformation.UnitName +\"\\\"";
            // 
            // group3
            // 
            this.group3.GroupFooter = this.groupFooterSection3;
            this.group3.GroupHeader = this.groupHeaderSection3;
            this.group3.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("= Fields.MachineInformation.SectionInformation.SectionName")});
            this.group3.Name = "group3";
            // 
            // groupHeaderSection3
            // 
            this.groupHeaderSection3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20007865130901337D);
            this.groupHeaderSection3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox9});
            this.groupHeaderSection3.Name = "groupHeaderSection3";
            // 
            // groupFooterSection3
            // 
            this.groupFooterSection3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection3.Name = "groupFooterSection3";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D), Telerik.Reporting.Drawing.Unit.Inch(7.8757606388535351E-05D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.91996079683303833D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox9.StyleName = "GroupingStyle";
            this.textBox9.Value = "=Fields.MachineInformation.SectionInformation.SectionName";
            // 
            // FaultHistoryReport
            // 
            this.DataSource = this.FaultHistoryDataSource;
            this.ExternalStyleSheets.Add(new Telerik.Reporting.Drawing.ExternalStyleSheet("StyleSheets\\TelerikReportingStyleSheet.xml"));
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1,
            this.group2,
            this.group3});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail,
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.groupHeaderSection3,
            this.groupFooterSection3});
            this.Name = "FaultHistoryReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.0807762145996094D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        public Telerik.Reporting.ObjectDataSource FaultHistoryDataSource;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.Group group2;
        private Telerik.Reporting.GroupFooterSection groupFooterSection2;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection2;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.Group group3;
        private Telerik.Reporting.GroupFooterSection groupFooterSection3;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection3;
        private Telerik.Reporting.TextBox textBox9;
    }
}