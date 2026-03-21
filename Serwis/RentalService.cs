namespace Serwis;

public class RentalService
{
    List<Equipment> equipments = new List<Equipment>();
    List<Rental> rentals = new List<Rental>();
    List<User> users = new List<User>();
    
    public void AddEquipment(Equipment equipment)
    {
        equipments.Add(equipment);
    }
    
    public void showEquipment()
    {
        foreach (var equipment in equipments)
        {
            Console.WriteLine(equipment);
        }
    }
    
    public void showAvailableEquipment()
    {
        foreach (var equipment in equipments.Where(
                     e => e.Status == EquipmentStatus.AVAILABLE))
        {
            Console.WriteLine(equipment);
        }
    }
    
    public void AddUser(User user)
    {
        users.Add(user);
    }
    
    public void RentEquipment(User user, Equipment equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.AVAILABLE)
        {
            Console.WriteLine("Sprzet jest niedostepny do wypozyczenia! ");
            return;
        }
        
        equipment.Status = EquipmentStatus.RENTED;
        var now = DateTime.Now;
        rentals.Add(new Rental {
            User = user,
            Equipment = equipment,
            RentDate = now,
            DueDate = now.AddDays(days)
        });
    }
    
    public void ReturnEquipment(Equipment equipment)
    {
        var rental = rentals.FirstOrDefault(
            r => r.Equipment.Id == equipment.Id && r.ReturnDate == null
            );
    
        if (rental == null)
        {
            Console.WriteLine("Ten sprzet nie jest wypozyczony! ");
            return;
        }

        rental.ReturnDate = DateTime.Now;
        equipment.Status = EquipmentStatus.AVAILABLE;

        if (rental.ReturnDate > rental.DueDate)
        {
            TimeSpan delay = rental.ReturnDate.Value - rental.DueDate;
            int delayDays = delay.Days;

            if (delayDays > 0)
            {
                double penaltyRate = 10.0;
                double totalPenalty = delayDays * penaltyRate;
                Console.WriteLine($"Opoznienie zwrotu: {delayDays} dni. Kara: {totalPenalty} zł. ");
            }
        }
        else 
        {
            Console.WriteLine("Sprzet zwrocony w terminie! ");
        }
    }
    
    public void setEquipmentUnavailable(Equipment equipment)
    {
        equipment.Status = EquipmentStatus.UNAVAILABLE;
    }
    
    public void ShowActiveRentals()
    {
        var activeRentals = rentals.Where(
            r => r.ReturnDate == null);
        foreach (var rental in activeRentals)
            Console.WriteLine(rental);
    }
    
    public void showOverdueRentals()
    {
        var overdueRentals = rentals.Where(
            r => r.ReturnDate == null && r.DueDate < DateTime.Now);
        foreach (var rental in overdueRentals)
            Console.WriteLine(rental);
    }

    public void generateRaport()
    {
        Console.WriteLine("--- RAPORT STANU WYPOZYCZALNI ---");
        Console.WriteLine($"Calkowita liczba sprzetu: {equipments.Count}");
        Console.WriteLine($"Dostepny sprzet: {equipments.Count(e => e.Status == EquipmentStatus.AVAILABLE)}");
        Console.WriteLine($"Wypozyczony sprzet: {equipments.Count(e => e.Status == EquipmentStatus.RENTED)}");
        Console.WriteLine($"Brakujacy sprzet: {equipments.Count(e => e.Status == EquipmentStatus.UNAVAILABLE)}");
        Console.WriteLine($"Aktualne wypozyczenia: {rentals.Count(r => r.ReturnDate == null)}");
    }
}