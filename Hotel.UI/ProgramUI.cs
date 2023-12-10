// CS1400 - Fall 2023 - Bishwas Thapa

using Hotel.Logic;
// Only for the Enum RoomType
using Hotel.Data;
using System.Runtime.CompilerServices;

//Console.Clear();
try
{
    LogicClass.GetDataFromFiles();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}
int userChoice = 0;
string recentMessage = "";
do
{
    Console.Clear();
    Console.WriteLine($"************ Main Menu ************ \n{recentMessage}\nWelcome to Hotel Management System. \n Here's you navigation menu: \n 1. Customer Management \n 2. Room Management \n 3. Reservation Management \n 4. Promotions and Reports \n 5. Save and exit");
    userChoice = getInt(1, 5, "Choose any number from 1 to 5: ");
    if (userChoice == 1)
    {
        customerManagementUI();
    }
    else if (userChoice == 2)
    {
        roomManagementUI();
    }
    else if (userChoice == 3)
    {
        reservationManagementUI();
    }
    else if (userChoice == 4)
    {
        promotionsAndReportsUI();
    }
    else if (userChoice == 5)
    {
        LogicClass.saveAllToFiles();
        Console.WriteLine("Thanks for using my App.");
        break;
    }

} while (true);


// UI Methods
int getInt(int min = int.MinValue, int max = int.MaxValue, string Prompt = "")
{
    Console.Write(Prompt);
    bool isValid = false;
    int returnValue = 0;
    int count = 0;
    while (isValid == false || returnValue < min || returnValue > max)
    {
        if (count > 0)
        {
            Console.Write("Invalid input! Try again: ");
        }
        isValid = int.TryParse(Console.ReadLine(), out returnValue);
        count++;
    }

    return returnValue;
}
decimal getDecimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue, string Prompt = "")
{
    Console.Write(Prompt);
    bool isValid = false;
    decimal returnValue = 0;
    int count = 0;
    while (isValid == false || returnValue < min || returnValue > max)
    {
        if (count > 0)
        {
            Console.Write("Invalid input! Try again: ");
        }
        isValid = decimal.TryParse(Console.ReadLine(), out returnValue);
        count++;
    }

    return returnValue;
}
long getLong(long min = long.MinValue, long max = long.MaxValue, string Prompt = "")
{
    Console.Write(Prompt);
    bool isValid = false;
    long returnValue = 0;
    int count = 0;
    while (isValid == false || returnValue < min || returnValue > max)
    {
        if (count > 0)
        {
            Console.Write("Invalid input! Try again: ");
        }
        isValid = long.TryParse(Console.ReadLine(), out returnValue);
        count++;
    }

    return returnValue;
}
string getString(string prompt = "")
{
    Console.Write(prompt);
    string returnValue = Console.ReadLine();
    return returnValue;
}
DateOnly getDate(string prompt = "")
{
    DateOnly returnValue;
    Console.Write(prompt);
    bool isValid = false;
    while (true)
    {
        isValid = DateOnly.TryParse(Console.ReadLine(), out returnValue);
        if (isValid == true)
        {
            return returnValue;
        }
    }

}
void PressToContinue(string prompt = "Press any key to continue: ")
{
    Console.Write(prompt);
    while (Console.KeyAvailable)
    {
        Console.ReadKey(true);
    }
    Console.ReadKey(true);

}

