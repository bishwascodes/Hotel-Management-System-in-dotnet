// CS1400 - Fall 2023 - Bishwas Thapa
using Hotel.Logic;

Console.WriteLine("Let's Check if Booking is available or not.");
Console.Write("Enter room number:");
bool success = false;
int roomNumber;
do
{
    success = int.TryParse(Console.ReadLine(), out roomNumber);
} while (success == false);
Console.Write("Enter booking date:");
bool dateSuccess = false;
DateOnly bookingDate;
do
{
    dateSuccess = DateOnly.TryParse(Console.ReadLine(), out bookingDate);
} while (dateSuccess == false);
if (LogicClass.RoomIsAvailable(bookingDate, roomNumber) == true)
{
    Console.WriteLine("Yes! The room is available for booking");
}
else
{
    Console.WriteLine("Sorry! The room is already booked for that day.");
}






