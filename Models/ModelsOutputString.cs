using System.ComponentModel.DataAnnotations;

namespace TechnologyASP.Models
{
    public class ModelsOutputString
    {
        public string? Input { get; set; }
        public string? Result { get; set; }
        public Dictionary<char, int>? SymbolCount { get; set; }
        public string? FinalSubstring { get; set; }
        public string? SortedString { get; set; }
        public string? RemovedString { get; set; }
        public HashSet<char>? BadSymbol { get; set; }
    }

}
