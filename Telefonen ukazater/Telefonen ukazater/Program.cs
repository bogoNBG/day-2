namespace Telefonen_ukazater
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Number  { get; set; }
        public string Email  { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Phonebook\n" + "Select:\n" + "1. Add Contact\n" + "2. See Contacts\n" + "3. Search for contact\n" + "4. Remove contact\n" + "5. Edit contact\n" + "x for Exit ");

            List<Contact> contacts = new();
            var userInput = Console.ReadLine();
            int idCount = 0;

            var searched = "";
            var findNames = new List<Contact>();

            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Contact contact = new Contact();
                        idCount += 1;
                        contact.Id = idCount;

                        Console.WriteLine("Contact name:");
                        contact.Name = Console.ReadLine();

                        Console.WriteLine("Contact number:");
                        contact.Number = Console.ReadLine();

                        Console.WriteLine("Contact Email:");
                        contact.Email = Console.ReadLine();

                        

                        contacts.Add(contact);
                        break;

                    case "2":
                        foreach (var cont in contacts)
                        {
                            Console.WriteLine("{0}. Name: {1}, Number: {2}, Email: {3}", cont.Id, cont.Name, cont.Number, cont.Email);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Name of contact:");
                        searched = Console.ReadLine();
                        findNames = contacts.FindAll(x => x.Name.Contains(searched));

                        if (findNames.Count > 0)
                        {
                            foreach (var cont in findNames)
                            {
                                Console.WriteLine("{0}. Name: {1}, Number: {2}, Email: {3}", cont.Id, cont.Name, cont.Number, cont.Email);
                            }
                        }
                        else Console.WriteLine("No such name!");
                        break;

                    case "4":
                        Console.WriteLine("Name of contact:");
                        searched = Console.ReadLine();
                        findNames = contacts.FindAll(x => x.Name.Contains(searched));

                        if (findNames.Count > 0)
                        {
                            Console.WriteLine("Contacts found. Select the contact to delete: (0 to cancel)");

                            for (int i = 0; i < findNames.Count; i++)
                            {
                                Console.WriteLine("{0}. Name: {1}, Number: {2}, Email: {3}", i + 1, findNames[i].Name, findNames[i].Number, findNames[i].Email);
                            }

                                                      
                            if (int.TryParse(Console.ReadLine(), out int selectedContactIndex) && selectedContactIndex >= 1 && selectedContactIndex <= findNames.Count)
                            {
                                var selectedContact = findNames[selectedContactIndex - 1];
                                contacts.Remove(selectedContact);
                                Console.WriteLine("Contact '{0}' removed", selectedContact.Name);
                            }
                            else if (selectedContactIndex == 0)
                            {
                                Console.WriteLine("Deletion canceled.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Deletion canceled.");
                            }

                            Console.WriteLine("");
                        }
                        else Console.WriteLine("No such name!");

                        break;

                    case "5":
                        Console.WriteLine("Name of contact:");
                        searched = Console.ReadLine();
                        findNames = contacts.FindAll(x => x.Name.Contains(searched));

                        if (findNames.Count > 0)
                        {
                            Console.WriteLine("Contacts found. Select the contact to edit: (0 to cancel)");

                            for (int i = 0; i < findNames.Count; i++)
                            {
                                Console.WriteLine("{0}. Name: {1}, Number: {2}, Email: {3}", i + 1, findNames[i].Name, findNames[i].Number, findNames[i].Email);
                            }

                            int selectedContactIndex;
                            if (int.TryParse(Console.ReadLine(), out selectedContactIndex) && selectedContactIndex >= 1 && selectedContactIndex <= findNames.Count)
                                {
                                var selectedContact = findNames[selectedContactIndex - 1];
                                Console.WriteLine("What to edit?\n" + "1. Name\n" + "2. Number\n" + "3. Email\n" + "x for Exit");
                                userInput = Console.ReadLine();
                                do
                                {
                                    switch (userInput)
                                    {
                                        case "1":
                                            Console.WriteLine("Write new name:");
                                            selectedContact.Name = Console.ReadLine();
                                            Console.WriteLine("Name edited");
                                            break;

                                        case "2":
                                            Console.WriteLine("Write new number:");
                                            selectedContact.Number = Console.ReadLine();
                                            Console.WriteLine("Number edited");
                                            break;

                                        case "3":
                                            Console.WriteLine("Write new email:");
                                            selectedContact.Email = Console.ReadLine();
                                            Console.WriteLine("Email edited");
                                            break;

                                        default:
                                            Console.WriteLine("Unvalid operation!");
                                            break;
                                    }

                                    Console.WriteLine("What to edit?\n" + "1. Name\n" + "2. Number\n" + "3. Email\n" + "x for Exit");
                                    userInput = Console.ReadLine();

                                } while (userInput != "x");
                            }
                            else if (selectedContactIndex == 0)
                            {
                                Console.WriteLine("Edit canceled.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Edit canceled.");
                            }

                            Console.WriteLine("");
                        }
                        else Console.WriteLine("No such name!");

                        break;

                    case "x":
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Unvalid operation!");
                        break;
                }
                Console.WriteLine("Select operation:\n" + "1. Add Contact\n" + "2. See Contacts\n" + "3. Search for contact \n" + "4. Remove contact\n" + "5. Edit contact\n" + "x for Exit ");
                userInput = Console.ReadLine();
            }

        }
    }
}