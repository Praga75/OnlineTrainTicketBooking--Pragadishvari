
namespace OnlineTrainTicketBooking
{
    class Train
    {
        public string TrainName { get; set; }
        public double TicketPrice { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public int TicketsAvailable { get; set; }
        public Train(string name, double price, string sourceCity, string destinationCity, int ticketsavailable)
        {
            this.TrainName = name;
            this.TicketPrice = price;
            this.SourceCity = sourceCity;
            this.DestinationCity = destinationCity;
            this.TicketsAvailable = ticketsavailable;
        }

    }
}
