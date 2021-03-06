﻿using GPSTriangulator.GPSMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSTriangulator.Model
{
    public class GPSDegree : IGPSCoordinateMath
    {
        public int degrees;
        public int minutes;
        public double seconds;

        public GPSDegree()
        {
        degrees = 0;
        minutes = 0;
        seconds = 0.0f;
        }

        public GPSDegree(int degrees, int minutes, double seconds)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public GPSDegree(double degrees)
        {
            FromDouble(degrees);
        }

        public void FromDouble(double ddegree)
        {
            var r = GPSMathProcessor.Get().DecimalToGPSDegree(ddegree);
            degrees = r.degrees;
            minutes = r.minutes;
            seconds = r.seconds;
        }

        public double ToDouble()
        {
            return GPSMathProcessor.Get().GPSDegreeToDecimal(this);
        }

        public static GPSDegree operator+(GPSDegree instance, GPSDegree other)
        {
            return new GPSDegree(instance.degrees + other.degrees, instance.minutes + other.minutes, instance.seconds + other.seconds);
        }

        public static bool operator ==(GPSDegree instance, GPSDegree other)
        {
            return (instance.degrees == other.degrees) && (instance.minutes == other.minutes) && ( Math.Abs(instance.seconds - other.seconds) <= 0.001 );
        }

        public static bool operator !=(GPSDegree instance, GPSDegree other)
        {
            return instance == other;
        }

        //[AH] Not changing this until it makes sense
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
