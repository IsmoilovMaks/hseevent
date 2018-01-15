using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HSE_Event.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSourse { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string Title, string IconSourse, Type TargetType)
        {
            this.Title = Title;
            this.IconSourse = IconSourse;
            this.TargetType = TargetType;
        }
    }
}
