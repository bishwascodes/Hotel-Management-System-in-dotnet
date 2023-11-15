namespace Hotel.Logic.Tests;
using Hotel.Logic;
public class UnitTest1
{

    [Fact]
    public void RoomIsAvailable_True()
    {

        var bookingDate = new DateOnly(2023, 10, 5);
        int roomNumber = 101;
        LogicClass.reservationList.Clear();

        var isAvailable = LogicClass.RoomIsAvailable(bookingDate, roomNumber);

        // Assert
        Assert.True(isAvailable, "Room should be available on the specified day.");
    }

    [Fact]
    public void RoomIsAvailable_False()
    {

        var bookingDate = new DateOnly(2024, 11, 11);
        int roomNumber = 101;
        LogicClass.reservationList.Clear();
        LogicClass.reservationList.Add((Guid.NewGuid(), bookingDate, roomNumber, "Bishwas Thapa", "HFHDSBfHFUEFSNSSYBFRBHSIS"));
        var isAvailable = LogicClass.RoomIsAvailable(bookingDate, roomNumber);
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

}