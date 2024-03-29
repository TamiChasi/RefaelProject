﻿using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class Range
    {
        private static int counter = 0;

        public int RangeId { get; }

        [Required]
        public decimal AerialLine { get; set; }
        [Required]
        public decimal Meters { get; set; }
        public Range(decimal aerialLine, decimal meters)
        {
            RangeId = ++counter;
            AerialLine = aerialLine;
            Meters = meters;
        }
        public Range()
        {

        }
    }
}
