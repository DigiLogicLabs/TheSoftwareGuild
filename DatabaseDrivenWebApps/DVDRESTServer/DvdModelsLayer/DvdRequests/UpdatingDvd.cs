using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Build.Framework;

namespace DvdModelsLayer.DvdRequests
{
    public class UpdatingDvd
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Id { get; set; } 
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public string Notes { get; set; }
    }
}