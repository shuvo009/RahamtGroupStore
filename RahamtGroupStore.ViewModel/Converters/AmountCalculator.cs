using RahamtGroupStore.ViewModel.ViewModel;
using System;
using System.Globalization;
using System.Windows.Data;

namespace RahamtGroupStore.ViewModel.Converters
{
    public class AmountCalculator : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var amount =(int)values[1]*(decimal) values[2];
                var purchaseVm = values[0] as PurchaseVm;
                if (purchaseVm != null) purchaseVm.SelectedItem.Price = amount;
                return amount.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}