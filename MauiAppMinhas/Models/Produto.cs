using SQLite;

namespace MauiAppMinhas.Models
{
    public class Product
    {
        string _description;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Description
        {
            get => _description;
            set
            {
                if (value == null)
                {
                    throw new Exception("Please, fill the fields");
                }

                _description = value;
            }
        }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Total { get => Convert.ToDouble(Amount) * Price; }
    }
}