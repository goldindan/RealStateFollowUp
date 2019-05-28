﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        {
            IEnumerable<SelectListItem> ret = from item in items
                                 select new SelectListItem
                                 {
                                     Text = item.GetPropertyValue("Name"),
                                     Value = item.GetPropertyValue("ID"),
                                     Selected = item.GetPropertyValue("ID").Equals(selectedValue.ToString())
                                 };
            return ret;
        }
    }
}
