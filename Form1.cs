using System.Text.RegularExpressions;
namespace Taxisystem

{

    public partial class Form1 : Form
    {
        private bool isLoggedIn = false;  // Προσθέτω την μεταβλητή isLoggedIn
        private List<Taxi> taxis = new List<Taxi>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Κρύβω τα στοιχεία για την κράτηση πριν το login
            // Κρύβω τα στοιχεία για την κράτηση πριν το login
            txtPickup.Visible = false;
            lblDestination.Visible = false;
            btnBook.Visible = false;
            lblPickup.Visible = false;
            label3.Visible = false;

            // Δημιουργώ 5 διαθέσιμα ταξί
            for (int i = 1; i <= 5; i++)
            {
                taxis.Add(new Taxi(i));
            }

            this.BackColor = Color.LightYellow; // Χρώμα φόντου φόρμας

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

            // Regex για επικύρωση του email για έλεγχο μορφής 
            string pattern = @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            // Έλεγχος αν το email είναι έγκυρο
            if (string.IsNullOrEmpty(email) || !regex.IsMatch(email))
            {
                MessageBox.Show("Παρακαλώ εισάγετε ένα έγκυρο email.");
            }
            else
            {
                // Επιτυχής login
                MessageBox.Show("Καλωσορίσατε, " + email);

                // Κρύβω το πεδίο email και το κουμπί login
                txtEmail.Visible = false;
                lblEmail.Visible = false;  
                btnLogin.Visible = false;
                // Εμφανίζω τα πεδία κράτησης
                txtPickup.Visible = true;
                lblDestination.Visible = true;
                btnBook.Visible = true;
                lblPickup.Visible = true;
                label3.Visible = true;

                // Θέτω το isLoggedIn = true
                isLoggedIn = true;
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("Πρέπει πρώτα να κάνετε login για να κάνετε κράτηση.");
                return; // Επιστρέφουμε και δεν επιτρέπουμε την κράτηση
            }

            string pickup = txtPickup.Text;
            string destination = lblDestination.Text;

            // Regex για διεύθυνση (Οδός, αριθμός, πόλη, ΤΚ)
            string pattern = @"^[a-zA-Z0-9\s,Ά-ώ]+(?:\s\d{1,5})?,\s[a-zA-Z0-9\sΆ-ώ]+(?:\s\d{1,5})?,\s\d{5}$";
            Regex regex = new Regex(pattern);

            // Έλεγχος αν τα πεδία είναι κενά ή αν δεν πληρούν το regex
            if (string.IsNullOrEmpty(pickup) || string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("Παρακαλώ εισάγετε και τις δύο διευθύνσεις.");
            }
            else if (!regex.IsMatch(pickup) || !regex.IsMatch(destination))
            {
                MessageBox.Show("Η διεύθυνση και ο προορισμός πρέπει να περιλαμβάνουν: οδό, αριθμό, πόλη και ταχυδρομικό κώδικα (π.χ., 'Οδός Σωκράτους 15, Αθήνα, 12345').");
            }
            else if (pickup.Trim().Equals(destination.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Η διεύθυνση παραλαβής και ο προορισμός δεν μπορούν να είναι ίδια.");
            }
            else
            {
                // Εδώ ξεκινά η κράτηση
                Taxi? availableTaxi = taxis.FirstOrDefault(t => t.IsAvailable); //Taxi? επειδή έβγαζε προειδοποίηση για null ενώ έχω έλεγχο ήδη

                if (availableTaxi != null)
                {
                    availableTaxi.IsAvailable = false;

                    MessageBox.Show($"Η κράτησή σας έγινε!\nΠαραλαβή: {pickup}\nΠροορισμός: {destination}\nΑριθμός Ταξί: {availableTaxi.TaxiId}");

                    SaveBookingToFile(pickup, destination, availableTaxi.TaxiId);
                }
                else
                {
                    MessageBox.Show("Συγγνώμη, δεν υπάρχουν διαθέσιμα ταξί αυτή τη στιγμή.");
                }
            }
        }
        private void SaveBookingToFile(string pickup, string destination, int taxiId)
        {
            string path = "bookings.txt";
            string bookingInfo = $"Taxi {taxiId}: Από {pickup} προς {destination} - {DateTime.Now}";

            using (StreamWriter writer = new StreamWriter(path, true)) // true = προσθήκη (append)
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
            IsAvailable = true; // όλα ξεκινάνε διαθέσιμα
        }
    }
}
