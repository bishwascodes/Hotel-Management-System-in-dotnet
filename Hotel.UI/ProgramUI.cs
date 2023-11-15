// CS1400 - Fall 2023 - Bishwas Thapa
using Hotel.Logic;

Console.Clear();
Console.WriteLine("************ Main Menu ************ \n Welcome to Hotel Management System. \n Here's you navigation menu: \n 1. Customer Management \n 2. Reservation Management \n 3. Room Management \n 4.  System Configuration \n 5. Save and exit");
int userChoice = getAnInt("Input: ");
if (userChoice == 1)
{
    Console.Clear();
    Console.WriteLine("************ Customer Management ************ \n Here's you navigation menu: \n 1. Add New Customer \n 2. View Customer Details \n 3. Edit Customer Information \n 4.  Delete Customer \n 5. Return to main menu");
    userChoice = getAnInt();
    if (userChoice == 1)
    {
        Console.Clear();
        Console.WriteLine("************ Customer Management ************ \n Here's you navigation menu: \n 1. Add New Customer \n 2. View Customer Details \n 3. Edit Customer Information \n 4.  Delete Customer \n 5. Return to main menu");
        userChoice = getAnInt();
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

    }
    else
    {

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

}
else
{

}

// UI Methods
int getAnInt(string Prompt = "")
{
    Console.Write(Prompt);
    bool isValid = false;
    int returnValue = 0;
    while (isValid == false)
    {
        isValid = int.TryParse(Console.ReadLine(), out returnValue);
    }

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






