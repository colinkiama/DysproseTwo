﻿using DysproseTwo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DysproseTwo.Converters
{
    class SessionStateToPlayPauseLabel:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string label = "Play";
            if (value is DysproseSessionState sessionState)
            {
                switch (sessionState)
                {
                    case DysproseSessionState.InProgress:
                        label = "Pause";
                        break;
                }
            }

            return label;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
