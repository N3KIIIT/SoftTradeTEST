using SoftTradeTEST.Models.Enum;
using Type = SoftTradeTEST.Models.Enum.Type;

namespace SoftTradeTEST.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public SubscriptionPeriod Period { get; set; }

        public override string ToString()
        {
            return ($"{Name}({Type}-{Period})");
        }
    }
}
