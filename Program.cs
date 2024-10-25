namespace Automobile_showroom
{
    public class vehicle
    {
        public string Model { get; set; }
        public double BasePrice { get; set; }

        public vehicle(string model, double baseprice)
        {
            Model = model;
            BasePrice = baseprice;
        }
        public virtual double CalculatePrice()
        {
            return BasePrice;
        }
    }
    public class Car:vehicle
    {
        public Car(string Model, double BasePrice) : base(Model, BasePrice) { }
    }
    public class Motorcycle:vehicle
    {
        public Motorcycle(string model,double baseprice): base(model, baseprice) { }
    }
    public class Invoice
    {
        public vehicle vehicle { get; set; }
        public List<string> Accessories { get; set; }

        public Invoice(vehicle vehicle)
        {
            vehicle = vehicle;
            Accessories = new List<string>();
        }
        public virtual double CalculatePrice()
        {
            double total = vehicle.CalculatePrice();
            return total;
        }
        public void PrintInvoice()
        {
            Console.WriteLine($"Model:{vehicle.Model}");
            Console.WriteLine($"BasePrice:$vehicle.BasePrice");
            Console.WriteLine($"Accessories: {string.Join(", ", Accessories)}");
            Console.WriteLine($"Total Price: ${CalculatePrice()}");
        }
    }
    public class LoanInvoice : Invoice
    {
        public double InterestRate { get; set; }
        public int LoanTermMonths { get; set; }

        public LoanInvoice(vehicle vehicle, double interestRate, int loanTermMonths):base(vehicle)
        {
            InterestRate = interestRate;
            LoanTermMonths = loanTermMonths;
        }
        public override double CalculatePrice()
        { 
            double basePrice = vehicle.CalculatePrice();
            double interest = basePrice * (InterestRate / 100) * (LoanTermMonths / 12.0);
            return basePrice + interest;
        }
        public override void PrintInvoice()
        {
            base.PrintInvoice();
            Console.WriteLine($"InterestRate:{InterestRate}%");
            Console.WriteLine($"LoanTerm: {LoanTermMonths} months");
            Console.WriteLine($"Total price with interest:${CalculatePrice()}");
        }
    }
     class Program
    {
        static void Main(string[] args)
        {
            vehicle Car = new Car("Sedan", 25000);
            vehicle Motorcycle = new Motorcycle("sportbike", 15000);

            Invoice CarInvoice = new Invoice(Car);
            CarInvoice.AddAccessories("Leather seats");
            CarInvoice.AddAccessories("Navigation system ");
            CarInvoice.PrintInvoice();
            Console.WriteLine();

            LoanInvoice loanInvoice = new LoanInvoice(Motorcycle, 5.5, 24);
            loanInvoice.AddAccessories("External Warrenty");
            loanInvoice.PrintInvoice();
        

        }
    }
}
