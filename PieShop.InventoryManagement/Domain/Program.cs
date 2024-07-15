using PieShop.InventoryManagement;
using PieShop.InventoryManagement.Domain.General;
using PieShop.InventoryManagement.Domain.ProductManagement;

PrintWelcome();

Utilities.InitializeStock();

Utilities.ShowMainMenu();

Console.WriteLine("Application shutting down...");

Console.ReadLine();

#region Layout

static void PrintWelcome()
{

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
    ()()()()()()                                                  _____ _         _____ _                                        
    |\         |                                                 |  __  (_)       / ____| |                                         ()()()()()()
    |.\. . . . |                                                 | |__) |  ___  | (___ | |__   ___  _ __                           |\         |
    \'.\       |                                                 |  ___/ |/ _ \  \___ \| '_ \ / _ \| '_ \                          |.\. . . . |
     \.:\ . . .|                                                 | |   | |  __/  ____) | | | | (_) | |_) |                         \'.\       |
      \'o\     |                                                 |_|__ |_|\___| |_____/|_| |_|\___/| .__/                    _      \.:\ . . .|
       \.'\. . |  |_   _|                    | |     __/ |         |  \/  |                        | |                      | |      \'o\     |
        \'.\   |    | |  _ ____   _____ _ __ | |_ __|___/__ _   _  | \  / | __ _ _ __   __ _  __ _ |_|_ _ __ ___   ___ _ __ | |_      \.'\. . |
         \'`\ .|    | | | '_ \ \ / / _ \ '_ \| __/ _ \| '__| | | | | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '_ ` _ \ / _ \ '_ \| __|      \'.\   |
          \.'\ |   _| |_| | | \ V /  __/ | | | || (_) | |  | |_| | | |  | | (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_        \'`\ .|
           \__\|  |_____|_| |_|\_/ \___|_| |_|\__\___/|_|   \__, | |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_| |_| |_|\___|_| |_|\__|        \.'\ |
                                                             __/ |                            __/ |                                       \__\|
                                                            |___/                            |___/                               
    ");

    Console.ResetColor();

    Console.WriteLine("Press enter key to start logging in!");

    //accepting enter here
    Console.ReadLine();

    Console.Clear();
}
#endregion