namespace Hotel.Logic.Tests;
using Hotel.Logic;
using Hotel.Data;
public class UnitTest1
{

    // [Fact]
    // public void RoomIsAvailable_True()
    // {

    //     var bookingDate = new DateOnly(2023, 10, 5);
    //     int roomNumber = 101;
    //     LogicClass.reservationList.Clear();

    //     var isAvailable = LogicClass.RoomIsAvailable(bookingDate, roomNumber);

    //     // Assert
    //     Assert.True(isAvailable, "Room should be available on the specified day.");
    // }

    // [Fact]
    // public void RoomIsAvailable_False()
    // {

    //     var bookingDate = new DateOnly(2024, 11, 11);
    //     int roomNumber = 101;
    //     LogicClass.reservationList.Clear();
    //     LogicClass.reservationList.Add((Guid.NewGuid(), bookingDate, roomNumber, "Bishwas Thapa", "HFHDSBfHFUEFSNSSYBFRBHSIS"));
    //     var isAvailable = LogicClass.RoomIsAvailable(bookingDate, roomNumber);
    //     if (isAvailable == false)
    //     {
    //         Assert.True(true, "Room should be available on the specified day.");
    //     }
    //     else
    //     {
    //         // Assert

    //         Assert.Fail("Room should not be available on the specified day.");
    //     }

    // }
    // [Fact]
    // public void addingToCustomersPass()
    // {
    //     // Given
    //     string name = ("Test Name");
    //     long cardNumber = 125385425685;
    //     LogicClass.customersList.Clear();
    //     // When
    //     if (LogicClass.CustomerAlreadyAvailable(name))
    //     {
    //         LogicClass.addToCustomers((name, cardNumber));
    //     }
    //     // Then
    //     Assert.True(LogicClass.customersList.Count > 0, "Add the customer");
    // }
    // [Fact]
    // public void addingToCustomersFail()
    // {
    //     // Given
    //     string name = ("Test Name");
    //     long cardNumber = 125385425685;
    //     LogicClass.customersList.Clear();
    //     LogicClass.customersList.Add(("Test Name", 125385425685));
    //     // When
    //     if (LogicClass.CustomerAlreadyAvailable(name))
    //     {
    //         LogicClass.addToCustomers((name, cardNumber));
    //     }
    //     // Then
    //     Assert.False(LogicClass.customersList.Count > 1, "Can't add the customer");
    // }
    [Fact]
    public void returningTheRoomPricePass()
    {
        // Given
        DataClass.RoomType type = DataClass.RoomType.Single;
        LogicClass.roomPrices.Clear();
        LogicClass.roomPrices.Add((DataClass.RoomType.Single, 200.00m));

        // When
        var output = LogicClass.getRoomPrice(type);
        // Then
        Assert.True(output > 0);
    }
    [Fact]
    public void returningTheRoomPriceFail()
    {
        // Given
        DataClass.RoomType type = DataClass.RoomType.Single;
        LogicClass.roomPrices.Clear();
        LogicClass.roomPrices.Add((DataClass.RoomType.Double, 200.00m));

        // When
        var output = LogicClass.getRoomPrice(type);
        // Then
        Assert.Equal(0m,output);
        
    }

}