namespace Hotel.Data;

public class DataClass
{
    public enum RoomType { Single, Double, Suite }

    // Reading from the files  
    public static List<(int roomNumber, RoomType type)> ReadRoomFile(string filePath)
    {
        List<(int roomNumber, RoomType type)> roomList = new();

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
            throw new FileNotFoundException("Room File Couldn't find.\n");
        }

        // Throw exception here
        return roomList;
    }

    public static List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid)> ReadReservationsFile(string filePath)
    {
        List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid)> reservationList = new();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 8 && Guid.TryParse(parts[0], out Guid reservationNumber) && DateOnly.TryParse(parts[1], out DateOnly startDate) && DateOnly.TryParse(parts[2], out DateOnly endDate) && int.TryParse(parts[3], out int roomNumber) && !string.IsNullOrEmpty(parts[4]) && !string.IsNullOrEmpty(parts[5]) && bool.TryParse(parts[6], out bool hasCoupon) && decimal.TryParse(parts[7], out decimal amountPaid))
                {
                    reservationList.Add((reservationNumber, startDate, endDate, roomNumber, parts[4], parts[5], hasCoupon, amountPaid));
                }
            }
        }
        catch
        {
            throw new FileNotFoundException("Reservation File Couldn't find.\n");
        }

        return reservationList;
    }

    public static List<(string customerName, long cardNumber, bool isFrequentTraveler)> ReadCustomersFile(string filePath)
    {
        List<(string customerName, long cardNumber, bool isFrequentTraveler)> customersList = new();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3 && !string.IsNullOrEmpty(parts[0]) && long.TryParse(parts[1], out long cardNumber) && bool.TryParse(parts[2], out bool isFreqTraveler))
                {
                    customersList.Add((parts[0], cardNumber, isFreqTraveler));
                }
            }
        }
        catch
        {
            throw new FileNotFoundException("Customer File Couldn't find.\n");
        }

        return customersList;
    }

    public static List<(RoomType roomType, decimal dailyRate, decimal cleaningCost)> ReadRoomPricesFile(string filePath)
    {
        List<(RoomType roomType, decimal dailyRate, decimal cleaningCost)> roomPrices = new();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3 && Enum.TryParse(parts[0], out RoomType roomType) && decimal.TryParse(parts[1], out decimal dailyRate) && decimal.TryParse(parts[1], out decimal cleaningCost))
                {
                    roomPrices.Add((roomType, dailyRate, cleaningCost));
                }
            }
        }
        catch
        {
            throw new FileNotFoundException("Room Price File Couldn't find.\n");
        }

        return roomPrices;
    }
    public static List<(Guid reservationNumber, string couponCode, double discountPercentage)> ReadCouponRedemptionsFile(string filePath)
    {
        List<(Guid reservationNumber, string couponCode, double discountPercentage)> couponRedemptions = new();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3 && Guid.TryParse(parts[0], out Guid reservationNumber) && !string.IsNullOrEmpty(parts[1]) && double.TryParse(parts[2], out double discountPercent))
                {
                    couponRedemptions.Add((reservationNumber, parts[1], discountPercent));
                }
            }
        }
        catch
        {
            throw new FileNotFoundException("Error Reading the CouponRedemptions File.\n");
        }

        return couponRedemptions;
    }
    public static List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid, DateOnly refundDate)> ReadRefundsFile(string filePath)
    {
        List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid, DateOnly refundDate)> refunds = new();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 9 && Guid.TryParse(parts[0], out Guid reservationNumber) && DateOnly.TryParse(parts[1], out DateOnly startDate) && DateOnly.TryParse(parts[2], out DateOnly endDate) && int.TryParse(parts[3], out int roomNumber) && !string.IsNullOrEmpty(parts[4]) && !string.IsNullOrEmpty(parts[5]) && bool.TryParse(parts[6], out bool hasCoupon) && decimal.TryParse(parts[7], out decimal amountPaid) && DateOnly.TryParse(parts[8], out DateOnly refundDate))
                {
                    refunds.Add((reservationNumber, startDate, endDate, roomNumber, parts[4], parts[5], hasCoupon, amountPaid, refundDate));
                }
                else
                {
                    Console.WriteLine("Can't parse here");
                }
            }
        }
        catch
        {
            throw new FileNotFoundException("Error Reading the CouponRedemptions File.\n");
        }

        return refunds;
    }
    public static Dictionary<string, double> ReadCouponsFile(string filePath)
    {
        Dictionary<string, double> coupons = new Dictionary<string, double>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && !string.IsNullOrEmpty(parts[0]) && double.TryParse(parts[1], out double discountPercent))
                {
                    coupons.Add(parts[0], discountPercent);
                }
            }
        }
        catch
        {
            throw new FileNotFoundException("Error Reading the CouponRedemptions File.\n");
        }

        return coupons;
    }

    // Updating the files
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

    public static void UpdateReservationsFile(string filePath, List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid)> reservationList)
    {
        List<string> lines = new List<string>();
        foreach (var reservation in reservationList)
        {
            string line = $"{reservation.reservationNumber},{reservation.startDate},{reservation.endDate},{reservation.roomNumber},{reservation.customerName},{reservation.paymentConfirmation},{reservation.hasCoupon},{reservation.amountPaid}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }

    public static void UpdateCustomersFile(string filePath, List<(string customerName, long cardNumber, bool isFrequentTraveler)> customersList)
    {
        List<string> lines = new List<string>();
        foreach (var customer in customersList)
        {
            string line = $"{customer.customerName},{customer.cardNumber},{customer.isFrequentTraveler}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }

    public static void UpdateRoomPricesFile(string filePath, List<(RoomType roomType, decimal dailyRate, decimal cleaningCost)> roomPrices)
    {
        List<string> lines = new List<string>();
        foreach (var price in roomPrices)
        {
            string line = $"{price.roomType},{price.dailyRate},{price.cleaningCost}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }
    public static void UpdateCouponRedemptionsFile(string filePath, List<(Guid reservationNumber, string couponCode, double discountPercentage)> couponRedemptions)
    {
        List<string> lines = new List<string>();
        foreach (var item in couponRedemptions)
        {
            string line = $"{item.reservationNumber},{item.couponCode},{item.discountPercentage}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }
    public static void UpdateRefundsFile(string filePath, List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid, DateOnly refundDate)> refunds)
    {
        List<string> lines = new List<string>();
        foreach (var item in refunds)
        {
            string line = $"{item.reservationNumber},{item.startDate},{item.endDate},{item.roomNumber},{item.customerName},{item.paymentConfirmation},{item.hasCoupon},{item.amountPaid},{item.refundDate}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }
    public static void UpdateCouponsFile(string filePath, Dictionary<string, double> coupons)
    {
        List<string> lines = new List<string>();
        foreach (var item in coupons)
        {
            string line = $"{item.Key},{item.Value}";
            lines.Add(line);
        }
        File.WriteAllLines(filePath, lines);
    }




}


