﻿namespace Hotel.Logic;
using Hotel.Data;

public class LogicClass
{
    // File Paths
    public static string roomsFile = "..\\Rooms.txt";
    public static string reservationsFile = "..\\Reservations.txt";
    public static string customersFile = "..\\Customers.txt";
    public static string roomPricesFile = "..\\RoomPrices.txt";

    public static List<(int roomNumber, string type)> roomList = DataClass.ReadRoomFile(roomsFile);
    public static List<(Guid reservationNumber, DateOnly date, int roomNumber, string customerName, string paymentConfirmation)> reservationList = DataClass.ReadReservationsFile(reservationsFile);
    public static List<(string customerName, long cardNumber)> customersList = DataClass.ReadCustomersFile(customersFile);
    public static List<(string roomType, decimal dailyRate)> roomPrices = DataClass.ReadRoomPricesFile(roomPricesFile);



    // Adding items to each list 
    public static void addToRoom((int, string) roomData)
    {
        roomList.Add((roomData.Item1, roomData.Item2));
    }
    public static void addToReservationList((Guid, DateOnly, int, string, string) reservationData)
    {
        reservationList.Add((reservationData.Item1, reservationData.Item2, reservationData.Item3, reservationData.Item4, reservationData.Item5));
    }
    public static void addToCustomers((string, long) customerData)
    {
        customersList.Add((customerData.Item1, customerData.Item2));
    }
    public static void addToRoomPrice((string roomType, decimal dailyRate) roomPriceDatas)
    {
        roomPrices.Add((roomPriceDatas.roomType, roomPriceDatas.dailyRate));
    }








    // Methods 

    public static bool RoomIsAvailable(DateOnly bookingDate, int roomNumber)
    {
        var newReservationDate = bookingDate;
        var newReservationRoom = roomNumber;
        var reservationFileData = reservationList;
        bool isAvailable = true;
        foreach (var data in reservationFileData)
        {
            if (data.date == newReservationDate && data.roomNumber == newReservationRoom)
            {
                isAvailable = false;
                break;
            }

        }
        return isAvailable;
    }
    public static bool CustomerIsAvailable(string name)
    {
      
        var customerFileData = customersList;
        bool isAvailable = true;
        foreach (var data in customerFileData)
        {
            if (data.customerName.ToLower() == name.ToLower())
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
