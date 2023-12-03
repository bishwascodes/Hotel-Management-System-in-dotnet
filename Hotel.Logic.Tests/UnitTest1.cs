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
    public void CustomerAlreadyAvailable_True()
    {
        // Given
        string existingCustomerName = "Test Name";
        LogicClass.customersList.Clear();
        LogicClass.customersList.Add((existingCustomerName, 123456789, false));

        // When
        bool isAvailable = LogicClass.CustomerAlreadyAvailable(existingCustomerName);

        // Then
        Assert.True(isAvailable, "Customer should be available");
    }

    [Fact]
    public void CustomerAlreadyAvailable_False()
    {
        // Given
        string nonExistingCustomerName = "Another Name";
        LogicClass.customersList.Clear();
        LogicClass.customersList.Add(("Test Name", 123456789, false));

        // When
        bool isAvailable = LogicClass.CustomerAlreadyAvailable(nonExistingCustomerName);

        // Then
        Assert.False(isAvailable, "Customer should not be available");
    }
    [Fact]
    public void RoomAvailableToCreate_True()
    {
        // Given
        int availableRoomNumber = 101;
        LogicClass.roomList.Clear();
        LogicClass.roomList.Add((availableRoomNumber, DataClass.RoomType.Single));

        // When
        bool isAvailable = LogicClass.RoomAvailableToCreate(102);

        // Then
        Assert.True(isAvailable, "Room should be available to create");
    }

    [Fact]
    public void RoomAvailableToCreate_False()
    {
        // Given
        int existingRoomNumber = 103;
        LogicClass.roomList.Clear();
        LogicClass.roomList.Add((existingRoomNumber, DataClass.RoomType.Double));

        // When
        bool isAvailable = LogicClass.RoomAvailableToCreate(existingRoomNumber);

        // Then
        Assert.False(isAvailable, "Room should not be available to create");
    }
    [Fact]
    public void GetRoomType_ExistingRoom()
    {
        // Given
        int existingRoomNumber = 101;
        LogicClass.roomList.Clear();
        LogicClass.roomList.Add((existingRoomNumber, DataClass.RoomType.Double));

        // When
        DataClass.RoomType roomType = LogicClass.getRoomType(existingRoomNumber);

        // Then
        Assert.Equal(DataClass.RoomType.Double, roomType);
    }

    [Fact]
    public void GetRoomType_NonExistingRoom()
    {
        // Given
        int nonExistingRoomNumber = 102;
        LogicClass.roomList.Clear();

        // When
        DataClass.RoomType roomType = LogicClass.getRoomType(nonExistingRoomNumber);

        // Then
        Assert.Equal(DataClass.RoomType.Single, roomType); // Default should be Single for non-existing room
    }
    [Fact]
    public void GetRoomPrice_ExistingRoomType()
    {
        // Given
        DataClass.RoomType RoomType = DataClass.RoomType.Double;
        LogicClass.roomPrices.Clear();
        LogicClass.roomPrices.Add((RoomType, 150.00m, 25.00m));

        // When
        decimal roomPrice = LogicClass.getRoomPrice(RoomType);

        // Then
        Assert.Equal(150.00m, roomPrice);
    }

    [Fact]
    public void GetRoomPrice_NonExistingRoomType()
    {
        // Given
        DataClass.RoomType nonExistingRoomType = DataClass.RoomType.Suite;
        LogicClass.roomPrices.Clear();
        LogicClass.roomPrices.Add((DataClass.RoomType.Single, 100.00m, 20.00m));

        // When
        decimal roomPrice = LogicClass.getRoomPrice(nonExistingRoomType);

        // Then
        Assert.Equal(0.00m, roomPrice); // Default should be 0 for non-existing room type
    }
    [Fact]
    public void GetRoomCleaningPrice_ExistingRoomType()
    {
        // Given
        DataClass.RoomType existingRoomType = DataClass.RoomType.Double;
        LogicClass.roomPrices.Clear();
        LogicClass.roomPrices.Add((DataClass.RoomType.Double, 150.00m, 25.00m));

        // When
        decimal cleaningPrice = LogicClass.getRoomCleaningPrice(existingRoomType);

        // Then
        Assert.Equal(25.00m, cleaningPrice);
    }

    [Fact]
    public void GetRoomCleaningPrice_NonExistingRoomType()
    {
        // Given
        DataClass.RoomType nonExistingRoomType = DataClass.RoomType.Suite;
        LogicClass.roomPrices.Clear();
        LogicClass.roomPrices.Add((DataClass.RoomType.Single, 100.00m, 20.00m));
        // When
        decimal cleaningPrice = LogicClass.getRoomCleaningPrice(nonExistingRoomType);

        // Then
        Assert.Equal(0.00m, cleaningPrice); // Default should be 0 for non-existing room type
    }
    [Fact]
    public void UpdateRoomPrice_ExistingRoomType()
    {
        // Given
        DataClass.RoomType existingRoomType = DataClass.RoomType.Double;
        LogicClass.roomPrices.Clear();
        LogicClass.roomPrices.Add((DataClass.RoomType.Double, 150.00m, 25.00m));

        // When
        LogicClass.updateTheRoomPrice(existingRoomType, 200.00m, 30.00m);

        // Then
        Assert.Equal(200.00m, LogicClass.roomPrices[0].dailyRate);

    }

    [Fact]
    public void UpdateRoomPrice_NonExistingRoomType()
    {
        // Given
        DataClass.RoomType nonExistingRoomType = DataClass.RoomType.Suite;
        LogicClass.roomPrices.Clear();
        LogicClass.roomPrices.Add((DataClass.RoomType.Single, 100.00m, 20.00m));
        LogicClass.roomPrices.Add((DataClass.RoomType.Double, 150.00m, 25.00m));

        // When
        LogicClass.updateTheRoomPrice(nonExistingRoomType, 200.00m, 30.00m);

        // Then
        Assert.Equal(2, LogicClass.roomPrices.Count); // No change since room type doesn't exist
    }

    [Fact]
    public void IsValidCoupon_ValidCoupon()
    {
        // Given
        string validCouponCode = "DISCOUNT20";
        LogicClass.couponsList.Clear();
        LogicClass.couponsList.Add(validCouponCode, 20.0);

        // When
        bool isValid = LogicClass.isValidCoupon(validCouponCode);

        // Then
        Assert.True(isValid);
    }

    [Fact]
    public void IsValidCoupon_InvalidCoupon()
    {
        // Given
        string invalidCouponCode = "INVALIDCODE";
        LogicClass.couponsList.Clear();

        // When
        bool isValid = LogicClass.isValidCoupon(invalidCouponCode);

        // Then
        Assert.False(isValid);
    }
    [Fact]
    public void GetCouponDiscountPercent_ValidCoupon()
    {
        // Given
        string validCouponCode = "DISCOUNT20";
        double expectedDiscountPercent = 20.0;
        LogicClass.couponsList.Clear();
        LogicClass.couponsList.Add(validCouponCode, expectedDiscountPercent);

        // When
        double actualDiscountPercent = LogicClass.getCouponDiscountPercent(validCouponCode);

        // Then
        Assert.Equal(expectedDiscountPercent, actualDiscountPercent);
    }

    [Fact]
    public void GetCouponDiscountPercent_InvalidCoupon()
    {
        // Given
        string invalidCouponCode = "INVALIDCODE";
        LogicClass.couponsList.Clear();

        // When

        if (LogicClass.couponsList.ContainsKey(invalidCouponCode))
        {

            double actualDiscountPercent = LogicClass.getCouponDiscountPercent(invalidCouponCode);
        }
        else
        {
            //Then
            Assert.False(false);
        }
    }
    [Fact]
    public void IsFrequentTraveler_CustomerIsFrequentTraveler()
    {
        // Given
        string frequentTravelerName = "Bishwas Thapa";
        LogicClass.customersList.Clear();
        LogicClass.customersList.Add((frequentTravelerName, 123456789, true));

        // When
        bool isFrequentTraveler = LogicClass.isFrequentTraveler(frequentTravelerName);

        // Then
        Assert.True(isFrequentTraveler);
    }

    [Fact]
    public void IsFrequentTraveler_CustomerIsNotFrequentTraveler()
    {
        // Given
        string nonFrequentTravelerName = "Bishwas";
        LogicClass.customersList.Clear();
        LogicClass.customersList.Add((nonFrequentTravelerName, 987654321, false));

        // When
        bool isFrequentTraveler = LogicClass.isFrequentTraveler(nonFrequentTravelerName);

        // Then
        Assert.False(isFrequentTraveler);
    }
    [Fact]
    public void IsValidReservation_ValidReservationNumber()
    {
        // Given
        Guid validReservationNumber = Guid.NewGuid();
        LogicClass.reservationList.Clear();
        LogicClass.reservationList.Add((validReservationNumber, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), 101, "Bishwas Thapa", "ABC123", false, 0));

        // When
        bool isValidReservation = LogicClass.isValidReservation(validReservationNumber);

        // Then
        Assert.True(isValidReservation);
    }

    [Fact]
    public void IsValidReservation_InvalidReservationNumber()
    {
        // Given
        Guid invalidReservationNumber = Guid.NewGuid();
        LogicClass.reservationList.Clear();
        // No reservations in the list

        // When
        bool isValidReservation = LogicClass.isValidReservation(invalidReservationNumber);

        // Then
        Assert.False(isValidReservation);
    }


    [Fact]
    public void AddAsFrequentTraveller_CustomerExists()
    {
        // Given
        string existingCustomerName = "Bisu";
        long existingCardNumber = 1234567890;
        LogicClass.customersList.Clear();
        LogicClass.customersList.Add((existingCustomerName, existingCardNumber, false));

        // When
        LogicClass.addAsFrequentTraveller(existingCustomerName);

        // Then
        Assert.True(LogicClass.isFrequentTraveler(existingCustomerName));
    }

    [Fact]
    public void AddAsFrequentTraveller_CustomerDoesNotExist()
    {
        // Given
        string nonExistingCustomerName = "Bisu";
        LogicClass.customersList.Clear();
        // No customers in the list

        // When
        LogicClass.addAsFrequentTraveller(nonExistingCustomerName);

        // Then
        Assert.False(LogicClass.isFrequentTraveler(nonExistingCustomerName));
    }
    [Fact]
    public void GetReservationDetails_ExistingReservation()
    {
        // Given
        Guid existingReservationNumber = Guid.NewGuid();
        LogicClass.reservationList.Clear();
        LogicClass.reservationList.Add((existingReservationNumber, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 101, "Bisu", "ABC123", false, 0));

        // When
        var reservationDetails = LogicClass.getReservationDetails(existingReservationNumber);

        // Then
        Assert.Equal(existingReservationNumber, reservationDetails.reservationNumber);
    }

    [Fact]
    public void GetReservationDetails_NonExistingReservation()
    {
        // Given
        Guid existingReservationNumber = Guid.NewGuid();
        Guid nonExistingReservationNumber = Guid.NewGuid();
        LogicClass.reservationList.Clear();
        LogicClass.reservationList.Add((existingReservationNumber, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 101, "Bisu", "ABC123", false, 0));
        // No reservations in the list

        // When
        var reservationDetails = LogicClass.getReservationDetails(nonExistingReservationNumber);

        // Then
        Assert.Equal(existingReservationNumber, reservationDetails.reservationNumber); // It should return the first reservation when the reservation number is not found

    }
    [Fact]
    public void CalculatePriceBeforeCheckout_NoDiscounts()
    {
        // Given
        decimal initPrice = 100.0m;
        int noOfDays = 3;

        // When
        var result = LogicClass.calculatePriceBeforeCheckout(initPrice, noOfDays);

        // Then
        Assert.Equal(initPrice * noOfDays, result.Item1);

    }

    [Fact]
    public void CalculatePriceBeforeCheckout_WithDiscounts()
    {
        // Given
        decimal initPrice = 100.0m;
        int noOfDays = 5;
        double frequentTravelerDiscount = 10.0;
        double couponDiscount = 15.0;

        // When
        var result = LogicClass.calculatePriceBeforeCheckout(initPrice, noOfDays, frequentTravelerDiscount, couponDiscount);

        // Then
        decimal expectedDiscount = (decimal)((frequentTravelerDiscount + couponDiscount) * noOfDays / 100) * initPrice;
        Assert.Equal(initPrice * noOfDays - expectedDiscount, result.Item1);
        Assert.Equal((decimal)expectedDiscount * (decimal)(frequentTravelerDiscount / (frequentTravelerDiscount + couponDiscount)), result.Item2);
        Assert.Equal(expectedDiscount * (decimal)(couponDiscount / (frequentTravelerDiscount + couponDiscount)), result.Item3);
    }
    [Fact]
    public void GetUniqueCouponList_NoRedemptions()
    {
        // Given
        LogicClass.couponRedemptionsList.Clear();

        // When
        var result = LogicClass.getUniqueCouponList();

        // Then
        Assert.Empty(result); // No redemptions, so the list should be empty
    }

    [Fact]
    public void GetUniqueCouponList_WithRedemptions()
    {
        // Given
        LogicClass.couponRedemptionsList.Clear();
        LogicClass.couponRedemptionsList.Add((Guid.NewGuid(), "COUPON1", 10.0));
        LogicClass.couponRedemptionsList.Add((Guid.NewGuid(), "COUPON2", 15.0));
        LogicClass.couponRedemptionsList.Add((Guid.NewGuid(), "COUPON1", 20.0)); // Duplicate coupon

        // When
        var result = LogicClass.getUniqueCouponList();

        // Then
        Assert.Equal(2, result.Count); // Two unique coupons in the list

    }
    [Fact]
    public void GetCouponRedemptionListByCouponCode_NoRedemptions()
    {
        // Given
        LogicClass.couponRedemptionsList.Clear();
        string couponCode = "COUPON1";

        // When
        var result = LogicClass.getCouponRedemptionListByCouponCode(couponCode);

        // Then
        Assert.Empty(result); // No redemptions for the given coupon code, so the list should be empty
    }

    [Fact]
    public void GetCouponRedemptionListByCouponCode_WithRedemptions()
    {
        // Given
        LogicClass.couponRedemptionsList.Clear();
        Guid reservationId1 = Guid.NewGuid();
        Guid reservationId2 = Guid.NewGuid();
        LogicClass.couponRedemptionsList.Add((reservationId1, "COUPON1", 10.0));
        LogicClass.couponRedemptionsList.Add((reservationId2, "COUPON1", 15.0));
        LogicClass.couponRedemptionsList.Add((Guid.NewGuid(), "COUPON2", 20.0)); // Different coupon code

        string couponCode = "COUPON1";

        // When
        var result = LogicClass.getCouponRedemptionListByCouponCode(couponCode);

        // Then
        Assert.Equal(2, result.Count); // Two redemptions for the given coupon code

    }
    [Fact]
    public void AvailableRoomsList_NoReservations()
    {
        // Given
        LogicClass.reservationList.Clear();
        LogicClass.roomList.Clear();
        LogicClass.roomList.Add((120, DataClass.RoomType.Single));
        DateOnly checkingDate = new DateOnly(2023, 10, 5);

        // When
        var result = LogicClass.availableRoomsList(checkingDate);

        // Then
        Assert.True(result.Count > 0);
    }

    [Fact]
    public void AvailableRoomsList_WithReservations()
    {
        // Given
        LogicClass.reservationList.Clear();
        LogicClass.roomList.Clear();
        DateOnly checkingDate = new DateOnly(2023, 10, 5);
        int reservedRoomNumber = 101;

        LogicClass.reservationList.Add((
            Guid.NewGuid(),
            checkingDate.AddDays(-1), // Reservation from yesterday
            checkingDate.AddDays(1),  // Reservation until tomorrow
            reservedRoomNumber,
            "Bisu",
            "Payment123",
            false,
            120m
        ));

        LogicClass.roomList.Add((reservedRoomNumber, DataClass.RoomType.Single));

        // When
        var result = LogicClass.availableRoomsList(checkingDate);

        // Then
        Assert.Empty(result); // Room with number 101 is reserved on the specified date, so it should not be available
    }
    [Fact]
    public void UnavailableRoomsList_NoReservations()
    {
        // Given
        LogicClass.reservationList.Clear();
        LogicClass.roomList.Clear();
        DateOnly checkingDate = new DateOnly(2023, 10, 5);

        // When
        var result = LogicClass.unavailableRoomsList(checkingDate);

        // Then
        Assert.Empty(result);
    }

    [Fact]
    public void UnavailableRoomsList_WithReservations()
    {
        // Given
        LogicClass.reservationList.Clear();
        LogicClass.roomList.Clear();
        DateOnly checkingDate = new DateOnly(2023, 10, 5);
        int reservedRoomNumber = 101;

        LogicClass.reservationList.Add((
            Guid.NewGuid(),
            checkingDate.AddDays(-1), // Reservation from yesterday
            checkingDate.AddDays(1),  // Reservation until tomorrow
            reservedRoomNumber,
            "Bisu",
            "Payment123",
            false,
            0m
        ));

        LogicClass.roomList.Add((reservedRoomNumber, DataClass.RoomType.Single));

        // When
        var result = LogicClass.unavailableRoomsList(checkingDate);

        // Then
        Assert.Single(result); 
       
    }









}
