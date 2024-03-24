namespace Lab5CloudServices.Models
{
    public class CloudService
    {
        public static Dictionary<string, double> InstanceSizePrices = new Dictionary<string, double>
        {
            { "Very Small", 0.02 },
            { "Small", 0.08 },
            { "Medium", 0.16 },
            { "Large", 0.32 },
            { "Very Large", 0.64 },
            { "A6", 0.90 },
            { "A7", 1.80 }
        };

        public int NoInstances { get; set; }

        public string InstanceSize { get; set; }

        public double Cost
        {
            get
            {
                if (!InstanceSizePrices.ContainsKey(this.InstanceSize))
                {
                    throw new ArgumentException("Instance is not found in prices");
                }

                double hourlyPrice = NoInstances * InstanceSizePrices[this.InstanceSize];
                double dailyPrice = hourlyPrice * 24;
                double yearlyPrice;

                if (DateTime.IsLeapYear(DateTime.Now.Year))
                {
                    yearlyPrice = dailyPrice * 366;
                }
                else
                {
                    yearlyPrice = dailyPrice * 365;
                }
                return yearlyPrice;
            }
        }

    }
}
