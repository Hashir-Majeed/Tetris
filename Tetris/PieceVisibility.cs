using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Tetris
{
    class PieceVisibility : IValueConverter
    {

        public object Convert(object value, Type targetType, object paramater, CultureInfo culture)
        {
            Visibility visible;

            if (value == null)
            {
                visible = Visibility.Hidden;
            }

            else visible = Visibility.Visible;

            return (Visibility)visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
        
}
