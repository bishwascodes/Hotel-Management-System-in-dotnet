namespace Hotel.Data;

public class DataClass
{

    public static List<(int roomNumber, string type)> ReadRoomFile(string filePath)
    {
        List<(int roomNumber, string type)> roomList = new List<(int roomNumber, string type)>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int roomNumber) && Enum.TryParse(parts[1], out string roomType))
                {
                    roomList.Add((roomNumber, roomType));
                }
            }
        }

        return roomList;
    }

    public static List<(Guid reservationNumber, DateTime date, int roomNumber, string customerName, string paymentConfirmation)> ReadReservationsFile(string filePath)
    {
        List<(Guid reservationNumber, DateTime date, int roomNumber, string customerName, string paymentConfirmation)> reservationList = new List<(Guid reservationNumber, DateTime date, int roomNumber, string customerName, string paymentConfirmation)>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 5 && Guid.TryParse(parts[0], out Guid reservationNumber) && DateTime.TryParse(parts[1], out DateTime date) &&
                    int.TryParse(parts[2], out int roomNumber) && !string.IsNullOrEmpty(parts[3]) && !string.IsNullOrEmpty(parts[4]))
                {
                    reservationList.Add((reservationNumber, date, roomNumber, parts[3], parts[4]));
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

    public static List<(string roomType, decimal dailyRate)> ReadRoomPricesFile(string filePath)
    {
        List<(string roomType, decimal dailyRate)> roomPrices = new List<(string roomType, decimal dailyRate)>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && Enum.TryParse(parts[0], out string roomType) && decimal.TryParse(parts[1], out decimal dailyRate))
                {
                    roomPrices.Add((roomType, dailyRate));
                }
            }
        }

        return roomPrices;
    }

    public static void UpdateRoomFile(string filePath, List<(int roomNumber, string type)> roomList)
    {
        List<string> lines = new List<string>();

        foreach (var room in roomList)
        {
            string line = $"{room.roomNumber},{room.type}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }

    public static void UpdateReservationsFile(string filePath, List<(Guid reservationNumber, DateTime date, int roomNumber, string customerName, string paymentConfirmation)> reservationList)
    {
        List<string> lines = new List<string>();
        foreach (var reservation in reservationList)
        {
            string line = $"{reservation.reservationNumber},{reservation.date},{reservation.roomNumber},{reservation.customerName},{reservation.paymentConfirmation}";
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

    public static void UpdateRoomPricesFile(string filePath, List<(string roomType, decimal dailyRate)> roomPrices)
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
