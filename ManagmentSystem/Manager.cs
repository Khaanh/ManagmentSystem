namespace ManagmentSystem
{
    internal class Manager
    {
        public List<Person> people;

        public Manager()
        {
            people = new List<Person>();
            PrintMenu();
        }

        public void PrintMenu()
        {
            Console.WriteLine("Welcome to my management system!" + Environment.NewLine);
            Console.WriteLine("1. Print all user");
            Console.WriteLine("2. Add user");
            Console.WriteLine("3. Edit user");
            Console.WriteLine("4. Search user");
            Console.WriteLine("5. Remove user");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your menu option: ");

            bool tryParse = int.TryParse(Console.ReadLine(), out int menuOption);

            if (!tryParse)
            {
                Console.WriteLine(menuOption);

                if (menuOption == 1)
                {
                    PrintAll();
                } else if (menuOption == 2)
                {
                    AddPerson();
                } else if (menuOption == 3)
                {
                    EditPerson();
                } else if (menuOption == 4)
                {
                    SearchPerson();
                } else if (menuOption == 5)
                {
                    RemovePerson();
                }
            }
            else
            {
                Console.WriteLine("Incorrect menu choice.");
                Console.WriteLine("Press <Enter> to try again.");
                Console.ReadLine();
                Console.Clear();
                PrintMenu();
            }
          
            Console.WriteLine(menuOption);
        }

        public void PrintAll()
        {
            people.ForEach(delegate (Person person)
            {
                Console.WriteLine(person.ReturnDetails());
            });
        }
        public void AddPerson() {}
        public void EditPerson() {}
        public void SearchPerson() {}
        public void RemovePerson() {}

    }
}
