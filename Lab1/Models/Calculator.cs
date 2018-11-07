using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    
    public class Calculator
    {
        [Range(0, double.MaxValue, ErrorMessage = "Only numbers allowed!")]
        [Display(Name = "Voltage")]
        public double Voltage { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Only numbers allowed!")]
        [Display(Name = "Resistance")]
        public double Resistance { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Only numbers allowed!")]
        [Display(Name = "Current")]
        public double Current { get; set; }

        [ScaffoldColumn(false)]
        public double VoltageResult { get; set; }

        [ScaffoldColumn(false)]
        public double ResistanceResult { get; set; }

        [ScaffoldColumn(false)]
        public double CurrentResult { get; set; }

        public Calculator()
        {

        }
    }
}