// UI Components
void customerManagementUI()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"*****  Main Menu  ******* Customer Management ************ \n{recentMessage} Here's you navigation menu: \n 1. Add New Customer \n 2. View Customer Details \n 3. Delete Customer \n 4. Prior Reservation for Customer\n 5. Make Frequent Traveller \n 6. Save changes and exit to main menu ");
        userChoice = getInt(1, 6, "Choose any number from 1 to 6: ");
        while (true)
        {
            if (userChoice == 1)
            {
                addNewCustomerUI();
                break;
            }
            else if (userChoice == 2)
            {
                customersDetailsUI();
                break;
            }

            else if (userChoice == 3)
            {
                removeACustomerUI();
                break;
            }

            else if (userChoice == 4)
            {
                var customer = priorReservationForCustomerUITop();
                if (!LogicClass.CustomerAlreadyAvailable(customer))
                {
                    PressToContinue($"The user {customer} doesn't exist. Press any key to continue: ");
                    recentMessage = $"\nMessage: The customer with the name {customer} not found. \n";
                    break;
                }
                priorReservationForCustomerUI(customer);
                break;
            }

            else if (userChoice == 5)
            {
                Console.Clear();
                Console.WriteLine("***  Customer Management  *** Make Frequent Traveller *** \n ");
                string customer = getString("Please enter the name of customer: ");
                if (!LogicClass.CustomerAlreadyAvailable(customer))
                {
                    Console.Write($"The user {customer} doesn't exist. ");
                    PressToContinue();
                    recentMessage = $"\nMessage: The customer with the name {customer} not found. \n";
                    break;
                }
                if (LogicClass.isFrequentTraveler(customer))
                {
                    Console.Write($"The user {customer} is already a Frequent Traveller. ");
                    PressToContinue();
                    recentMessage = $"\nMessage: The customer with the name {customer} is already a Frequent traveller. \n";
                    break;
                }
                LogicClass.addAsFrequentTraveller(customer);
                Console.Write($"Success! The customer {customer} is now a Frequent traveller.");
                PressToContinue();
                recentMessage = $"\nMessage:The user {customer} successfully added as a Frequent Traveller. \n";
                break;
            }
            else if (userChoice == 6)
            {
                break;
            }
        }
        if (userChoice == 6)
        {
            LogicClass.saveAllToFiles();
            recentMessage = "\nMessage: All the recent changes were saved successfully in files.\n";
            break;
        }

    }
}
void roomManagementUI()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"************ Room Management ************ \n{recentMessage} Here's you navigation menu: \n 1. Add New Room \n 2. Change Room Pricing \n 3.  Cost Tracking Report \n 4. Save changes and return to main menu ");
        userChoice = getInt(1, 4, "Choose any number from 1 to 4: ");
        while (true)
        {
            if (userChoice == 1)
            {
                addANewRoomUI();
                break;
            }
            else if (userChoice == 2)
            {
                changeRoomPriceUI();
                break;
            }
            else if (userChoice == 3)
            {
                PressToContinue("Feature Coming soon. Press any key to continue: ");
                break;
            }
            else if (userChoice == 4)
            {
                break;
            }
        }
        if (userChoice == 4)
        {
            LogicClass.saveAllToFiles();
            recentMessage = "\nMessage: All the recent changes were saved successfully in files.\n";
            break;
        }
    }
}
void reservationManagementUI()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"************ Reservation Management ************ \n{recentMessage} Here's you navigation menu: \n 1. Add New Reservation \n 2. View All Reservations \n 3. Reservation Report by Customer Name(Future) \n 4. Reservation Report by Date \n 5. Available Room Search by Date \n 6. Refund a Reservation \n 7. Save changes and return to main menu ");
        userChoice = getInt(1, 7, "Choose any number from 1 to 7: ");
        while (true)
        {
            if (userChoice == 1)
            {
                addNewReservationUI();
                break;
            }
            else if (userChoice == 2)
            {
                Console.Clear();
                Console.WriteLine("***  Reservation Management  *** Reservation Details  *** \n [*********Reservation Number*********] [*Start Date*] [*End   Date*] [Room ] [***********Name**********] [*****Payment Confirmation*****] [Has Coupon] [Paid Amount]");
                foreach ((Guid guid, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid) in LogicClass.reservationList)
                {
                    Console.WriteLine($"[ {guid,-30}] [{startDate,12}] [{endDate,12}] [{roomNumber,5}] [{customerName,25}] [{paymentConfirmation,30}] [{hasCoupon,10}] [{amountPaid,11}]");
                }
                PressToContinue();
                recentMessage = "";
                break;
            }
            else if (userChoice == 3)
            {
                Console.Clear();
                Console.WriteLine("***  Reservation Management  *** Reservation Report by Customer Name *** \n ");
                string customer = getString("Please enter the name of customer: ");
                if (!LogicClass.CustomerAlreadyAvailable(customer))
                {
                    Console.Write($"The user {customer} doesn't exist. ");
                    PressToContinue();
                    recentMessage = $"\nMessage: The customer with the name {customer} not found. \n";
                    break;
                }
                Console.WriteLine($"\nReservation details for {customer} (Future and Current Reservation Only) \n\n[S.N] [*********Reservation Number**********] [*Start Date*] [*End   Date*] [Room ] [***********Name**********] [*****Payment Confirmation*****] [Has Coupon] [Paid Amount]\n");
                int no_of_results = 0;
                var dateNow = DateOnly.FromDateTime(DateTime.Now);
                foreach ((Guid guid, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid) in LogicClass.reservationList)
                {
                    if (customerName.ToLower().Trim() == customer.ToLower().Trim() && dateNow < endDate)
                    {
                        no_of_results++;
                        Console.WriteLine($"[ {no_of_results} ] [ {guid,-30}] [{startDate,12}] [{endDate,12}] [{roomNumber,5}] [{customerName,25}] [{paymentConfirmation,30}] [{hasCoupon,10}] [{amountPaid,11}]");

                    }
                }
                if (no_of_results == 0)
                {
                    Console.WriteLine($"\nUser {customer} has not made any reservations yet . ");
                }
                else
                {
                    Console.WriteLine($"\nTotal {no_of_results} reservations found for {customer}. ");
                }
                PressToContinue();
                recentMessage = "";
                break;
            }
            else if (userChoice == 4)
            {
                reservationReportByDateUI();
                break;
            }
            else if (userChoice == 5)
            {
                availableRoomSearchByDateUI();
                break;
            }
            else if (userChoice == 6)
            {
                Console.Clear();
                Console.WriteLine("***  Reservation Management  *** Refund a Reservation*** \n ");
                string reservationNo = getString("Please Copy and Paste the Reservation Number(GUID) here(right click to paste): ").Trim();
                Guid reservationNoGuid;
                bool isValid = Guid.TryParse(reservationNo, out reservationNoGuid);
                if (!isValid || !LogicClass.isValidReservation(reservationNoGuid))
                {
                    Console.WriteLine($"The reservation with that Reservation Number doesn't exist. Please try copying and pasting again. ");
                    PressToContinue();
                    Console.WriteLine();
                    recentMessage = "\nMessage: Couldn't Find the reservation for the refund\n";
                    break;
                }
                var reservationDetails = LogicClass.getReservationDetails(reservationNoGuid);
                Console.WriteLine($"Warning! You're about to refund ${reservationDetails.amountPaid} for {reservationDetails.customerName}. \nHere are the details about the refund: \nRoom Number -> {reservationDetails.roomNumber}, Start Date -> {reservationDetails.startDate}, End Date -> {reservationDetails.endDate}");
                string typedInput = getString("\nType 'X' to cancel or any other key to Proceed: ");
                if (typedInput.Trim().ToLower() == "x")
                {
                    recentMessage = "\nMessage: Refund Request Cancelled!\n";
                    break;
                }
                LogicClass.addToReFundsList((reservationDetails.Item1, reservationDetails.Item2, reservationDetails.Item3, reservationDetails.Item4, reservationDetails.Item5, reservationDetails.Item6, reservationDetails.Item7, reservationDetails.Item8, DateOnly.FromDateTime(DateTime.Now)));
                LogicClass.removeFromReservation(reservationNoGuid);


                Console.Write($"Refund Successful for {reservationDetails.customerName}. ");
                PressToContinue();
                Console.WriteLine();
                recentMessage = "\nMessage: Refund Request executed Successfully. \n";
                break;
            }
            else if (userChoice == 7)
            {
                break;
            }
        }
        if (userChoice == 7)
        {
            LogicClass.saveAllToFiles();
            recentMessage = "\nMessage: All the recent changes were saved successfully in files.\n";
            break;
        }

    }
}
void promotionsAndReportsUI()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"*****  Main Menu  ******* Promotions and Reports ************ \n{recentMessage} Here's you navigation menu: \n 1. View Available Coupon Codes \n 2. Add a new Coupon Code \n 3. Delete Coupon Code \n 4. View Coupon Codes Reports \n 5. Utilization Report for a day \n 6.  Utilization Report for a date range \n 7. Save changes and exit to main menu ");
        userChoice = getInt(1, 7, "Choose any number from 1 to 7: ");
        while (true)
        {
            if (userChoice == 1)
            {
                viewAvailableCouponUI();
                break;
            }
            else if (userChoice == 2)
            {
                PressToContinue("Feature Coming soon. Press any key to continue: ");
                break;
            }

            else if (userChoice == 3)
            {
                PressToContinue("Feature Coming soon. Press any key to continue: ");
                break;
            }

            else if (userChoice == 4)
            {
                viewCouponCodesReportUI();
                break;
            }

            else if (userChoice == 5)
            {
                //5. Utilization Report for a day
                utilizationReportForADayUI();
                break;
            }
            else if (userChoice == 6)
            {
                utilizationReportForDateRangeUI();
                break;
            }
            else if (userChoice == 7)
            {
                break;
            }
        }
        if (userChoice == 7)
        {
            LogicClass.saveAllToFiles();
            recentMessage = "\nMessage: All the recent changes were saved successfully in files.\n";
            break;
        }

    }
}
void addNewCustomerUI()
{
    Console.Clear();
    Console.WriteLine("*** Customer Management *** Add New Customer  *** \n Please enter the customer details below or Press X to exit.: ");
    string name = "";
    while (true)
    {
        name = getString("Please, Enter the name of your customer: ");
        if (name != "X" && name != "x")
        {
            if (!LogicClass.CustomerAlreadyAvailable(name))
            {
                break;
            }
            Console.WriteLine($"The customer with the same name '{name}' already exists.");
            PressToContinue();
            Console.WriteLine();
            recentMessage = "\nMessage: Couldn't add new customer\n";
            break;
        }
        break;
    }
    if (!LogicClass.CustomerAlreadyAvailable(name) && name != "X" && name != "x")
    {
        long cardNumber = getLong(Prompt: "Please, Enter the card Number: ");
        LogicClass.addToCustomers((name, cardNumber, false));
    }
    recentMessage = "\nMessage: New customer Successfully Added\n";
}


