namespace CloudShopApp.Model.Entity
{
    // Класс "Заказ в магазине"
    public class Order
    {
        public int Id { get; set; }

        public string FeedbackContact { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Id} - {FeedbackContact} - {Description}";
        }
    }
}
