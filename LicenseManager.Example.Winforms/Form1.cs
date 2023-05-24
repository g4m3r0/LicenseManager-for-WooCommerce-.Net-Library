namespace LicenseManager.Example.Winforms
{
    using LicenseManager.Lib;
    using System.Globalization;
    using System.Diagnostics;
    using LicenseManager.Lib.Exceptions;

    public partial class Form1 : Form
    {
        public LicenseManagerClient? LicenseManager { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void ClearPropertyGrid()
        {
            this.propertyGrid1.SelectedObject = null;
        }

        private void buttonSetupLicenseClient_Click(object sender, EventArgs e)
        {
            this.ClearPropertyGrid();

            var cultureInfo = new CultureInfo("en");
            //var cultureInfo = new CultureInfo("de");
            //var cultureInfo = new CultureInfo("es");
            //var cultureInfo = new CultureInfo("fr");
            //var cultureInfo = new CultureInfo("ru");
            //var cultureInfo = new CultureInfo("zh");

            Debug.WriteLine("Setup the client...");

            try
            {
                this.LicenseManager = new LicenseManagerClient(this.textBoxHost.Text, this.textBoxConsumerKey.Text, this.textBoxConsumerSecret.Text, Convert.ToInt32(this.textBoxProductId.Text), cultureInfo);

                this.buttonActivateLicense.Enabled = true;
                this.buttonDeActivateLicense.Enabled = true;
                this.buttonValidateLicense.Enabled = true;
                this.buttonListLicenses.Enabled = true;

                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void buttonActivateLicense_Click(object sender, EventArgs e)
        {
            this.ClearPropertyGrid();
            Debug.WriteLine("Activate a license:");

            if (this.LicenseManager == null)
            {
                Debug.WriteLine("Please setup the client first!");
                MessageBox.Show("Please setup the client first!");
                return;
            }

            try
            {
                var activateLicenseResponse = await this.LicenseManager.ActivateLicenseAsync(this.textBoxLicenseKey.Text).ConfigureAwait(true);

                if (activateLicenseResponse != null)
                {
                    Debug.WriteLine($"Success: {activateLicenseResponse.Success}");
                    this.propertyGrid1.SelectedObject = activateLicenseResponse.Data;
                }
            }
            catch (LicenseManagerException ex)
            {
                Debug.WriteLine($"Success: false");
                Debug.WriteLine(ex.Message);

                MessageBox.Show(ex.Message);
                this.propertyGrid1.SelectedObject = ex;
            }
        }

        private async void buttonDeActivateLicense_Click(object sender, EventArgs e)
        {
            this.ClearPropertyGrid();
            Debug.WriteLine("DeActivate a license");

            if (this.LicenseManager == null)
            {
                Debug.WriteLine("Please setup the client first!");
                MessageBox.Show("Please setup the client first!");
                return;
            }

            try
            {
                var deactivateLicenseResponse = await this.LicenseManager.DeactivateLicenseAsync(this.textBoxLicenseKey.Text).ConfigureAwait(true);

                if (deactivateLicenseResponse != null)
                {
                    Debug.WriteLine($"Success: {deactivateLicenseResponse.Success}");
                    this.propertyGrid1.SelectedObject = deactivateLicenseResponse.Data;
                }
            }
            catch (LicenseManagerException ex)
            {
                Debug.WriteLine($"Success: false");
                Debug.WriteLine(ex.Message);

                MessageBox.Show(ex.Message);

            }
        }

        private async void buttonValidateLicense_Click(object sender, EventArgs e)
        {
            this.ClearPropertyGrid();
            Debug.WriteLine("Validate a license");

            if (this.LicenseManager == null)
            {
                Debug.WriteLine("Please setup the client first!");
                MessageBox.Show("Please setup the client first!");
                return;
            }

            try
            {
                var licenseResponse = await this.LicenseManager.ValidateLicenseAsync(textBoxLicenseKey.Text);

                Debug.WriteLine($"Success: {licenseResponse.Success}");

                this.propertyGrid1.SelectedObject = licenseResponse.Data;
            }
            catch (LicenseManagerException ex)
            {
                Debug.WriteLine($"Success: false");
                Debug.WriteLine(ex.Message);

                MessageBox.Show(ex.Message);
                this.propertyGrid1.SelectedObject = ex;
            }
        }

        private async void buttonListLicenses_Click(object sender, EventArgs e)
        {
            this.ClearPropertyGrid();
            Debug.WriteLine("List all licenses");

            if (this.LicenseManager == null)
            {
                Debug.WriteLine("Please setup the client first!");
                MessageBox.Show("Please setup the client first!");
                return;
            }

            try
            {
                var allLicensesResponse = await this.LicenseManager.ListLicensesAsync().ConfigureAwait(true);

                Debug.WriteLine($"Success: {allLicensesResponse.Success}");
                this.propertyGrid1.SelectedObject = allLicensesResponse.Data;
            }
            catch (LicenseManagerException ex)
            {
                Debug.WriteLine($"Success: false");
                Debug.WriteLine(ex.Message);

                MessageBox.Show(ex.Message);
                this.propertyGrid1.SelectedObject = ex;
            }
        }
    }
}