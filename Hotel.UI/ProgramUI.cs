// CS1400 - Fall 2023 - Bishwas Thapa
using Hotel.Logic;

Console.Clear();
int userChoice = 0;
string recentMessage = "";
do
{
    Console.Clear();
    Console.WriteLine($"************ Main Menu ************ \n{recentMessage}\nWelcome to Hotel Management System. \n Here's you navigation menu: \n 1. Customer Management \n 2. Room Management \n 3. Reservation Management \n 4. System Configuration \n 5. Save and exit");
    userChoice = getInt(1, 5, "Choose any number from 1 to 5: ");
    if (userChoice == 1)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"************ Customer Management ************ \n{recentMessage} Here's you navigation menu: \n 1. Add New Customer \n 2. View Customer Details \n 3. Delete Customer \n 4. Save changes and exit to main menu ");
            userChoice = getInt(1, 4, "Choose any number from 1 to 4: ");
            while (true)
            {
                if (userChoice == 1)
                {
                    addNewCustomerUI();
                    break;
                }
                else if (userChoice == 2)
                {
                    customersDetailsUI();
                    break;
                }

                else if (userChoice == 3)
                {
                    removeACustomerUI();
                    break;
                }
                else if (userChoice == 4)
                {
                    break;
                }
            }
            if (userChoice == 4)
            {
                LogicClass.saveAllToFiles();
                recentMessage = "\nMessage: All the recent changes were saved successfully in files.\n";
                break;
            }

        }

    }
    else if (userChoice == 2)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"************ Room Management ************ \n{recentMessage} Here's you navigation menu: \n 1. Add New Room \n 2. Search for Available Rooms \n 3.  Cost Tracking Report \n 4. Save changes and return to main menu ");
            userChoice = getInt(1, 4, "Choose any number from 1 to 4: ");
            while (true)
            {
                if (userChoice == 1)
                {
                    addANewRoomUI();
                    break;
                }
                else if (userChoice == 4)
                {

                    break;
                }
            }
            if (userChoice == 4)
            {
                LogicClass.saveAllToFiles();
                recentMessage = "\nMessage: All the recent changes were saved successfully in files.\n";
                break;
            }
        }
    }
    else if (userChoice == 3)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"************ Reservation Management ************ \n{recentMessage} Here's you navigation menu: \n 1. Add New Reservation \n 2. View All Reservations \n 3. Reservation Report by Customer Name \n 4. Reservation Report by Date \n 5. Available Room Search by Date \n 6. Save changes and return to main menu ");
            userChoice = getInt(1, 6, "Choose any number from 1 to 6: ");
            while (true)
            {
                if (userChoice == 1)
                {
                    addNewReservationUI();
                    break;
                }
                else if (userChoice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("***  Reservation Management  *** Reservation Details  *** \n [*********Reservation Number*********] [*Start Date*] [*End   Date*] [Room ] [***********Name**********] [*****Payment Confirmation*****]");
                    foreach ((Guid guid, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation) in LogicClass.reservationList)
                    {
                        Console.WriteLine($"[ {guid,-30}] [{startDate,12}] [{endDate,12}] [{roomNumber,5}] [{customerName,25}] [{paymentConfirmation,30}]");
                    }
                    Console.Write("press eny key to return back. ");
                    Console.ReadKey(true);
                    recentMessage = "";
                    break;
                }
                else if (userChoice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("***  Reservation Management  *** Reservation Report by Customer Name *** \n ");
                    string customer = getString("Please enter the name of customer: ");
                    if (!LogicClass.CustomerAlreadyAvailable(customer))
                    {
                        Console.Write($"The user {customer} doesn't exist. Press any key to continue: ");
                        Console.ReadKey(true);
                        recentMessage = $"\nMessage: The customer with the name {customer} not found. \n";
                        break;
                    }
                    Console.WriteLine($"\nReservation details for {customer} \n\n[S.N] [*********Reservation Number**********] [*Start Date*] [*End   Date*] [Room ] [***********Name**********] [*****Payment Confirmation*****]\n");
                    int no_of_results = 0;
                    foreach ((Guid guid, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation) in LogicClass.reservationList)
                    {
                        if (customerName.ToLower().Trim() == customer.ToLower().Trim())
                        {
                            no_of_results++;
                            Console.WriteLine($"[ {no_of_results} ] [ {guid,-30}] [{startDate,12}] [{endDate,12}] [{roomNumber,5}] [{customerName,25}] [{paymentConfirmation,30}]");

                        }
                    }
                    if (no_of_results == 0)
                    {
                        Console.WriteLine($"\nUser {customer} has not made any reservations yet . ");
                    }
                    else
                    {
                        Console.WriteLine($"\nTotal {no_of_results} reservations found for {customer}. ");
                    }
                    Console.Write("press eny key to return back. ");
                    Console.ReadKey(true);
                    recentMessage = "";
                    break;
                }
                else if (userChoice == 4)
                {
                    reservationReportByDateUI();
                    break;
                }
                else if (userChoice == 5)
                {
                    availableRoomSearchByDateUI();
                    break;
                }
                else if (userChoice == 6)
                {
                    LogicClass.saveAllToFiles();
                    recentMessage = "\nMessage: All the recent changes were saved successfully in files.\n";
                    break;
                }
            }
            if (userChoice == 6)
            {
                LogicClass.saveAllToFiles();
                recentMessage = "\nMessage: All the recent changes were saved successfully in files.\n";
                break;
            }

        }
    }
    else if (userChoice == 4)
    {

    }
    else if (userChoice == 5)
    {
        LogicClass.saveAllToFiles();
        Console.WriteLine("Thanks for using my App.");
        break;
    }

} while (true);


