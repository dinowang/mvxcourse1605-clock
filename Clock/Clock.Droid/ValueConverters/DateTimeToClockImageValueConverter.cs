using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
//using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;

namespace Clock.Droid.ValueConverters
{
    public class DateTimeToClockImageValueConverter : MvxValueConverter<DateTime, Bitmap>
    {
        protected override Bitmap Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            var w = 300;
            var h = 300;
            var rw = 300 / 2;
            var rh = 300 / 2;
            var r = Math.Min(rw, rh);
            var hour = r * .6;
            var minute = r * .8;
            var second = r * .85;

            var bitmap = Bitmap.CreateBitmap(new DisplayMetrics(), w, h, Bitmap.Config.Alpha8);
            var canvas = new Canvas(bitmap);

            var gray = new Paint(PaintFlags.AntiAlias)
            {
                Color = Color.Gray,
                Alpha = 128,
            };
            gray.SetStyle(Paint.Style.Stroke);

            var red = new Paint(PaintFlags.AntiAlias)
            {
                Color = Color.Red,
            };
            red.SetStyle(Paint.Style.Stroke);

            var black3 = new Paint(PaintFlags.AntiAlias)
            {
                Color = Color.Black,
                StrokeWidth = 3
            };
            black3.SetStyle(Paint.Style.Stroke);

            var black5 = new Paint(PaintFlags.AntiAlias)
            {
                Color = Color.Black,
                StrokeWidth = 5
            };
            black5.SetStyle(Paint.Style.Stroke);

            canvas.DrawCircle(rw, rh, r, gray);

            var radius = ToRadius(value.Hour, 12);
            var x2 = rw + hour * Math.Cos(radius);
            var y2 = rw + hour * Math.Sin(radius);

            canvas.DrawLine(rw, rh, (float)x2, (float)y2, black5);

            radius = ToRadius(value.Minute, 60);
            x2 = rw + minute * Math.Cos(radius);
            y2 = rw + minute * Math.Sin(radius);

            canvas.DrawLine(rw, rh, (float)x2, (float)y2, black3);

            radius = ToRadius(value.Second, 60);
            x2 = rw + second * Math.Cos(radius);
            y2 = rw + second * Math.Sin(radius);

            canvas.DrawLine(rw, rh, (float)x2, (float)y2, red);

            return bitmap;
        }

        private double ToRadius(int value, int maxValue) => (value * (360 / maxValue) - 90) * (Math.PI / 180);
    }
}