void customersDetailsUI()
{
    Console.Clear();
    Console.WriteLine("*** Customer Management *** Customer Details  *** \n[*************Name**************] [**********Card Number*********] [Is Frequent Traveler?]");
    foreach ((string name, long id, bool isFreqTraveler) in LogicClass.customersList)
    {
        Console.WriteLine($"[ {name,-30}] [{id,30}] [{isFreqTraveler,21}]");
    }
    PressToContinue();
    recentMessage = "";

}
void removeACustomerUI()
{
    Console.Clear();
    Console.WriteLine("*** Customer Management *** Remove a Customer  *** \nPlease enter the customer details below or Press X to exit.: ");
    string name = "";
    while (true)
    {

        name = getString("Please, Enter the name of your customer: ");
        if (name != "X" && name != "x")
        {
            if (LogicClass.CustomerAlreadyAvailable(name))
            {
                Console.Write($"Warning! You're about to delete the customer \"{name}\" from database. \nPress 'Y' to Proceed or any other Key to return back: ");
                string input = Console.ReadLine();
                if (input == "Y" || input == "y")
                {
                    LogicClass.removeFromCustomers(name);

                }
                recentMessage = "\nMessage: The customer was deleted successfully.\n";
                break;
            }
            else
            {
                Console.WriteLine($"The customer with the name {name} doesn't exist. Please recheck and enter again.");
                recentMessage = "\nMessage: Couldn't delete the customer.\n";
            }
        }
        else
        {
            break;
        }
    }
}
string priorReservationForCustomerUITop()
{
    Console.Clear();
    Console.WriteLine("***  Customer Management  *** Prior Reservation for Customers *** \n ");
    string customer = getString("Please enter the name of customer: ");
    return customer;

}
void priorReservationForCustomerUI(string customer)
{

    Console.WriteLine($"\nReservation details for {customer} (Past Reservation Only) \n\n[S.N] [*********Reservation Number**********] [*Start Date*] [*End   Date*] [Room ] [***********Name**********] [*****Payment Confirmation*****] [Has Coupon] [Paid Amount]\n");
    int no_of_results = 0;
    var dateNow = DateOnly.FromDateTime(DateTime.Now);
    foreach ((Guid guid, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid) in LogicClass.reservationList)
    {
        if (customerName.ToLower().Trim() == customer.ToLower().Trim() && dateNow > endDate)
        {
            no_of_results++;
            Console.WriteLine($"[ {no_of_results} ] [ {guid,-30}] [{startDate,12}] [{endDate,12}] [{roomNumber,5}] [{customerName,25}] [{paymentConfirmation,30}] [{hasCoupon,10}] [{amountPaid,11}]");

        }
    }
    if (no_of_results == 0)
    {
        Console.WriteLine($"\nUser {customer} has not made any reservations yet . ");
    }
    else
    {
        Console.WriteLine($"\nTotal {no_of_results} reservations found for {customer}. ");
    }
    PressToContinue();
    recentMessage = "";
}
void addANewRoomUI()
{
    Console.Clear();
    Console.WriteLine("*** Room Management *** Add New Room  *** \n Please enter the room details below: ");
    int roomNum;
    while (true)
    {
        roomNum = getInt(Prompt: "Please, Enter the new room number: ");

        if (!LogicClass.RoomAvailableToCreate(roomNum))
        {
            Console.WriteLine($"The room with the same number '{roomNum}' already exists.");
            PressToContinue();
            Console.WriteLine();
            recentMessage = "\nMessage: Couldn't add new room.\n";
            break;
        }
        DataClass.RoomType roomType;
        while (true)
        {
            string input = getString("Please enter the room type: ");
            if (int.TryParse(input, out int tempVar))
            {
                continue;
            }
            if (Enum.TryParse(input, out roomType))
            {
                break;
            }
        }

        LogicClass.addToRoom((roomNum, roomType));
        recentMessage = "\nMessage: New Room Successfully added.\n";
        break;

    }
}
void changeRoomPriceUI()
{
    bool isTrue = false;
    int count = 0;
    DataClass.RoomType roomTypeValue = new();
    while (!isTrue)
    {
        string prompt = "Enter the room type that you want to change the price of: ";
        if (count > 0)
        {
            prompt = "Please Enter the valid room type : ";
        }
        string input = getString(prompt);
        if (int.TryParse(input, out int tempVal))
        {
            count++;
            continue;
        }
        isTrue = Enum.TryParse(input, out roomTypeValue);
        count++;
    }
    decimal currentPrice = LogicClass.getRoomPrice(roomTypeValue);

    Console.WriteLine($"The current price for the room type '{roomTypeValue}' is {currentPrice}");
    decimal getRoomPrice = getDecimal(Prompt: "Enter the New Price for your room type. ");

    decimal currrentCleaningPrice = LogicClass.getRoomCleaningPrice(roomTypeValue);
    Console.WriteLine($"The current cleaning price for the room type '{roomTypeValue}' is {currrentCleaningPrice}");
    decimal getCleaningPrice = getDecimal(Prompt: "Enter the New Cleaning Price for your room type. ");
    LogicClass.updateTheRoomPrice(roomTypeValue, getRoomPrice, getCleaningPrice);

    recentMessage = "\nMessage: The Price was updated.\n";
}
void addNewReservationUI()
{
    Console.Clear();
    Console.WriteLine("*** Reservation Management *** Add New Reservation  *** \n ");
    int roomNum;
    DateOnly startDate;
    DateOnly endDate;
    while (true)
    {
        roomNum = getInt(Prompt: "Please, Enter the room number that you want to book: ");
        if (LogicClass.RoomAvailableToCreate(roomNum))
        {
            Console.Write("The room number that you entered doesn't exist. Please create one to proceed booking. ");
            PressToContinue();
            recentMessage = "\nMessage: Booking can't proceed. Please make a new room. \n";
            break;
        }
        startDate = getDate("Please, Enter the starting date: ");
        endDate = getDate("Please, Enter the ending date: ");
        if (endDate < startDate)
        {
            Console.Write("Invalid Input of the date.");
            PressToContinue();
            continue;
        }
        if (!LogicClass.RoomIsAvailable(startDate, endDate, roomNum))
        {
            Console.WriteLine($"The room '{roomNum}' is already booked on between '{startDate}'-'{endDate}'.");
            PressToContinue();
            recentMessage = "\nMessage: Couldn't make the new reservation.\n";
            break;
        }
        string customerName = getString("Please enter the customer name: ");
        if (!LogicClass.CustomerAlreadyAvailable(customerName))
        {
            Console.Write("The user doesn't exist. Please create one to proceed booking. ");
            PressToContinue();
            recentMessage = "\nMessage: Booking can't proceed. Please make a new user. \n";
            break;
        }


        bool hasCoupon;
        decimal amountPaid;
        int noOfDays = LogicClass.GetDaysBetweenDates(startDate, endDate);
        int count = 0;
        string couponCode;
        double couponDiscountPer = 0;
        double frequentTravelerDiscountPer = 0;
        Guid reservationNumber = Guid.NewGuid();
        while (true)
        {
            string prompt = "Please enter Coupon Code if You have or enter X to skip: ";
            if (count > 0)
            {
                prompt = "The coupon was invalid. Please try again or enter X to skip: ";
            }
            couponCode = getString(prompt);
            couponCode = couponCode.Trim().ToUpper();
            if (couponCode == "X")
            {
                hasCoupon = false;
                break;
            }
            else
            {
                if (LogicClass.isValidCoupon(couponCode))
                {
                    hasCoupon = true;
                    break;
                }
                count++;
            }
        }
        if (hasCoupon)
        {
            couponDiscountPer = LogicClass.getCouponDiscountPercent(couponCode);
        }
        if (LogicClass.isFrequentTraveler(customerName))
        {
            frequentTravelerDiscountPer = 12; //Making it manual(12%) upto this point
        }
        string output = " ";
        var finalPrice = LogicClass.calculatePriceBeforeCheckout(LogicClass.getRoomPrice(LogicClass.getRoomType(roomNum)), noOfDays, couponDiscountPer, frequentTravelerDiscountPer);
        amountPaid = finalPrice.Item1;
        if (finalPrice.Item2 > 0 || finalPrice.Item2 > 0)
        {
            Console.WriteLine("\nWoW! You Got Some Discounts");
            output = "Your Total Saving: ";
            if (finalPrice.Item2 > 0)
            {
                output += $"Frequent Traveler Discount({frequentTravelerDiscountPer}%) : $";
                output += finalPrice.Item2;
                output += "\n";
            }
            if (finalPrice.Item3 > 0)
            {
                output += $"Coupon Discount for '{couponCode}' ({couponDiscountPer}%): $";
                output += finalPrice.Item3;
                output += "\n";

            }
            output += $"Total = ${LogicClass.getRoomPrice(LogicClass.getRoomType(roomNum))} * {noOfDays} days - ${finalPrice.Item3 + finalPrice.Item2} = ${amountPaid}";


        }
        else
        {
            output += $"Total = ${LogicClass.getRoomPrice(LogicClass.getRoomType(roomNum))} * {noOfDays}= {amountPaid}";
        }
        if (couponDiscountPer > 0)
        {
            LogicClass.couponRedemptionsList.Add((reservationNumber, couponCode.ToUpper().Trim(), couponDiscountPer));

        }
        Console.WriteLine(output);

        LogicClass.addToReservationList((reservationNumber, startDate, endDate, roomNum, customerName, LogicClass.GenerateRandomString(30), hasCoupon, amountPaid));
        PressToContinue();
        recentMessage = $"\nMessage: New Reservation for {customerName} Successfully added.\n";
        break;

    }
}
void reservationReportByDateUI()
{
    Console.Clear();
    Console.WriteLine("***  Reservation Management  *** Reservation Report by Date  *** \n ");
    DateOnly checkingDate = getDate("Please enter the date to check the report: ");

    Console.WriteLine($"\nReservation details for the date {checkingDate} \n\n(P.S. Th end date doesn't count as it's free to book on end date.)\n[S.N] [*********Reservation Number**********] [*Start Date*] [*End   Date*] [Room ] [***********Name**********] [*****Payment Confirmation*****] \n");
    int no_of_results = 0;
    foreach ((Guid guid, DateOnly startDate, DateOnly endDate, int roomNumber, string customerName, string paymentConfirmation, bool hasCoupon, decimal amountPaid) in LogicClass.reservationList)
    {
        if (checkingDate >= startDate && checkingDate < endDate)
        {
            no_of_results++;
            Console.WriteLine($"[ {no_of_results} ] [ {guid,-30}] [{startDate,12}] [{endDate,12}] [{roomNumber,5}] [{customerName,25}] [{paymentConfirmation,30}] [{hasCoupon,10}] [{amountPaid,11}]");

        }
    }
    if (no_of_results == 0)
    {
        Console.WriteLine($"Sorry! No reservations found on given date - '{checkingDate}' . ");
    }
    else
    {
        Console.WriteLine($"\nTotal {no_of_results} reservations found on given date - '{checkingDate}' . ");
    }
    PressToContinue();
    recentMessage = "";
}
void availableRoomSearchByDateUI()
{
    Console.Clear();
    Console.WriteLine("***  Reservation Management  *** Available Room Search by Date  *** \n ");
    DateOnly checkingDate = getDate("Please enter the date to search: ");
    var availableRoomLists = LogicClass.availableRoomsListByDate(checkingDate);
    if (availableRoomLists.Count == 0)
    {
        Console.WriteLine($"Sorry! No any rooms available to book for the day '{checkingDate}'. ");
    }
    else
    {
        Console.WriteLine($"\nHere's the list of available rooms to book for the day '{checkingDate}'. \n");
        Console.WriteLine($"[Room No.] [Room Type]");
        foreach (var item in availableRoomLists)
        {
            Console.WriteLine($"[{item.Item1,8}] [{item.Item2,9}]");
        }
        Console.WriteLine($"\n{availableRoomLists.Count} numbers of rooms are available.");
    }
    PressToContinue();
    recentMessage = "";
}

