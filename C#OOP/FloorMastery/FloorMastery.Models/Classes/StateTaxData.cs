namespace FloorMastery.Models
{
    public class StateTaxData
    {
        public string StatesAbbreviation { get; set; }
        public string StatesName { get; set; }
        public decimal TaxRate { get; set; }
        public override string ToString()
        {
            return StatesName;
        }
    }
}