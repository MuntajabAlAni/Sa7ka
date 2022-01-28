using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sa7kaWin.Models
{
    public class SettingInfo
    {
        public int Id { get; set; }
        public bool OnStartUp { get; set; }
        public string KeyModifier1 { get; set; }
        public string Key1 { get; set; }
        public Keys Key1Value
        {
            get
            {
                return (Keys)Enum.Parse(typeof(Keys), Key1);
            }
        }
        public string KeyModifier2 { get; set; }
        public string Key2 { get; set; }
        public Keys Key2Value
        {
            get
            {
                return (Keys)Enum.Parse(typeof(Keys), Key2);
            }
        }
        public string KeyModifier3 { get; set; }
        public string Key3 { get; set; }
        public Keys Key3Value
        {
            get
            {
                return (Keys)Enum.Parse(typeof(Keys), Key3);
            }
        }
    }
}
