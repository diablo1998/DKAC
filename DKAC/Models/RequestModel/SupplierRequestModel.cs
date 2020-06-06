using DKAC.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DKAC.Models.RequestModel
{
    public class SupplierRequestModel : BaseModel
    {
        public string KeyWord { get; set; }
        public List<Supplier> data { get; set; }
    }
}