void viewAvailableCouponUI()
{
    Console.Clear();
    Console.WriteLine("***  Promotions and Reports *** View Available Coupon Codes *** \n ");

    Console.WriteLine($"Here is the List of available Coupon Codes: ");
    Console.WriteLine($"Use them to do some saving. We love you. \n");
    Console.WriteLine($"[Coupon Code] [Discount%]");

    foreach (var item in LogicClass.couponsList)
    {

        Console.WriteLine($"[{item.Key,-11}] [{item.Value,9}]");
    }


    PressToContinue();
    recentMessage = $"\n";
}
void viewCouponCodesReportUI()
{
    Console.Clear();
    Console.WriteLine("***  Promotions and Reports *** View Coupon Codes Reports *** \n ");
    Console.WriteLine($"Total no. of Coupons used by customer till now: {LogicClass.couponRedemptionsList.Count}\n");
    var uniqueCoupons = LogicClass.getUniqueCouponList();
    string text = "";
    for (int i = 0; i < uniqueCoupons.Count; i++)
    {
        text += $"{uniqueCoupons[i]}, ";
    }
    Console.WriteLine($"Total Unique no. of Coupons used by customer till now: {uniqueCoupons.Count} and the coupon codes are {text}\n");

    Console.WriteLine($"Here is the report of Coupon Uses: ");
    Console.WriteLine($"[Coupon Used] [***********Name**********] [Discount%] [*********Reservation Number*********]");

    for (int i = 0; i < LogicClass.couponRedemptionsList.Count; i++)
    {
        var item = LogicClass.couponRedemptionsList[i];
        var reservationDetails = LogicClass.getReservationDetails(item.reservationNumber);
        Console.WriteLine($"[{item.couponCode,11}] [{reservationDetails.customerName,25}] [{item.discountPercentage,9}] [{item.reservationNumber,-30}]");
    }


    PressToContinue();
    recentMessage = $"\n";
}
void utilizationReportForADayUI()
{
    Console.Clear();
    Console.WriteLine("***  Promotions and Reports *** View Utilization Reports For a day*** \n ");
    DateOnly inputDate = getDate("Please Enter the date that you want to check for: ");
    Console.WriteLine($"Here's the List of Already Booked Rooms For the day '{inputDate}' ");
    Console.WriteLine($"[Room Number] -> [Room Type]");
    decimal rental = 0;
    for (int i = 0; i < LogicClass.unavailableRoomsListByDate(inputDate).Count; i++)
    {
        var item = LogicClass.unavailableRoomsListByDate(inputDate)[i];

        Console.WriteLine($"[{item.Item1,-11}] -> [{item.Item2,-9}] ");
        var theReservation = LogicClass.getReservationDetails(LogicClass.GetReservationNumberByDateAndRoom(inputDate, item.Item1));
        rental += theReservation.amountPaid / ((decimal)(theReservation.endDate.DayNumber - theReservation.startDate.DayNumber));
    }

    Console.WriteLine($"\n\nHere's the List of Available Rooms For the day '{inputDate}' ");
    Console.WriteLine($"[Room Number] -> [Room Type]");
    foreach (var item in LogicClass.availableRoomsListByDate(inputDate))
    {
        Console.WriteLine($"[{item.Item1,-11}] -> [{item.Item2,-9}] ");
    }

    Console.WriteLine($"\n\nThe total rental earning for {LogicClass.unavailableRoomsListByDate(inputDate).Count} no. of rooms for today is ${rental}.");

    double occupancyRate = (Double)LogicClass.unavailableRoomsListByDate(inputDate).Count / (Double)LogicClass.roomList.Count;
    occupancyRate = occupancyRate * 100;
    Console.WriteLine($"\nThe occupancy rate for today is {occupancyRate}%.");

    PressToContinue();
    recentMessage = $"\n";
}
void utilizationReportForDateRangeUI()
{
    Console.Clear();
    Console.WriteLine("***  Promotions and Reports *** View Utilization Reports For a Date Range *** \n ");

    DateOnly startDate = getDate("Please Enter the start date: ");
    DateOnly endDate = getDate("Please Enter the end date: ");

    decimal totalRental = 0;
    int totalBookedRooms = 0;

    // Iterate over each day in the date range
    for (DateOnly currentDate = startDate; currentDate < endDate; currentDate = currentDate.AddDays(1))
    {
        Console.WriteLine($"Utilization Report for {currentDate}:");

        Console.WriteLine($"Here's the List of Already Booked Rooms For the day '{currentDate}' ");
        Console.WriteLine($"[Room Number] -> [Room Type]");
        decimal dailyRental = 0;

        foreach (var item in LogicClass.unavailableRoomsListByDate(currentDate))
        {
            Console.WriteLine($"[{item.Item1,-11}] -> [{item.Item2,-9}] ");
            var theReservation = LogicClass.getReservationDetails(LogicClass.GetReservationNumberByDateAndRoom(currentDate, item.Item1));
            dailyRental += theReservation.amountPaid / ((decimal)(theReservation.endDate.DayNumber - theReservation.startDate.DayNumber));
        }

        totalRental += dailyRental;
        totalBookedRooms += LogicClass.unavailableRoomsListByDate(currentDate).Count;

        Console.WriteLine($"\n\nHere's the List of Available Rooms For the day '{currentDate}' ");
        Console.WriteLine($"[Room Number] -> [Room Type]");
        foreach (var item in LogicClass.availableRoomsListByDate(currentDate))
        {
            Console.WriteLine($"[{item.Item1,-11}] -> [{item.Item2,-9}] ");
        }

        Console.WriteLine($"\n\nThe total rental earning for {LogicClass.unavailableRoomsListByDate(currentDate).Count} no. of rooms for today is ${dailyRental}.");

        double occupancyRate = (Double)LogicClass.unavailableRoomsListByDate(currentDate).Count / (Double)LogicClass.roomList.Count;
        occupancyRate = occupancyRate * 100;
        Console.WriteLine($"\nThe occupancy rate for today is {occupancyRate}%.\n");
    }

    Console.WriteLine($"\n\nThe total rental earning for the date range is ${totalRental}.");

    double overallOccupancyRate = (Double)totalBookedRooms / (Double)LogicClass.roomList.Count;
    overallOccupancyRate = overallOccupancyRate * 100;
    Console.WriteLine($"\nThe overall occupancy rate for the date range is {overallOccupancyRate}%.");

    PressToContinue();
    recentMessage = $"\n";
}


