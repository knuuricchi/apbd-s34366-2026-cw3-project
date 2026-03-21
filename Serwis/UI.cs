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
            _ => new Projector(name)
        };
        
        serwisApp.AddEquipment(eq);
        Console.WriteLine("Dodano sprzet.");
    }

    private void RentMenu()
    {
        //TODO
    }

    private void ReturnMenu()
    {
        //TODO
    }
}