namespace Serwis;

public class RentalService
{
    private const int STUDENT_LIMIT = 2;
    private const int EMPLOYEE_LIMIT = 5;
    private const double PENALTY = 1.5;

    List<Equipment> equipments = new List<Equipment>();
    List<Rental> _rentals = new List<Rental>();
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
    
    public void showUsers()
    {
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
    
    public void RentEquipment(User user, Equipment equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.AVAILABLE)
        {
            Console.WriteLine("Sprzet jest niedostepny do wypozyczenia! ");
            return;
        }

        int activeRentals = _rentals.Count(
            r => r.User.Id == user.Id && r.ReturnDate == null);
        int userLimit = user.UserType == UserType.STUDENT ? STUDENT_LIMIT : EMPLOYEE_LIMIT;
        if (activeRentals >= userLimit)
        {
            Console.WriteLine($"Uzytkownik przekroczyl limit wypozyczen: {userLimit}");
            return;
        }

        equipment.Status = EquipmentStatus.RENTED;
        var now = DateTime.Now;
        _rentals.Add(new Rental {
            User = user,
            Equipment = equipment,
            RentDate = now,
            DueDate = now.AddDays(days)
        });
    }
    
    public void ReturnEquipment(Equipment equipment)
    {
        var rental = _rentals.FirstOrDefault(
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
                double totalPenalty = delayDays * PENALTY;
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
    
    public void ShowUserRentals(User user)
    {
        var userActiveRentals = _rentals.Where(
            r => r.User.Id == user.Id && r.ReturnDate == null);
        Console.WriteLine($"Aktywne wypożyczenia dla użytkownika: {user.FirstName} {user.LastName}");
        foreach (var rental in userActiveRentals)
        {
            Console.WriteLine(rental);
        }
    }
    
    public void ShowAllRentals()
    {
        var activeRentals = _rentals.Where(
            r => r.ReturnDate == null);
        foreach (var rental in activeRentals)
            Console.WriteLine(rental);
    }
    
    public void showOverdueRentals()
    {
        var overdueRentals = _rentals.Where(
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
        Console.WriteLine($"Aktualne wypozyczenia: {_rentals.Count(r => r.ReturnDate == null)}");
    }

    public User GetUserById(Guid id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }

    public Equipment GetEquipmentById(Guid id)
    {
        return equipments.FirstOrDefault(e => e.Id == id);
    }
}