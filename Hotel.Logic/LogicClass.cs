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
    public static List<(int roomNumber, DataClass.RoomType type)> roomList = new();
    public static List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation)> reservationList = new();
    public static List<(string customerName, long cardNumber)> customersList = new();
    public static List<(DataClass.RoomType roomType, decimal dailyRate)> roomPrices = new();

    public static void GetDataFromFiles()
    {
        var errorMessages = "";
        try
        {
            roomList = DataClass.ReadRoomFile(roomsFile);
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }

        try
        {
            reservationList = DataClass.ReadReservationsFile(reservationsFile);
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }

        try
        {
            customersList = DataClass.ReadCustomersFile(customersFile);
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }

        try
        {
            roomPrices = DataClass.ReadRoomPricesFile(roomPricesFile);
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }
        if (errorMessages.Length > 0)
        {
            throw new Exception(errorMessages);
        }



    }


    // Adding items to each list 
    public static void addToRoom((int, DataClass.RoomType) roomData)
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
    public static void addToRoomPrice((DataClass.RoomType roomType, decimal dailyRate) roomPriceDatas)
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
    public static List<(int, DataClass.RoomType)> availableRoomsList(DateOnly checkingDate)
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
        List<(int, DataClass.RoomType)> tempRoomList = new();
        foreach ((int, DataClass.RoomType) roomItem in roomList)
        {
            tempRoomList.Add(roomItem);
        }
        foreach (int number in numbers)
        {
            tempRoomList.RemoveAll(item => item.Item1 == number);
        }
        // Check if tempRoomList is empty, and if so, return a new empty list
        return tempRoomList.Count > 0 ? tempRoomList : new List<(int, DataClass.RoomType)>();
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

    public static decimal getRoomPrice(DataClass.RoomType type)
    {
        decimal currentPrice = 0;
        foreach ((DataClass.RoomType roomType, decimal dailyRate) item in roomPrices)
        {
            if (item.roomType == type)
            {
                currentPrice = item.dailyRate;
                break;
            }
        }
        return currentPrice;
    }
    public static void updateTheRoomPrice(DataClass.RoomType roomTypeValue, decimal getPrice)
    {
        for (int i = 0; i < roomPrices.Count; i++)
        {
            var item = LogicClass.roomPrices[i];
            if (item.roomType == roomTypeValue)
            {
                LogicClass.roomPrices[i] = (item.roomType, getPrice);
                break;
            }
        }
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
