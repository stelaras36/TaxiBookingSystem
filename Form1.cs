using System.Text.RegularExpressions;
namespace Taxisystem

{

    public partial class Form1 : Form
    {
        private bool isLoggedIn = false;  // �������� ��� ��������� isLoggedIn
        private List<Taxi> taxis = new List<Taxi>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ����� �� �������� ��� ��� ������� ���� �� login
            // ����� �� �������� ��� ��� ������� ���� �� login
            txtPickup.Visible = false;
            lblDestination.Visible = false;
            btnBook.Visible = false;
            lblPickup.Visible = false;
            label3.Visible = false;

            // ��������� 5 ��������� ����
            for (int i = 1; i <= 5; i++)
            {
                taxis.Add(new Taxi(i));
            }

            this.BackColor = Color.LightYellow; // ����� ������ ������

            btnLogin.BackColor = Color.DeepSkyBlue;
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            btnBook.BackColor = Color.MediumSeaGreen;
            btnBook.ForeColor = Color.White;
            btnBook.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            lblEmail.ForeColor = Color.DarkBlue;
            lblPickup.ForeColor = Color.DarkGreen;
            label3.ForeColor = Color.DarkGreen;

            txtEmail.BackColor = Color.WhiteSmoke;
            txtPickup.BackColor = Color.WhiteSmoke;
            lblDestination.BackColor = Color.WhiteSmoke;

            this.BackgroundImage = Image.FromFile("stelaras.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            // Regex ��� ��������� ��� email ��� ������ ������ 
            string pattern = @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            // ������� �� �� email ����� ������
            if (string.IsNullOrEmpty(email) || !regex.IsMatch(email))
            {
                MessageBox.Show("�������� �������� ��� ������ email.");
            }
            else
            {
                // �������� login
                MessageBox.Show("������������, " + email);

                // ����� �� ����� email ��� �� ������ login
                txtEmail.Visible = false;
                lblEmail.Visible = false;  
                btnLogin.Visible = false;
                // �������� �� ����� ��������
                txtPickup.Visible = true;
                lblDestination.Visible = true;
                btnBook.Visible = true;
                lblPickup.Visible = true;
                label3.Visible = true;

                // ���� �� isLoggedIn = true
                isLoggedIn = true;
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("������ ����� �� ������ login ��� �� ������ �������.");
                return; // ������������ ��� ��� ����������� ��� �������
            }

            string pickup = txtPickup.Text;
            string destination = lblDestination.Text;

            // Regex ��� ��������� (����, �������, ����, ��)
            string pattern = @"^[a-zA-Z0-9\s,�-�]+(?:\s\d{1,5})?,\s[a-zA-Z0-9\s�-�]+(?:\s\d{1,5})?,\s\d{5}$";
            Regex regex = new Regex(pattern);

            // ������� �� �� ����� ����� ���� � �� ��� ������� �� regex
            if (string.IsNullOrEmpty(pickup) || string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("�������� �������� ��� ��� ��� �����������.");
            }
            else if (!regex.IsMatch(pickup) || !regex.IsMatch(destination))
            {
                MessageBox.Show("� ��������� ��� � ���������� ������ �� �������������: ���, ������, ���� ��� ����������� ������ (�.�., '���� ��������� 15, �����, 12345').");
            }
            else if (pickup.Trim().Equals(destination.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("� ��������� ��������� ��� � ���������� ��� ������� �� ����� ����.");
            }
            else
            {
                // ��� ������ � �������
                Taxi? availableTaxi = taxis.FirstOrDefault(t => t.IsAvailable); //Taxi? ������ ������ ������������� ��� null ��� ��� ������ ���

                if (availableTaxi != null)
                {
                    availableTaxi.IsAvailable = false;

                    MessageBox.Show($"� ������� ��� �����!\n��������: {pickup}\n����������: {destination}\n������� ����: {availableTaxi.TaxiId}");

                    SaveBookingToFile(pickup, destination, availableTaxi.TaxiId);
                }
                else
                {
                    MessageBox.Show("��������, ��� �������� ��������� ���� ���� �� ������.");
                }
            }
        }
        private void SaveBookingToFile(string pickup, string destination, int taxiId)
        {
            string path = "bookings.txt";
            string bookingInfo = $"Taxi {taxiId}: ��� {pickup} ���� {destination} - {DateTime.Now}";

            using (StreamWriter writer = new StreamWriter(path, true)) // true = �������� (append)
            {
                writer.WriteLine(bookingInfo);
            }
        }
    }
    public class Taxi
    {
        public int TaxiId { get; set; }
        public bool IsAvailable { get; set; }

        public Taxi(int taxiId)
        {
            TaxiId = taxiId;
            IsAvailable = true; // ��� �������� ���������
        }
    }
}
