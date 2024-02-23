using SoftTradeTEST.MVVM.Models.Enum;

using Type = SoftTradeTEST.MVVM.Models.Enum.Type;

namespace SoftTradeTEST.MVVM.Models

{
    internal class Product
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
