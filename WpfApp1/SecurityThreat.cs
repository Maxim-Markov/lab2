using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class SecurityThreat
    {
        private string id;
        public string Id { get
            {
                return id;
            }
            set
            {
                id = "УБИ." + value;
            }
        }
        public string Name { get; set; }
        internal string Description { get; set; }
        internal string Source { get; set; }
        internal string ImpactObj { get; set; }
        internal bool IsConfidentialityViolat { get; set; }
        internal bool IsIntegrityViolat { get; set; }
        internal bool IsAccessibilityViolat { get; set; }

        public SecurityThreat(string id, string name, string description, string source, string impactObj, bool isConfidentialityViolat, bool isIntegrityViolat, bool isAccessibilityViolat)
        {
            Id = id;
            Name = name;
            Description = description;
            Source = source;
            ImpactObj = impactObj;
            IsConfidentialityViolat = isConfidentialityViolat;
            IsIntegrityViolat = isIntegrityViolat;
            IsAccessibilityViolat = isAccessibilityViolat;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
