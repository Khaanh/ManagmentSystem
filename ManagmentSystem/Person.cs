namespace ManagmentSystem
{
    internal class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string ReturnDetails()
        {
            return name + " - " + age;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setAge(int age)
        {
            this.age = age;
        }
    }
}
