using System;
using System.Collections.Generic;
using System.Text;

namespace PlazaProject
{
    class ClothingProduct:Product
    {
        public string Material { get; }
        public string Type { get; }
        public ClothingProduct(long Barcode,string Name,string Manufacturer,string Material,string Type) :base(Barcode,Name,Manufacturer)
        {
            this.Material = Material;
            this.Type = Type;
        }

    }
}
