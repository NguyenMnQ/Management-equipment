using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EquipmentManagerment.Context;

namespace EquipmentManagerment.Areas.Admin.Models
{
    public class GetList
    {
        public List<ThietBi> ListEquip { get; set; }
        public List<NhanVien> ListEmploy { get; set; }
    }
}