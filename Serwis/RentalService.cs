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
    
    public void AddUser(User user)
    {
        users.Add(user);
    }
    
    public void RentEquipment(User user, Equipment equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            Console.WriteLine("Sprzet jest niedostepny do wypozyczenia! ");
            return;
        }
        
        equipment.Status = EquipmentStatus.Rented;
        var now = DateTime.Now;
        rentals.Add(new Rental {
            User = user,
            Equipment = equipment,
            RentDate = now,
            DueDate = now.AddDays(days)
        });
    }
}