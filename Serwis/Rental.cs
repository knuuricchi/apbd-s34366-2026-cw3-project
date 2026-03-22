namespace Serwis;

public class Rental
{
    public User User { get; set; }
    public Equipment Equipment { get; set; }

    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public override string ToString()
    {
        return $"{Equipment?.Name} dla {User} od {RentDate} do {DueDate}," +
               $" zwrot: {(ReturnDate?.ToShortDateString() ?? "brak")}";
    }
}
