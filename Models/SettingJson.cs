namespace TechnologyASP.Models
{
    public class SettingJson
    {
        public string? RandomApi { get; set; }
        public Black? Settings { get; set; }
    }
    public class Black
    {
        public List<string>? BlackList { get; set; }
    }

}
