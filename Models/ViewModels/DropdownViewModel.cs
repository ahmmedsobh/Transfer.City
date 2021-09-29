using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transfer.City.Models.ViewModels
{
    public class DropdownViewModel<T>
    {
        public T Value { get; set; }
        public string Name { get; set; }
    }
}