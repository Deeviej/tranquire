﻿using System;
using System.Globalization;

namespace Tranquire.Selenium.Questions.Converters
{
    /// <summary>
    /// A converter that uses the given conversion function
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TConverted"></typeparam>
    public class GenericConverter<TSource, TConverted> : IConverter<TSource, TConverted>
    {
        public GenericConverter(Func<TSource, TConverted> convertFunction) : this((v, c) => convertFunction(v))
        {
            Guard.ForNull(convertFunction, nameof(convertFunction));
        }

        public GenericConverter(Func<TSource, CultureInfo, TConverted> convertFunction)
        {
            Guard.ForNull(convertFunction, nameof(convertFunction));
            ConvertFunction = convertFunction;
        }

        public Func<TSource, CultureInfo, TConverted> ConvertFunction { get; }

        public TConverted Convert(TSource source, CultureInfo culture)
        {
            return ConvertFunction(source, culture);
        }
    }
}