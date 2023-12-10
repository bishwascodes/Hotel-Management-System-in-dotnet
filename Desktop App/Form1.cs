using Hotel.Logic;

namespace Desktop_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogicClass.GetDataFromFiles();
        }

        private void getAvailableRoomsBtn_Click(object sender, EventArgs e)
        {
            string DisplayValue = "";


            DateOnly checkingDate = DateOnly.FromDateTime(ourDate.Value);
            var availableRoomLists = LogicClass.availableRoomsListByDate(checkingDate);
            if (availableRoomLists.Count == 0)
            {
                DisplayValue += $"Sorry! No any rooms available to book for the day '{checkingDate}'. ";
                DisplayValue += Environment.NewLine;
            }
            else
            {
                DisplayValue += $"Here's the list of available rooms to book for the day '{checkingDate}'. ";
                DisplayValue += Environment.NewLine;
                DisplayValue += Environment.NewLine;
                DisplayValue += $"[Room No.] [Room Type]";
                DisplayValue += Environment.NewLine;
                foreach (var item in availableRoomLists)
                {
                    DisplayValue += $"[{item.Item1,15}] [{item.Item2,15}]";
                    DisplayValue += Environment.NewLine;
                }
                DisplayValue += $"\n{availableRoomLists.Count} numbers of rooms are available.";
            }
            outputBox1.Text = DisplayValue;
        }
    }
}