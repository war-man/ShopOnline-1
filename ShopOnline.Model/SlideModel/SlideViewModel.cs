using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.SlideModel
{
    public class SlideViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decripstion { get; set; }
        public string Caption { get; set; }
        public int? ParentId { get; set; }
        public string PathImage { get; set; }
    }
}
