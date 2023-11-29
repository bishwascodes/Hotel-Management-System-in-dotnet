namespace Hotel.Logic;
using Hotel.Data;

public class LogicClass
{
    // File Paths
    public static string roomsFile = "..\\Rooms.txt";
    public static string reservationsFile = "..\\Reservations.txt";
    public static string customersFile = "..\\Customers.txt";
    public static string roomPricesFile = "..\\RoomPrices.txt";

    // try catch
    // Thow exception

    public static List<(int roomNumber, RoomType type)> roomList = DataClass.ReadRoomFile(roomsFile);

    public static List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation)> reservationList = DataClass.ReadReservationsFile(reservationsFile);
    public static List<(string customerName, long cardNumber)> customersList = DataClass.ReadCustomersFile(customersFile);
    public static List<(RoomType roomType, decimal dailyRate)> roomPrices = DataClass.ReadRoomPricesFile(roomPricesFile);



    // Adding items to each list 
    public static void addToRoom((int, RoomType) roomData)
    {
        roomList.Add((roomData.Item1, roomData.Item2));
    }
    public static void addToReservationList((Guid, DateOnly, DateOnly, int, string, string) reservationData)
    {
        reservationList.Add((reservationData.Item1, reservationData.Item2, reservationData.Item3, reservationData.Item4, reservationData.Item5, reservationData.Item6));
    }
    public static void addToCustomers((string, long) customerData)
    {
        customersList.Add((customerData.Item1, customerData.Item2));
    }
    public static void addToRoomPrice((RoomType roomType, decimal dailyRate) roomPriceDatas)
    {
        roomPrices.Add((roomPriceDatas.roomType, roomPriceDatas.dailyRate));
    }
    // Removing items from each list 
    // public static void addToRoom((int, string) roomData)
    // {
    //     roomList.Add((roomData.Item1, roomData.Item2));
    // }
    // public static void addToReservationList((Guid, DateOnly, int, string, string) reservationData)
    // {
    //     reservationList.Add((reservationData.Item1, reservationData.Item2, reservationData.Item3, reservationData.Item4, reservationData.Item5));
    // }
    public static void removeFromCustomers(string nameToRemove)
    {

        customersList.RemoveAll(customer => customer.Item1.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase));

    }
    // public static void addToRoomPrice((string roomType, decimal dailyRate) roomPriceDatas)
    // {
    //     roomPrices.Add((roomPriceDatas.roomType, roomPriceDatas.dailyRate));
    // }

    public static void saveAllToFiles()
    {
        DataClass.UpdateCustomersFile(customersFile, customersList);
        DataClass.UpdateRoomFile(roomsFile, roomList);
        DataClass.UpdateReservationsFile(reservationsFile, reservationList);
        DataClass.UpdateRoomPricesFile(roomPricesFile, roomPrices);
    }








    // Methods 
    public static List<(int, RoomType)> availableRoomsList(DateOnly checkingDate)
    {
        List<(int, string)> rooms = new();
        List<int> numbers = new();

        foreach ((Guid guid, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation) in LogicClass.reservationList)
        {
            if (checkingDate >= startDate && checkingDate < endDate)
            {
                numbers.Add(roomNumber);
            }
        }
        List<(int, RoomType)> tempRoomList = new();
        foreach ((int, RoomType) roomItem in roomList)
        {
            tempRoomList.Add(roomItem);
        }
        foreach (int number in numbers)
        {
            tempRoomList.RemoveAll(item => item.Item1 == number);
        }
        // Check if tempRoomList is empty, and if so, return a new empty list
        return tempRoomList.Count > 0 ? tempRoomList : new List<(int, RoomType)>();
    }
    public static bool RoomIsAvailable(DateOnly bookingStartDate, DateOnly bookingEndDate, int roomNumber)
    {
        var newReservationStartDate = bookingStartDate;
        var newReservationEndDate = bookingEndDate;
        var newReservationRoom = roomNumber;
        var reservationFileData = reservationList;
        bool isAvailable = true;
        foreach (var data in reservationFileData)
        {
            if (data.roomNumber == newReservationRoom)
            {
                // to make it exclusive i.e if user books for 11/15/2024-11/16/2024, we count it only a day
                // 11/16/2024 is actually allowed to book
                if (!(data.startDate >= newReservationEndDate || newReservationStartDate >= data.endDate))
                {
                    isAvailable = false;
                    break;
                }

            }

        }
        return isAvailable;
    }
    public static bool CustomerAlreadyAvailable(string name)
    {

        var customerFileData = customersList;
        bool isAvailable = false;
        foreach (var data in customerFileData)
        {
            if (data.customerName.ToLower().Trim() == name.ToLower())
            {
                isAvailable = true;
                break;
            }

        }
        return isAvailable;
    }
    public static bool RoomAvailableToCreate(int roomNumber)
    {

        var roomsFileData = roomList;
        bool isAvailable = true;
        foreach (var data in roomsFileData)
        {
            if (data.roomNumber == roomNumber)
            {
                isAvailable = false;
                break;
            }

        }
        return isAvailable;
    }
    public static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        char[] result = new char[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = chars[random.Next(chars.Length)];
        }

        return new string(result);
    }

}
