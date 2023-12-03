namespace Hotel.Logic.Tests;
using Hotel.Logic;
using Hotel.Data;
public class UnitTest1
{

    [Fact]
    public void RoomIsAvailable_True()
    {

        var bookingStartDate = new DateOnly(2023, 10, 5);
        var bookingEndDate = new DateOnly(2023, 10, 8);
        int roomNumber = 101;
        LogicClass.reservationList.Clear();

        var isAvailable = LogicClass.RoomIsAvailable(bookingStartDate, bookingEndDate, roomNumber);

        // Assert
        Assert.True(isAvailable, "Room should be available on the specified day.");
    }

    [Fact]
    public void RoomIsAvailable_False()
    {

        var bookingStartDate = new DateOnly(2023, 10, 5);
        var bookingEndDate = new DateOnly(2023, 10, 8);
        int roomNumber = 101;
        LogicClass.reservationList.Clear();
        LogicClass.reservationList.Add((Guid.NewGuid(), bookingStartDate, bookingEndDate, roomNumber, "Bishwas Thapa", "HFHDSBfHFUEFSNSSYBFRBHSIS", false, 320m));
        var isAvailable = LogicClass.RoomIsAvailable(bookingStartDate, bookingEndDate, roomNumber);
        if (isAvailable == false)
        {
            Assert.True(true, "Room should be available on the specified day.");
        }
        else
        {
            // Assert
            Assert.Fail("Room should not be available on the specified day.");
        }

    }
    [Fact]
    public void addingToCustomersPass()
    {
        // Given
        string name = "Test";
        long cardNumber = 125385425685;
        LogicClass.customersList.Clear();
        // When
        if (!LogicClass.CustomerAlreadyAvailable(name))
        {
            LogicClass.addToCustomers((name, cardNumber, false));
        }
        // Then
        Assert.True(LogicClass.customersList.Count > 0);
    }
    [Fact]
    public void addingToCustomersFail()
    {
        // Given
        string name = "Test Name";
        long cardNumber = 125385425685;
        LogicClass.customersList.Clear();
        LogicClass.customersList.Add(("Test Name", 125385425685, false));
        // When
        if (!LogicClass.CustomerAlreadyAvailable(name))
        {
            LogicClass.addToCustomers((name, cardNumber, false));
        }
        // Then
        if (LogicClass.customersList.Count > 1)
        {
            Assert.Fail("Can't add the customer");
        }

    }
    [Fact]
    public void returningTheRoomPricePass()
    {
        // Given
        DataClass.RoomType type = DataClass.RoomType.Single;
        LogicClass.roomPrices.Clear();
        LogicClass.roomPrices.Add((DataClass.RoomType.Single, 200.00m, 10.0m));

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
        LogicClass.roomPrices.Add((DataClass.RoomType.Double, 200.00m, 10.0m));

        // When
        var output = LogicClass.getRoomPrice(type);
        // Then
        Assert.Equal(0m, output);

    }

    [Fact]
    public void GetCouponRedemptionListByCouponCode_Exists()
    {
        // Arrange
        var couponCode = "ABC123";
        LogicClass.couponRedemptionsList.Clear();
        LogicClass.couponRedemptionsList.Add((Guid.NewGuid(), couponCode.ToUpper().Trim(), 20));
        // Act
        var redemptionList = LogicClass.getCouponRedemptionListByCouponCode(couponCode);

        // Assert
        Assert.True(redemptionList.Count > 0);
    }


}
