namespace Lab1_V2
{
    public class Customer
    {

        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;

        public bool CheckAge()
        {
            return Age >= 18 && Age <= 60;
        }




    }
}