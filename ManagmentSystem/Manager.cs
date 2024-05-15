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
            Console.WriteLine("Welcome to my managment system!" + Environment.NewLine);
            Console.WriteLine("1. Print all uers");
            Console.WriteLine("2. Add user");
            Console.WriteLine("3. Edit user");
            Console.WriteLine("4. Search user");
            Console.WriteLine("5. Remove user");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your menu option: ");


            int menuOption = Convert.ToInt32(Console.ReadLine());

          
            Console.WriteLine(menuOption);
        }

    }
}
