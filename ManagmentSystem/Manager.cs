namespace ManagmentSystem
{
    internal class Manager
    {
        public List<Person> people;

        public Manager()
        {
            people = new List<Person>(){};
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

            if (tryParse)
            {
                Console.WriteLine($"menuOption: {menuOption}");

                if (menuOption == 1)
                {
                    PrintAll();
                }
                else if (menuOption == 2)
                {
                    AddPerson();
                }
                else if (menuOption == 3)
                {
                    EditPerson();
                }
                else if (menuOption == 4)
                {
                    SearchPerson();
                }
                else if (menuOption == 5)
                {
                    RemovePerson();
                }

                PrintMenu();
            }
            else
            {
                OutputMessage("Incorrect menu choice.");
                PrintMenu();
            }
        }

        public void PrintAll()
        {
            StartOption("Printing all users: ");

            if (people.Count == 0)
            {
                Console.WriteLine("There are no users in the system, use option 1 to create a user");
            }
            else
            {
                for (int i = 0; i < people.Count(); i++)
                {
                    Console.WriteLine(i + 1 + ". " + people[i].ReturnDetails());
                }

            }

            FinishOption();

            //people.ForEach(delegate (Person person)
            //int i = 0;
            //{
            //    i++;
            //    Console.WriteLine($"{i}. {person.ReturnDetails()}");
            //});

            //people.ForEach((person) =>
            //{
            //    i++;
            //    Console.WriteLine($"{i}. {person.ReturnDetails()}");
            //});



        }
        public void AddPerson()
        {
            StartOption("Adding a user");

            try
            {
                Console.WriteLine("Enter a name: ");
                string nameInput = Console.ReadLine();

                Console.WriteLine("Enter an age: ");
                int ageInput = Convert.ToInt32(Console.ReadLine());

                if (!string.IsNullOrEmpty(nameInput))
                {
                    if (ageInput >= 0 && ageInput <= 150)
                    {
                        //Person person = new Person(nameInput, ageInput);
                        people.Add(new Person(nameInput, ageInput));

                        Console.WriteLine("Successfully added a person.");
                        FinishOption();
                    }
                    else
                    {
                        OutputMessage("Enter a sensible age.");
                        AddPerson();
                    }
                }
                else
                {
                    OutputMessage("You didn't enter a name.");
                    AddPerson();
                }

            }
            catch (Exception)
            {
                OutputMessage("Something has went wrong");
                AddPerson();
            }

        }
        public void EditPerson()
        {
            StartOption("Editing a users:");
            //check if people in system
            // print all
            // allow selection
            // validate selection
            // edit user, print message
            // return back to menu

            if (people.Count == 0)
            {
                Console.WriteLine("Nu users to edit. Use the menu to add a user.");
            }

            FinishOption();
        }
        public void SearchPerson()
        {
            StartOption("Searching users:");
            FinishOption();
        }
        public void RemovePerson()
        {
            StartOption("Removing a user:");
            FinishOption();
        }

        public void FinishOption()
        {
            Console.WriteLine(Environment.NewLine + "You have finished this option. Press <Enter> to return to the menu.");
            Console.ReadLine();
            Console.Clear();
        }

        public void StartOption(string message)
        {
            Console.Clear();
            Console.WriteLine($"{message}" + Environment.NewLine);
        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message + " Press <Enter> to try again.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