// UI Methods
int getInt(int min = int.MinValue, int max = int.MaxValue, string Prompt = "")
{
    Console.Write(Prompt);
    bool isValid = false;
    int returnValue = 0;
    while (isValid == false || returnValue < min || returnValue > max)
    {

        isValid = int.TryParse(Console.ReadLine(), out returnValue);
    }

    return returnValue;
}
long getLong(long min = long.MinValue, long max = long.MaxValue, string Prompt = "")
{
    Console.Write(Prompt);
    bool isValid = false;
    long returnValue = 0;
    while (isValid == false || returnValue < min || returnValue > max)
    {

        isValid = long.TryParse(Console.ReadLine(), out returnValue);
    }

    return returnValue;
}
string getString(string prompt = "")
{
    Console.Write(prompt);
    string returnValue = Console.ReadLine();
    return returnValue;
}
DateOnly getDate(string prompt = "")
{
    DateOnly returnValue;
    Console.Write(prompt);
    bool isValid = false;
    while (true)
    {
        isValid = DateOnly.TryParse(Console.ReadLine(), out returnValue);
        if (isValid == true)
        {
            return returnValue;
        }
    }

}

// UI Components
void addNewCustomerUI()
{
    Console.Clear();
    Console.WriteLine("*** Customer Management *** Add New Customer  *** \n Please enter the customer details below or Press X to exit.: ");
    string name = "";
    while (true)
    {
        name = getString("Please, Enter the name of your customer: ");
        if (name != "X" && name != "x")
        {
            if (!LogicClass.CustomerAlreadyAvailable(name))
            {
                break;
            }
            Console.WriteLine($"The customer with the same name '{name}' already exists.");
            Console.Write("Press any key to continue");
            Console.ReadKey(true);
            Console.WriteLine();
            recentMessage = "\nMessage: Couldn't add new customer\n";
            break;
        }
        break;
    }
    if (!LogicClass.CustomerAlreadyAvailable(name) && name != "X" && name != "x")
    {
        long cardNumber = getLong(Prompt: "Please, Enter the card Number: ");
        LogicClass.addToCustomers((name, cardNumber));
    }
    recentMessage = "\nMessage: New customer Successfully Added\n";
}


