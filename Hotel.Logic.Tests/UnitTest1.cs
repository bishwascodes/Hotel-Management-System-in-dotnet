namespace Hotel.Logic.Tests;
using Hotel.Logic;
public class UnitTest1
{

    [Fact]
    public void RoomIsAvailable_True()
    {
        // Arrange
        var bookingDate = new DateOnly(2023, 10, 5);
        int roomNumber = 101;

        // Act
        var isAvailable = LogicClass.RoomIsAvailable(bookingDate, roomNumber);

        // Assert
        Assert.False(isAvailable, "Room should be available on the specified day.");
    }

    [Fact]
    public void RoomIsAvailable_False()
    {
        // Arrange
        var bookingDate = new DateOnly(2023, 11, 11);
        int roomNumber = 101;


        // Act
        var isAvailable = LogicClass.RoomIsAvailable(bookingDate, roomNumber);

        // Assert
        Assert.True(isAvailable, "Room should not be available on the specified day.");
    }

}