using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace echarging.Models
{
    public class Kwh
    {
        [Key]
        public string Date { get; set; }

        public double T13 { get; set; }
        public double T14 { get; set; }
        public double T15 { get; set; }
        public double T16 { get; set; }
        public double T17 { get; set; }
        public double T18 { get; set; }
        public double T19 { get; set; }
        public double T20 { get; set; }
        public double T21 { get; set; }
        public double T22 { get; set; }
        public double T23 { get; set; }
        public double T00 { get; set; }
        public double T01 { get; set; }
        public double T02 { get; set; }
        public double T03 { get; set; }
        public double T04 { get; set; }
        public double T05 { get; set; }
        public double T06 { get; set; }
        public double T07 { get; set; }
        public double T08 { get; set; }
        public double T09 { get; set; }
        public double T10 { get; set; }
        public double T11 { get; set; }
        public double T12 { get; set; }
    }
}