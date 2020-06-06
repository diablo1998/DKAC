﻿using DKAC.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DKAC.Models.InfoModel
{
    public class MenuInfo
    {
        public int id { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public byte? IsDeleted { get; set; }

        [StringLength(50)]
        public string MenuCode { get; set; }

        [StringLength(200)]
        public string MenuName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime? Date { get; set; }

        public List<MenuDetail> details { get; set; }
    }
}