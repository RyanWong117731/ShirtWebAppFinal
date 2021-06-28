using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShirtWebAppFinal.Models
{
    public class ShirtModel
    {
        public int ShirtModelId { get; set; }

        public string ShirtName { get; set; }
        public string FilePath { get; set; }
        public float Price { get; set; }
        public string Sizes { get; set; }

    }
}
