using RahamtGroupStore.Model.DatabaseModels;

namespace RahamtGroupStore.View.Reports
{
    partial class FaultyListReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.FaultyDataSource = new Telerik.Reporting.ObjectDataSource();
            this.group2 = new Telerik.Reporting.Group();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.group3 = new Telerik.Reporting.Group();
            this.groupFooterSection3 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection3 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox16 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20007896423339844D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox8});
            this.detail.Name = "detail";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000788688659668D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0749211311340332D), Telerik.Reporting.Drawing.Unit.Inch(0.19999991357326508D));
            this.textBox9.StyleName = "DetailsStyle";
            this.textBox9.Value = "=Fields.SparesInformation.PartName";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8750789165496826D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0249214172363281D), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343D));
            this.textBox10.StyleName = "DetailsStyle";
            this.textBox10.Value = "=Fields.SparesInformation.Partno";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9000790119171143D), Telerik.Reporting.Drawing.Unit.Inch(7.8731114626862109E-05D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999211549758911D), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343D));
            this.textBox11.StyleName = "DetailsStyle";
            this.textBox11.Value = "=Fields.MachineInformation.Name";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2000794410705566D), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87452572584152222D), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343D));
            this.textBox12.StyleName = "DetailsStyle";
            this.textBox12.Value = "=Fields.MachineInformation.Model";
            // 
            // textBox8
            // 
            this.textBox8.Format = "{0:d}";
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.925078809261322D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87492126226425171D), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343D));
            this.textBox8.StyleName = "DetailsStyle";
            this.textBox8.Value = "=Fields.EntryDate";
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
            this.textBox3,
            this.textBox4,
            this.textBox2,
            this.textBox5,
            this.textBox6,
            this.textBox1,
            this.textBox7});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            this.groupHeaderSection1.PrintOnEveryPage = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.004999999888241291D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.92000001668930054D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox3.StyleName = "GroupHeaderStyle";
            this.textBox3.Value = "Unit / Section";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0749211311340332D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox4.StyleName = "GroupHeaderStyle";
            this.textBox4.Value = "Part Name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.875D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0250003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox2.StyleName = "GroupHeaderStyle";
            this.textBox2.Value = "Part No";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9000790119171143D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999210357666016D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox5.StyleName = "GroupHeaderStyle";
            this.textBox5.Value = "Machin Name";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2000794410705566D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87452572584152222D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox6.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.StyleName = "GroupHeaderStyle";
            this.textBox6.Value = "Model";
            // 
            // textBox1
            // 
            this.textBox1.Docking = Telerik.Reporting.DockingStyle.Top;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.0746440887451172D), Telerik.Reporting.Drawing.Unit.Inch(0.29988190531730652D));
            this.textBox1.StyleName = "HeaderStyle";
            this.textBox1.Value = "Faulty List";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.925078809261322D), Telerik.Reporting.Drawing.Unit.Inch(0.29996061325073242D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87492120265960693D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.textBox7.StyleName = "GroupHeaderStyle";
            this.textBox7.Value = "Date";
            // 
            // FaultyDataSource
            // 
            this.FaultyDataSource.DataSource = typeof(MachineBreakdownInformation);
            this.FaultyDataSource.Name = "FaultyDataSource";
            // 
            // group2
            // 
            this.group2.GroupFooter = this.groupFooterSection2;
            this.group2.GroupHeader = this.groupHeaderSection2;
            this.group2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("= Fields.MachineInformation.UnitInformation.UnitName")});
            this.group2.Name = "group2";
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection2.Name = "groupFooterSection2";
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.19999980926513672D);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox15});
            this.groupHeaderSection2.Name = "groupHeaderSection2";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0050000082701444626D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.92000001668930054D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox15.StyleName = "GroupingStyle";
            this.textBox15.Value = "=Fields.MachineInformation.UnitInformation.UnitName + \" \\\"";
            // 
            // group3
            // 
            this.group3.GroupFooter = this.groupFooterSection3;
            this.group3.GroupHeader = this.groupHeaderSection3;
            this.group3.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("= Fields.MachineInformation.SectionInformation.SectionName")});
            this.group3.Name = "group3";
            // 
            // groupFooterSection3
            // 
            this.groupFooterSection3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection3.Name = "groupFooterSection3";
            // 
            // groupHeaderSection3
            // 
            this.groupHeaderSection3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D);
            this.groupHeaderSection3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox16});
            this.groupHeaderSection3.Name = "groupHeaderSection3";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0050000082701444626D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.91999995708465576D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox16.StyleName = "GroupingStyle";
            this.textBox16.Value = "=Fields.MachineInformation.SectionInformation.SectionName";
            // 
            // FaultyListReport
            // 
            this.DataSource = this.FaultyDataSource;
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1,
            this.group2,
            this.group3});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.groupHeaderSection3,
            this.groupFooterSection3,
            this.detail});
            this.Name = "FaultyListReport";
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
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("HeaderStyle")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            styleRule2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("GroupHeaderStyle")});
            styleRule3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            styleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule3.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            styleRule3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            styleRule3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(4D);
            styleRule3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule3.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("DetailsStyle")});
            styleRule4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            styleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            styleRule4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            styleRule4.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            styleRule4.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            styleRule4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(4D);
            styleRule4.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule4.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("GroupingStyle")});
            styleRule5.Style.Font.Bold = true;
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.0746440887451172D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        public Telerik.Reporting.ObjectDataSource FaultyDataSource;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.Group group2;
        private Telerik.Reporting.GroupFooterSection groupFooterSection2;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection2;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.Group group3;
        private Telerik.Reporting.GroupFooterSection groupFooterSection3;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection3;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox8;
    }
}