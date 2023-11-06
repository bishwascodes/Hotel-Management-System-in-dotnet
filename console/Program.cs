// CS1400 - Fall 2023 - Bishwas Thapa

string roomsFile = "..\\Rooms.txt";
string reservationsFile = "..\\Reservations.txt";
string customersFile = "..\\Customers.txt";
string roomPricesFile = "..\\RoomPrices.txt";

List<(int roomNumber, RoomType type)> roomList = ReadRoomFile(roomsFile);
List<(Guid reservationNumber, DateTime date, int roomNumber, string customerName, string paymentConfirmation)> reservationList = ReadReservationsFile(reservationsFile);
List<(string customerName, long cardNumber)> customersList = ReadCustomersFile(customersFile);
List<(RoomType roomType, decimal dailyRate)> roomPrices = ReadRoomPricesFile(roomPricesFile);

// Adding items to each list 
roomList.Add((105, RoomType.Suite));
reservationList.Add((Guid.NewGuid(), DateTime.Now, 101, "Kafumba Turey", GenerateRandomString(30)));
customersList.Add(("Kafumba Turey", 1234567891254687));
roomPrices.Add((RoomType.Single, 250.00M));

roomList.Add((105, RoomType.Suite));
reservationList.Add((Guid.NewGuid(), DateTime.Now, 101, "Randy Ortan", GenerateRandomString(30)));
customersList.Add(("Randy Ortan", 1234567890123456));
roomPrices.Add((RoomType.Double, 200.00M));

roomList.Add((105, RoomType.Suite));
reservationList.Add((Guid.NewGuid(), DateTime.Now, 101, "Micheal Johnesn", GenerateRandomString(30)));
customersList.Add(("Micheal Johnesn", 1234567890123456));


roomList.Add((105, RoomType.Suite));
reservationList.Add((Guid.NewGuid(), DateTime.Now, 101, "Peter Malan", GenerateRandomString(30)));
customersList.Add(("Peter Malan", 1234567890123456));


// Updating to the original file
UpdateRoomFile(roomsFile, roomList);
UpdateReservationsFile(reservationsFile, reservationList);
UpdateCustomersFile(customersFile, customersList);
UpdateRoomPricesFile(roomPricesFile, roomPrices);

List<(int roomNumber, RoomType type)> ReadRoomFile(string filePath)
{
    List<(int roomNumber, RoomType type)> roomList = new List<(int roomNumber, RoomType type)>();

    if (File.Exists(filePath))
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

    return roomList;
}

List<(Guid reservationNumber, DateTime date, int roomNumber, string customerName, string paymentConfirmation)> ReadReservationsFile(string filePath)
{
    List<(Guid reservationNumber, DateTime date, int roomNumber, string customerName, string paymentConfirmation)> reservationList = new List<(Guid reservationNumber, DateTime date, int roomNumber, string customerName, string paymentConfirmation)>();

    if (File.Exists(filePath))
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 5 && Guid.TryParse(parts[0], out Guid reservationNumber) && DateTime.TryParse(parts[1], out DateTime date) &&
                int.TryParse(parts[2], out int roomNumber) && !string.IsNullOrEmpty(parts[3]) && !string.IsNullOrEmpty(parts[4]))
            {
                reservationList.Add((reservationNumber, date, roomNumber, parts[3], parts[4]));
            }
        }
    }

    return reservationList;
}

List<(string customerName, long cardNumber)> ReadCustomersFile(string filePath)
{
    List<(string customerName, long cardNumber)> customersList = new List<(string customerName, long cardNumber)>();

    if (File.Exists(filePath))
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2 && !string.IsNullOrEmpty(parts[0]) && long.TryParse(parts[1], out long cardNumber))
            {
                customersList.Add((parts[0], cardNumber));
            }
        }
    }

    return customersList;
}

List<(RoomType roomType, decimal dailyRate)> ReadRoomPricesFile(string filePath)
{
    List<(RoomType roomType, decimal dailyRate)> roomPrices = new List<(RoomType roomType, decimal dailyRate)>();

    if (File.Exists(filePath))
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2 && Enum.TryParse(parts[0], out RoomType roomType) && decimal.TryParse(parts[1], out decimal dailyRate))
            {
                roomPrices.Add((roomType, dailyRate));
            }
        }
    }

    return roomPrices;
}


void UpdateRoomFile(string filePath, List<(int roomNumber, RoomType type)> roomList)
{
    List<string> lines = new List<string>();

    foreach (var room in roomList)
    {
        string line = $"{room.roomNumber},{room.type}";
        lines.Add(line);
    }
    File.WriteAllLines(filePath, lines);
}

void UpdateReservationsFile(string filePath, List<(Guid reservationNumber, DateTime date, int roomNumber, string customerName, string paymentConfirmation)> reservationList)
{
    List<string> lines = new List<string>();
    foreach (var reservation in reservationList)
    {
        string line = $"{reservation.reservationNumber},{reservation.date},{reservation.roomNumber},{reservation.customerName},{reservation.paymentConfirmation}";
        lines.Add(line);
    }
    File.WriteAllLines(filePath, lines);
}

void UpdateCustomersFile(string filePath, List<(string customerName, long cardNumber)> customersList)
{
    List<string> lines = new List<string>();
    foreach (var customer in customersList)
    {
        string line = $"{customer.customerName},{customer.cardNumber}";
        lines.Add(line);
    }
    File.WriteAllLines(filePath, lines);
}

void UpdateRoomPricesFile(string filePath, List<(RoomType roomType, decimal dailyRate)> roomPrices)
{
    List<string> lines = new List<string>();
    foreach (var price in roomPrices)
    {
        string line = $"{price.roomType},{price.dailyRate}";
        lines.Add(line);
    }
    File.WriteAllLines(filePath, lines);
}


string GenerateRandomString(int length)
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

enum RoomType { Single, Double, Suite }