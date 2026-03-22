namespace Serwis;

public class UI
{
    private RentalService serwisApp = new RentalService();

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- SYSTEM WYPOZYCZALNI ---");
            Console.WriteLine("1. Dodaj uzytkownika");
            Console.WriteLine("2. Wyswietl uzytkownikow");
            Console.WriteLine("3. Dodaj Sprzet");
            Console.WriteLine("4. Wyswietl sprzet");
            Console.WriteLine("5. Wypozycz sprzet");
            Console.WriteLine("6. Zwroc sprzet");
            Console.WriteLine("7. Raport");
            Console.WriteLine("8. Wyswietl tylko dostepny sprzet");
            Console.WriteLine("9. Oznacz sprzet jako niedostepny");
            Console.WriteLine("10. Wyswietl aktywne wypozyczenia uzytkownika");
            Console.WriteLine("11. Wyswietl wszystkie aktywne wypozyczenia");
            Console.WriteLine("12. Wyswietl przeterminowane wypozyczenia");
            Console.WriteLine("0. Wyjscie");
            Console.Write("Wybor: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddUserMenu(); break;
                case "2": serwisApp.showUsers(); break;
                case "3": AddEquipmentMenu(); break;
                case "4": serwisApp.showEquipment(); break;
                case "5": RentMenu(); break;
                case "6": ReturnMenu(); break;
                case "7": serwisApp.generateRaport(); break;
                case "8": serwisApp.showAvailableEquipment(); break;
                case "9": SetEquipmentUnavailableMenu(); break;
                case "10": ShowUserRentalsMenu(); break;
                case "11": serwisApp.ShowAllRentals(); break;
                case "12": serwisApp.showOverdueRentals(); break;
                case "0": running = false; break;
            }
        }
    }

    private void AddUserMenu()
    {
        Console.WriteLine("1. Student, 2. Pracownik");
        string type = Console.ReadLine();
        Console.Write("Imie: "); string fn = Console.ReadLine();
        Console.Write("Nazwisko: "); string ln = Console.ReadLine();

        if (type == "1") serwisApp.AddUser(new Student(fn, ln));
        else serwisApp.AddUser(new Employee(fn, ln));
        Console.WriteLine("Dodano uzytkownika.");
    }

    private void AddEquipmentMenu()
    {
        Console.WriteLine("1. Laptop, 2. Camera, 3. Projector");
        string type = Console.ReadLine();
        Console.Write("Nazwa sprzetu: "); string name = Console.ReadLine();

        Equipment eq = type switch
        {
            "1" => new Laptop(name),
            "2" => new Camera(name),
            "3" => new Projector(name),
            _ => null
        };
        
        if (eq == null)
        {
            Console.WriteLine("Nieprawidlowy wybor typu sprzetu! ");
            return;
        }
        serwisApp.AddEquipment(eq);
        Console.WriteLine("Dodano sprzet.");
    }

    private void RentMenu()
    {
        Console.Write("Podaj ID uzytkownika: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid userId))
        {
            Console.WriteLine("Bledny ID");
            return;
        }
        
        var user = serwisApp.GetUserById(userId);
        
        if (user == null)
        {
            Console.WriteLine("Nie znaleziono uzytkownika");
            return;
        }
        
        Console.Write("Podaj ID sprzetu: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid eqId))
        {
            Console.WriteLine("Bledny ID");
            return;
        }
        var eq = serwisApp.GetEquipmentById(eqId);
        if (eq == null)
        {
            Console.WriteLine("Nie znaleziono sprzetu");
            return;
        }
        Console.Write("Na ile dni: ");
        int days = int.Parse(Console.ReadLine());
        if (days <= 0) { 
            Console.WriteLine("Bledna liczba dni"); 
            return; 
        }
        serwisApp.RentEquipment(user, eq, days);
    }

    private void ReturnMenu()
    {
        Console.Write("Podaj ID sprzetu do zwrotu: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid eqId)) { Console.WriteLine("Bledny ID");
            return; }
        var eq = serwisApp.GetEquipmentById(eqId);
        if (eq == null)
        {
            Console.WriteLine("Nie znaleziono sprzetu");
            return;
        }
        serwisApp.ReturnEquipment(eq);
    }

    private void SetEquipmentUnavailableMenu()
    {
        Console.Write("Podaj ID sprzetu do oznaczenia jako niedostepny: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid eqId)) { 
            Console.WriteLine("Bledny ID"); 
            return; 
        }
        var eq = serwisApp.GetEquipmentById(eqId);
        if (eq == null)
        {
            Console.WriteLine("Nie znaleziono sprzetu"); 
            return;
        }
        serwisApp.setEquipmentUnavailable(eq);
        Console.WriteLine("Sprzet oznaczony jako niedostepny.");
    }

    private void ShowUserRentalsMenu()
    {
        Console.Write("Podaj ID uzytkownika: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid userId)) { Console.WriteLine("Bledny ID");
            return; }
        var user = serwisApp.GetUserById(userId);
        if (user == null) { Console.WriteLine("Nie znaleziono uzytkownika");
            return; }
        serwisApp.ShowUserRentals(user);
    }
}