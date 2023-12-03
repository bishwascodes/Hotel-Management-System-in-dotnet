namespace Hotel.Logic;

using System.Runtime.CompilerServices;
using Hotel.Data;
using Microsoft.VisualBasic;

public class LogicClass
{
    // To load the files from any directory
    public static string FindFile(string fileName)
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (true)
        {
            var testPath = Path.Combine(directory.FullName, fileName);
            if (File.Exists(testPath))
            {
                return testPath;
            }
            if (directory.FullName == directory.Root.FullName)
            {
                return testPath;
            }
            directory = directory.Parent;
        }
    }
    // File Paths
    public static string roomsFile = "Rooms.txt";
    public static string reservationsFile = "Reservations.txt";
    public static string customersFile = "Customers.txt";
    public static string roomPricesFile = "RoomPrices.txt";
    public static string couponsFile = "Coupons.txt";
    public static string couponRedemptionFile = "CouponRedemption.txt";
    public static string refundsFile = "Refunds.txt";

    // Init the lists
    public static List<(int roomNumber, DataClass.RoomType type)> roomList = new();
    public static List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid)> reservationList = new();
    public static List<(string customerName, long cardNumber, bool isFrequentTraveler)> customersList = new();
    public static List<(DataClass.RoomType roomType, decimal dailyRate, decimal cleaningCost)> roomPrices = new();
    public static List<(Guid reservationNumber, string couponCode, double discountPercentage)> couponRedemptionsList = new();
    public static List<(Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid, DateOnly refundDate)> refundsList = new();
    public static Dictionary<string, double> couponsList = new Dictionary<string, double>();

    // Actual Fetching of the data
    public static void GetDataFromFiles()
    {
        var errorMessages = "";
        try
        {
            roomList = DataClass.ReadRoomFile(FindFile(roomsFile));
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }

        try
        {
            reservationList = DataClass.ReadReservationsFile(FindFile(reservationsFile));
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }

        try
        {
            customersList = DataClass.ReadCustomersFile(FindFile(customersFile));
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }

        try
        {
            roomPrices = DataClass.ReadRoomPricesFile(FindFile(roomPricesFile));
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }

        try
        {
            couponRedemptionsList = DataClass.ReadCouponRedemptionsFile(FindFile(couponRedemptionFile));
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }

        try
        {
            refundsList = DataClass.ReadRefundsFile(FindFile(refundsFile));
        }
        catch (FileNotFoundException e)
        {
            errorMessages += e.Message;
        }

        try
        {
            couponsList = DataClass.ReadCouponsFile(FindFile(couponsFile));
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
    public static void addToReservationList((Guid, DateOnly, DateOnly, int, string, string, bool, decimal) reservationData)
    {
        reservationList.Add((reservationData.Item1, reservationData.Item2, reservationData.Item3, reservationData.Item4, reservationData.Item5, reservationData.Item6, reservationData.Item7, reservationData.Item8));
    }
    public static void addToCustomers((string, long, bool) customerData)
    {
        customersList.Add((customerData.Item1, customerData.Item2, customerData.Item3));
    }
    public static void addToRoomPrice((DataClass.RoomType roomType, decimal dailyRate, decimal cleaningCost) roomPriceDatas)
    {
        roomPrices.Add((roomPriceDatas.roomType, roomPriceDatas.dailyRate, roomPriceDatas.cleaningCost));
    }
    public static void addToReFundsList((Guid, DateOnly, DateOnly, int, string, string, bool, decimal, DateOnly) refundsData)
    {
        refundsList.Add((refundsData.Item1, refundsData.Item2, refundsData.Item3, refundsData.Item4, refundsData.Item5, refundsData.Item6, refundsData.Item7, refundsData.Item8, refundsData.Item9));
    }


    // Removing items from each list 

    public static void removeFromCustomers(string nameToRemove)
    {

        customersList.RemoveAll(customer => customer.Item1.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase));

    }

    public static void removeFromReservation(Guid ourReservationNumber)
    {
        reservationList.RemoveAll(reservation => Guid.Equals(reservation.Item1, ourReservationNumber));
    }

    // Updating the changed files

    public static void saveAllToFiles()
    {
        DataClass.UpdateCustomersFile(FindFile(customersFile), customersList);
        DataClass.UpdateRoomFile(FindFile(roomsFile), roomList);
        DataClass.UpdateReservationsFile(FindFile(reservationsFile), reservationList);
        DataClass.UpdateRoomPricesFile(FindFile(roomPricesFile), roomPrices);
        DataClass.UpdateRefundsFile(FindFile(refundsFile), refundsList);
        DataClass.UpdateCouponRedemptionsFile(FindFile(couponRedemptionFile), couponRedemptionsList);
        DataClass.UpdateCouponsFile(FindFile(couponsFile), couponsList);
    }








    // Methods 
    public static List<(int, DataClass.RoomType)> availableRoomsList(DateOnly checkingDate)
    {
        List<(int, string)> rooms = new();
        List<int> numbers = new();

        foreach ((Guid guid, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid) in LogicClass.reservationList)
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

    public static int GetDaysBetweenDates(DateOnly startDate, DateOnly endDate)
    {
        var duration = endDate.DayNumber - startDate.DayNumber;
        return duration;
    }

    public static DataClass.RoomType getRoomType(int ourRoomNumber)
    {
        foreach (var room in roomList)
        {
            if (room.roomNumber == ourRoomNumber)
            {
                return room.type;
            }
        }
        return DataClass.RoomType.Single; //Setting default in case we can't find the roomNumber
    }
    public static decimal getRoomPrice(DataClass.RoomType type)
    {
        decimal currentPrice = 0;
        foreach ((DataClass.RoomType roomType, decimal dailyRate, decimal cleaningCost) item in roomPrices)
        {
            if (item.roomType == type)
            {
                currentPrice = item.dailyRate;
                break;
            }
        }
        return currentPrice;
    }
    public static decimal getRoomCleaningPrice(DataClass.RoomType type)
    {
        decimal cleaningPrice = 0;
        foreach ((DataClass.RoomType roomType, decimal dailyRate, decimal cleaningCost) item in roomPrices)
        {
            if (item.roomType == type)
            {
                cleaningPrice = item.cleaningCost;
                break;
            }
        }
        return cleaningPrice;
    }
    public static void updateTheRoomPrice(DataClass.RoomType roomTypeValue, decimal getPrice, decimal cleaningCost)
    {
        for (int i = 0; i < roomPrices.Count; i++)
        {
            var item = roomPrices[i];
            if (item.roomType == roomTypeValue)
            {
                roomPrices[i] = (item.roomType, getPrice, cleaningCost);
                break;
            }
        }
    }

    public static bool isValidCoupon(string couponCode)
    {
        return couponsList.ContainsKey(couponCode);
    }

    public static double getCouponDiscountPercent(string couponCode)
    {
        return (double)couponsList[couponCode];
    }
    public static bool isFrequentTraveler(string name)
    {
        var customerFileData = customersList;
        bool isFreqTraveler = false;
        foreach (var data in customerFileData)
        {
            if (data.customerName.ToLower().Trim() == name.ToLower())
            {
                isFreqTraveler = data.isFrequentTraveler;
                break;
            }

        }
        return isFreqTraveler;
    }
    public static bool isValidReservation(Guid ourReservationNumber)
    {

        for (int i = 0; i < reservationList.Count; i++)
        {
            var item = reservationList[i];
            if (item.reservationNumber == ourReservationNumber)
            {
                return true;
            }
        }
        return false;
    }
    public static void addAsFrequentTraveller(string name)
    {

        for (int i = 0; i < customersList.Count; i++)
        {
            if (customersList[i].customerName.ToLower().Trim() == name.ToLower())
            {
                customersList[i] = (customersList[i].customerName, customersList[i].cardNumber, true);
            }
        }
    }
    public static (Guid reservationNumber, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid) getReservationDetails(Guid ourReservationNumber)
    {
        for (int i = 0; i < reservationList.Count; i++)
        {
            var item = reservationList[i];
            if (item.reservationNumber == ourReservationNumber)
            {
                return item;
            }
        }
        // If reservation Number not found, we'll return the very first reservation
        return reservationList[0];
    }


    public static (decimal, decimal, decimal) calculatePriceBeforeCheckout(decimal initPrice, int noOfDays, double frequentTravelerDiscount = 0, double couponDiscount = 0)
    {
        decimal frequentTravelerDiscountAmt = (decimal)(frequentTravelerDiscount * noOfDays / 100) * initPrice;
        decimal couponDiscountAmount = (decimal)(couponDiscount * noOfDays / 100) * initPrice;
        return ((initPrice * noOfDays - frequentTravelerDiscountAmt - couponDiscountAmount), frequentTravelerDiscountAmt, couponDiscountAmount);
    }
    public static List<string> getUniqueCouponList()
    {
        List<string> uniqueCouponsList = new List<string>();
        for (int i = 0; i < couponRedemptionsList.Count; i++)
        {
            string currentCoupon = couponRedemptionsList[i].couponCode;
            if (!uniqueCouponsList.Contains(currentCoupon))
            {
                uniqueCouponsList.Add(currentCoupon);
            }
        }
        return uniqueCouponsList;
    }
    public static List<(Guid reservationNumber, string couponCode, double discountPercentage)> getCouponRedemptionListByCouponCode(string CouponCode)
    {
        List<(Guid reservationNumber, string couponCode, double discountPercentage)> List = new();
        for (int i = 0; i < couponRedemptionsList.Count; i++)
        {
            var item = couponRedemptionsList[i];
            if (item.couponCode == CouponCode)
            {
                List.Add(item);
            }
        }
        return List;
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
