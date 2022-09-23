using Sa7kaWin.Enums;
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
        public bool OnStartUp { get; set; }
        public string KeyModifier1 { get; set; }
        public KeyModifier KeyModifier1Value
        {
            get
            {
                return (KeyModifier)Enum.Parse(typeof(KeyModifier), KeyModifier1);
            }
        }
        public string Key1 { get; set; }
        public Keys Key1Value
        {
            get
            {
                return (Keys)Enum.Parse(typeof(Keys), Key1);
            }
        }
        public string KeyModifier2 { get; set; }
        public KeyModifier KeyModifier2Value
        {
            get
            {
                return (KeyModifier)Enum.Parse(typeof(KeyModifier), KeyModifier2);
            }
        }
        public string Key2 { get; set; }
        public Keys Key2Value
        {
            get
            {
                return (Keys)Enum.Parse(typeof(Keys), Key2);
            }
        }
        public string KeyModifier3 { get; set; }
        public KeyModifier KeyModifier3Value
        {
            get
            {
                return (KeyModifier)Enum.Parse(typeof(KeyModifier), KeyModifier3);
            }
        }
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