void customersDetailsUI()
{
    Console.Clear();
    Console.WriteLine("*** Customer Management *** Customer Details  *** \n[*************Name**************] [**********Card Number*********]");
    foreach ((string name, long id) in LogicClass.customersList)
    {
        Console.WriteLine($"[ {name,-30}] [{id,30}]");
    }
    Console.Write("press eny key to return back. ");
    Console.ReadKey(true);
    recentMessage = "";

}
void removeACustomerUI()
{
    Console.Clear();
    Console.WriteLine("*** Customer Management *** Remove a Customer  *** \nPlease enter the customer details below or Press X to exit.: ");
    string name = "";
    while (true)
    {

        name = getString("Please, Enter the name of your customer: ");
        if (name != "X" && name != "x")
        {
            if (LogicClass.CustomerAlreadyAvailable(name))
            {
                Console.Write($"Warning! You're about to delete the customer \"{name}\" from database. \nPress 'Y' to Proceed or any other Key to return back: ");
                string input = Console.ReadLine();
                if (input == "Y" || input == "y")
                {
                    LogicClass.removeFromCustomers(name);

                }
                recentMessage = "\nMessage: The customer was deleted successfully.\n";
                break;
            }
            else
            {
                Console.WriteLine($"The customer with the name {name} doesn't exist. Please recheck and enter again.");
                recentMessage = "\nMessage: Couldn't delete the customer.\n";
            }
        }
        else
        {
            break;
        }
    }
}
void addANewRoomUI()
{
    Console.Clear();
    Console.WriteLine("*** Room Management *** Add New Room  *** \n Please enter the room below or Press X to exit.: ");
    int roomNum;
    while (true)
    {
        roomNum = getInt(Prompt: "Please, Enter the new room number: ");

        if (!LogicClass.RoomAvailableToCreate(roomNum))
        {
            Console.WriteLine($"The room with the same number '{roomNum}' already exists.");
            Console.Write("Press any key to continue");
            Console.ReadKey(true);
            Console.WriteLine();
            recentMessage = "\nMessage: Couldn't add new room.\n";
            break;
        }
        string roomType = getString("Please enter the room type: ");
        LogicClass.addToRoom((roomNum, roomType));
        recentMessage = "\nMessage: New Room Successfully added.\n";
        break;

    }
}
void addNewReservationUI()
{
    Console.Clear();
    Console.WriteLine("*** Reservation Management *** Add New Reservation  *** \n Please enter the room below or Press X to exit.: ");
    int roomNum;
    DateOnly startDate;
    DateOnly endDate;
    while (true)
    {
        roomNum = getInt(Prompt: "Please, Enter the room number that you want to book: ");
        if (LogicClass.RoomAvailableToCreate(roomNum))
        {
            Console.Write("The room number that you entered doesn't exist. Please create one to proceed booking. Press any key to continue: ");
            Console.ReadKey(true);
            recentMessage = "\nMessage: Booking can't proceed. Please make a new room. \n";
            break;
        }
        startDate = getDate("Please, Enter the starting date: ");
        endDate = getDate("Please, Enter the ending date: ");
        if (endDate < startDate)
        {
            Console.Write("Invalid Input of the date. Press any key to continue: ");
            Console.ReadKey(true);
            Console.WriteLine();
            continue;
        }
        if (!LogicClass.RoomIsAvailable(startDate, endDate, roomNum))
        {
            Console.WriteLine($"The room '{roomNum}' is already booked on between '{startDate}'-'{endDate}'.");
            Console.Write("Press any key to continue");
            Console.ReadKey(true);
            recentMessage = "\nMessage: Couldn't make the new reservation.\n";
            break;
        }
        string customerName = getString("Please enter the customer name: ");
        if (!LogicClass.CustomerAlreadyAvailable(customerName))
        {
            Console.Write("The user doesn't exist. Please create one to proceed booking. Press any key to continue: ");
            Console.ReadKey(true);
            recentMessage = "\nMessage: Booking can't proceed. Please make a new user. \n";
            break;
        }
        LogicClass.addToReservationList((Guid.NewGuid(), startDate, endDate, roomNum, customerName, LogicClass.GenerateRandomString(30)));
        recentMessage = $"\nMessage: New Reservation for {customerName} Successfully added.\n";
        break;

    }
}
void reservationReportByDateUI()
{
    Console.Clear();
    Console.WriteLine("***  Reservation Management  *** Reservation Report by Date  *** \n ");
    DateOnly checkingDate = getDate("Please enter the date to check the report: ");

    Console.WriteLine($"\nReservation details for the date {checkingDate} \n\n(P.S. Th end date doesn't count as it's free to book on end date.)\n[S.N] [*********Reservation Number**********] [*Start Date*] [*End   Date*] [Room ] [***********Name**********] [*****Payment Confirmation*****]\n");
    int no_of_results = 0;
    foreach ((Guid guid, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation) in LogicClass.reservationList)
    {
        if (checkingDate >= startDate && checkingDate < endDate)
        {
            no_of_results++;
            Console.WriteLine($"[ {no_of_results} ] [ {guid,-30}] [{startDate,12}] [{endDate,12}] [{roomNumber,5}] [{customerName,25}] [{paymentConfirmation,30}]");

        }
    }
    if (no_of_results == 0)
    {
        Console.WriteLine($"Sorry! No reservations found on given date - '{checkingDate}' . ");
    }
    else
    {
        Console.WriteLine($"\nTotal {no_of_results} reservations found on given date - '{checkingDate}' . ");
    }
    Console.Write("press eny key to return back. ");
    Console.ReadKey(true);
    recentMessage = "";
}
void availableRoomSearchByDateUI()
{
    Console.Clear();
    Console.WriteLine("***  Reservation Management  *** Available Room Search by Date  *** \n ");
    DateOnly checkingDate = getDate("Please enter the date to search: ");
    var availableRoomLists = LogicClass.availableRoomsList(checkingDate);
    if (availableRoomLists.Count == 0)
    {
        Console.WriteLine($"Sorry! No any rooms available to book for the day '{checkingDate}'. ");
    }
    else
    {
        Console.WriteLine($"\nHere's the list of available rooms to book for the day '{checkingDate}'. \n");
        Console.WriteLine($"[Room No.] [Room Type]");
        foreach (var item in availableRoomLists)
        {
            Console.WriteLine($"[{item.Item1,8}] [{item.Item2,9}]");
        }
        Console.WriteLine($"\n{availableRoomLists.Count} numbers of rooms are available.");
    }
    Console.Write("\npress eny key to return back. ");
    Console.ReadKey(true);
    recentMessage = "";
}
