Dictionary<string, string> users = new();
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    List<string> dataUser = Console.ReadLine().Split(" ").ToList();
    string command = dataUser[0];
    string user = dataUser[1];
    

    if (command == "register")
    {
        string plateNumber = dataUser[2];

        if (!users.ContainsKey(user))
        {
            users[user] = ( plateNumber );
            Console.WriteLine($"{user} registered {plateNumber} successfully");
        }
        else
        {
            Console.WriteLine($"ERROR: already registered with plate number {users[user]}");
        }
    }
    else if (command == "unregister")
    {
        if (!users.ContainsKey(user))
        {
            Console.WriteLine($"ERROR: user {user} not found");
        }
        else
        {
            users.Remove(user);
            Console.WriteLine($"{user} unregistered successfully");
        }
    }
}

foreach (var user in users)
{
    Console.WriteLine($"{user.Key} => {user.Value}");
}