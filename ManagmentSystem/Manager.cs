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

            string[] menuOptions = new string[]
            {
                "Print all users",
                "Add user",
                "Edit user",
                "Search user",
                "Remove user",
                "Exit",
            };


            Console.WriteLine("Welcome to my management system!" + Environment.NewLine);

            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine( i + 1 + ". " + menuOptions[i]);
            }


            Console.Write("Enter your menu option: ");

            bool tryParse = int.TryParse(Console.ReadLine(), out int menuOption);

            if (tryParse)
            {

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

                if (menuOption >= 1 && menuOption <= menuOptions.Length - 1) {
                    PrintMenu();
                }
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

            if (!isSystemEmpty())
            {
                PrintAllUsers();
            }

            /*
            if (people.Count == 0)
            {
                Console.WriteLine(", use option 1 to create a user.");
            }
            else
            {
                PrintAllUsers();
            }
             */

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
                Person person = ReturnPerson();

                if (person != null)
                {
                    people.Add(person);
                    Console.WriteLine("Successfully added a person.");
                    FinishOption();
                }
                else
                {
                    OutputMessage("Something has went wrong.");
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

            if (!isSystemEmpty())
            {
                PrintAllUsers();

                try
                {
                    Console.Write("Enter an index: ");
                    int indexSelection = Convert.ToInt32(Console.ReadLine());
                    //indexSelection = indexSelection - 1;
                    //indexSelection -= 1;
                    indexSelection--;

                    //1-2
                    //0-1  2

                    if (indexSelection >= 0 && indexSelection <= people.Count - 1)
                    {
                        try
                        {
                            Person person = ReturnPerson();

                            if (person != null)
                            {
                                people[indexSelection] = person;
                                Console.WriteLine("Successfully edited a person.");
                                FinishOption();
                            }
                            else
                            {
                                OutputMessage("Something has went wrong.");
                                EditPerson();
                            }
                        }
                        catch (Exception)
                        {
                            OutputMessage("Something has went wrong.");
                            EditPerson();
                        }
                    }
                    else
                    {
                        OutputMessage("Enter a valid index range.");
                        EditPerson();
                    }
                }
                catch (Exception)
                {
                    OutputMessage("Something went wrong.");
                    EditPerson();
                }
            }
            else
            {
                OutputMessage("");
            }

            FinishOption();
        }
        public void SearchPerson()
        {
            StartOption("Searching users:");

            if (!isSystemEmpty())
            {
                Console.Write("Enter a name: ");
                string nameInput = Console.ReadLine();

                bool bFound = false;

                if (!string.IsNullOrEmpty(nameInput))
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (people[i].name.ToLower().Contains(nameInput.ToLower()))
                        {
                            Console.WriteLine(people[i].ReturnDetails());
                            bFound = true;
                        }
                    }

                    if (!bFound)
                    {
                        Console.WriteLine("No users found with that name.");
                    }
                    FinishOption();
                } 
                else
                {
                    OutputMessage("Please enter a name");
                    SearchPerson();
                }
            }
            else
            {
                OutputMessage("");
            }
        }
        public void RemovePerson()
        {
            StartOption("Removing a user:");

            

            if (!isSystemEmpty())
            {
                PrintAllUsers();
                Console.WriteLine("Enter an index: ");
                int index = Convert.ToInt32(Console.ReadLine());
                index--;

                if (index >= 0 && index <= people.Count - 1) {
                    people.RemoveAt(index);
                    Console.WriteLine("Succsessfully removed a person.");

                    FinishOption();
                } else
                {
                    OutputMessage("Enter a valid index inside the range.");
                    RemovePerson();
                }
            }
            else
            {
                OutputMessage("");
            }
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

            if (message.Equals(string.Empty))
            {
                Console.Write("Press <Enter> to try again.");
            } else
            {
                Console.WriteLine(message + " Press <Enter> to try again.");
            }
            Console.ReadLine();
            Console.Clear();
        }

        public void PrintAllUsers()
        {
            for (int i = 0; i < people.Count(); i++)
            {
                Console.WriteLine(i + 1 + ". " + people[i].ReturnDetails());
            }
        }

        public Person ReturnPerson()
        {
         
            Console.WriteLine("Enter a name: ");
            string nameInput = Console.ReadLine();

            Console.WriteLine("Enter an age: ");
            int ageInput = Convert.ToInt32(Console.ReadLine());

            if (!string.IsNullOrEmpty(nameInput))
            {
                if (ageInput >= 0 && ageInput <= 150)
                {
                    return new Person(nameInput, ageInput);
                }
                else
                {
                    OutputMessage("Enter a sensible age.");
                }
            }
            else
            {
                OutputMessage("You didn't enter a name.");
            }
            return null;
        }

        public bool isSystemEmpty()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("There are no users in the system.");
                return true;
            } else
            {
                return false;
            }
        }
    }
}
