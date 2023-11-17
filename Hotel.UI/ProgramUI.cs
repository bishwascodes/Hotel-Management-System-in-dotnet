// CS1400 - Fall 2023 - Bishwas Thapa
using Hotel.Logic;

Console.Clear();
int userChoice = 0;
do
{
    Console.Clear();
    Console.WriteLine("************ Main Menu ************ \n Welcome to Hotel Management System. \n Here's you navigation menu: \n 1. Customer Management \n 2. Reservation Management \n 3. Room Management \n 4.  System Configuration \n 5. Save and exit");
    userChoice = getInt(1, 5, "Choose any number from 1 to 5: ");
    if (userChoice == 1)
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("************ Customer Management ************ \n Here's you navigation menu: \n 1. Add New Customer \n 2. View Customer Details \n 3. Edit Customer Information \n 4.  Delete Customer \n 5. Return to main menu");
            userChoice = getInt(1, 5, "Choose any number from 1 to 5: ");
            while (true)
            {
                if (userChoice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("*** Customer Management *** Add New Customer  *** \n Please enter the customer details below: ");
                    string name = getString("Please, Enter the name of your customer: ");
                    long cardNumber = getLong(Prompt: "Please, Enter the card Number: ");
                    if (LogicClass.CustomerIsAvailable(name))
                    {
                        LogicClass.addToCustomers((name, cardNumber));
                    }
                    break;
                }
                else if (userChoice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("*** Customer Management *** Customer Details  *** \n [Name************************] [********Card Number*******]");
                    foreach((string name, long id) in LogicClass.customersList){
                         Console.WriteLine($"[ {name, -30}] [{id,30}]");
                    }
                    Console.WriteLine("press eny key to exit.");
                    if(Console.ReadLine().Length > 0){
                         break;
                    }
                   
                }
                else if (userChoice == 3)
                {
                    break;
                }
                else if (userChoice == 4)
                {
                    break;
                }
                else if (userChoice == 5)
                {
                    break;
                }
            }
            if (userChoice == 5)
            {
                break;
            }

        }

    }
    else if (userChoice == 2)
    {

    }
    else if (userChoice == 3)
    {

    }
    else if (userChoice == 4)
    {

    }
    else if (userChoice == 5)
    {
        Console.WriteLine("Thanks for using my App.");
        break;
    }
    else
    {

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

//Using the booking check feature
// Console.WriteLine("Let's Check if Booking is available or not.");
// Console.Write("Enter room number:");
// bool success = false;
// int roomNumber;
// do
// {
//     success = int.TryParse(Console.ReadLine(), out roomNumber);
// } while (success == false);
// Console.Write("Enter booking date:");
// bool dateSuccess = false;
// DateOnly bookingDate;
// do
// {
//     dateSuccess = DateOnly.TryParse(Console.ReadLine(), out bookingDate);
// } while (dateSuccess == false);
// if (LogicClass.RoomIsAvailable(bookingDate, roomNumber) == true)
// {
//     Console.WriteLine("Yes! The room is available for booking");
// }
// else
// {
//     Console.WriteLine("Sorry! The room is already booked for that day.");
// }






