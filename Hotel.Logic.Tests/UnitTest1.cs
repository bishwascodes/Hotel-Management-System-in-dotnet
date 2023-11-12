namespace Hotel.Logic.Tests;
using Hotel.Logic;
public class UnitTest1
{
    [Fact]
    public void ReserveDateNotTaken()
    {
        // Arrange
        var reservationData = (Guid.NewGuid(), DateOnly.Parse("11/05/2023"), 102, "Bishwas Ji", LogicClass.GenerateRandomString(30));
        var newReservationDate = reservationData.Item2;
        var newReservationRoom = reservationData.Item3;
        var reservationFileData = LogicClass.reservationList;
        bool result = true;
        foreach (var data in reservationFileData)
        {
            if (data.date == newReservationDate && data.roomNumber == newReservationRoom)
            {
                result = false;
            }

        }
        if (result == true)
        {
            LogicClass.addToReservationList(reservationData);
            LogicClass.UpdateReservationsFile("..\\Reservations.txt", reservationFileData);
        }
        Assert.True(result, "Reservation should succeed");
    }

    [Fact]
    public void ReserveDateAlreadyTaken()
    {
        var reservationData = (Guid.NewGuid(), DateOnly.Parse("11/11/2023"), 101, "Peter Malan", LogicClass.GenerateRandomString(30));

        var newReservationDate = reservationData.Item2;
        var newReservationRoom = reservationData.Item3;
        var reservationFileData = LogicClass.reservationList;
        bool result = false;
        foreach (var data in reservationFileData)
        {
            if (data.date == newReservationDate && data.roomNumber == newReservationRoom)
            {
                result = true;

            }
        }
        // Assert
        Assert.False(result, "Reservation failed because the date is already reserved");
    }
}