using System;
using System.Globalization;
using System.Windows.Data;

namespace RahamtGroupStore.ViewModel.Converters
{
    public class ReturnableQuantity : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                // values[0] = send Quantity
                // values[1] = Receive Quantity
                return System.Convert.ToDouble((int) values[0] - (int) values[1]);
            }
            catch (Exception)
            {
                return default(double);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}