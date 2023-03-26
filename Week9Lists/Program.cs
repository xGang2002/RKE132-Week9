string folderPath = @"C:\Data";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> MyShoppingList = new List<string>();
if (File.Exists(filePath))
{
   MyShoppingList = GetItemsFromUser();
   File.WriteAllLines(filePath, MyShoppingList);
}
else
{
    File.Create(filePath).Close();
    Console.WriteLine($"File {fileName} does not exist.");
    MyShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, MyShoppingList);

}


static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item´(add)/ Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else
        {
            Console.WriteLine("bye!");
            break;
        }
    }
    return userList;
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    int listLength = someList.Count;
    Console.WriteLine($"You have added {listLength} items to your shopping list.");

    int i = 1;
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}
