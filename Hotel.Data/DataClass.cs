namespace Hotel.Data;

public class DataClass
{


    public static List<(int roomNumber, RoomType type)> ReadRoomFile(string filePath)
    {
        List<(int roomNumber, RoomType type)> roomList = new List<(int roomNumber, RoomType type)>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int roomNumber) && Enum.TryParse(parts[1], out RoomType roomType))
                {
                    roomList.Add((roomNumber, roomType));
                }
            }
        }
        catch
        {
            throw new Exception("Room File Couldn't find.");
        }
        // Throw exception here
        return roomList;
    }

    public static List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation)> ReadReservationsFile(string filePath)
    {
        List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation)> reservationList = new List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation)>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 6 && Guid.TryParse(parts[0], out Guid reservationNumber) && DateOnly.TryParse(parts[1], out DateOnly startDate) && DateOnly.TryParse(parts[2], out DateOnly endDate) && int.TryParse(parts[3], out int roomNumber) && !string.IsNullOrEmpty(parts[4]) && !string.IsNullOrEmpty(parts[5]))
                {
                    reservationList.Add((reservationNumber, startDate, endDate, roomNumber, parts[4], parts[5]));
                }
            }
        }

        return reservationList;
    }

    public static List<(string customerName, long cardNumber)> ReadCustomersFile(string filePath)
    {
        List<(string customerName, long cardNumber)> customersList = new List<(string customerName, long cardNumber)>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && !string.IsNullOrEmpty(parts[0]) && long.TryParse(parts[1], out long cardNumber))
                {
                    customersList.Add((parts[0], cardNumber));
                }
            }
        }

        return customersList;
    }

    public static List<(RoomType roomType, decimal dailyRate)> ReadRoomPricesFile(string filePath)
    {
        List<(RoomType roomType, decimal dailyRate)> roomPrices = new List<(RoomType roomType, decimal dailyRate)>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && Enum.TryParse(parts[0], out RoomType roomType) && decimal.TryParse(parts[1], out decimal dailyRate))
                {
                    roomPrices.Add((roomType, dailyRate));
                }
            }
        }

        return roomPrices;
    }

    public static void UpdateRoomFile(string filePath, List<(int roomNumber, RoomType type)> roomList)
    {
        List<string> lines = new List<string>();

        foreach (var room in roomList)
        {
            string line = $"{room.roomNumber},{room.type}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }

    public static void UpdateReservationsFile(string filePath, List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation)> reservationList)
    {
        List<string> lines = new List<string>();
        foreach (var reservation in reservationList)
        {
            string line = $"{reservation.reservationNumber},{reservation.startDate},{reservation.endDate},{reservation.roomNumber},{reservation.customerName},{reservation.paymentConfirmation}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }

    public static void UpdateCustomersFile(string filePath, List<(string customerName, long cardNumber)> customersList)
    {
        List<string> lines = new List<string>();
        foreach (var customer in customersList)
        {
            string line = $"{customer.customerName},{customer.cardNumber}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }

    public static void UpdateRoomPricesFile(string filePath, List<(RoomType roomType, decimal dailyRate)> roomPrices)
    {
        List<string> lines = new List<string>();
        foreach (var price in roomPrices)
        {
            string line = $"{price.roomType},{price.dailyRate}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }




}

public enum RoomType { Single, Double, Suite }
