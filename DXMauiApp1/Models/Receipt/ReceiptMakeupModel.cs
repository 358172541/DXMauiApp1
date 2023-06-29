﻿using System.ComponentModel.DataAnnotations;

namespace DXMauiApp1.Models
{
    public class ReceiptMakeupModel
    {
        public long Id { get; set; }

        public decimal? Length { get; set; }

        public decimal? Height { get; set; }

        public string MemberNumber { get; set; }

        public string WaybillNumber { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Width { get; set; }
    }
}