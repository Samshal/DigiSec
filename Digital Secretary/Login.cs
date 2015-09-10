using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auth;
using DigitalSpeech;

namespace Digital_Secretary
{
    public partial class frmLogin : Form
    {
        Speech speechObject = new Speech();

        public frmLogin()
        {
            InitializeComponent();
            pnlLogin.Click += new EventHandler(login);
            pbLogin.Click += new EventHandler(login);
            lblLogin.Click += new EventHandler(login);
            pbToggleSpeech.Click += new EventHandler(toggleSpeech);
        }
        int rightX;
        int rightY;

        private bool speechAllowed
        {
            get;
            set;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            setFullScreen();
            setMainPanelPosition();
            setRightOptionsPanelPosition();

            txtLogin_Password.Text = "Password";
            txtLogin_Username.Text = "Username";
            txtLogin_Password.ForeColor = System.Drawing.Color.Gray;
            txtLogin_Username.ForeColor = System.Drawing.Color.Gray;
            txtLogin_Username.Focus();
            this.speechAllowed = true;
            if (this.speechAllowed)
            {
                speechObject.speakText("Welcome, Please Login To Continue To Your Profile");
            }
        }

        private void setFullScreen()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Location = new Point(0, 0);
            Size = new Size(x, y);
        }
        private void setMainPanelPosition()
        {
            int mX = (Width - pnlMain.Width) / 2;
            int mY = (Height - pnlMain.Height) / 2;
            pnlMain.Location = new Point(mX, mY);
            //pnlRightOptions.Location = new Point(Width -200, mY + 40);
        }
        private void setRightOptionsPanelPosition()
        {
            int y = pnlMain.Height - 100;
            rightY = 125;
            rightX = pnlMain.Width + 270;
            pnlRightOptions.Size = new Size(pnlRightOptions.Width, y);
            pnlRightOptions.Location = new Point(rightX, rightY);
            pbExitApplication.Location = new Point(rightX, 40);
            pbMinimize.Location = new Point(rightX - 80, 40);
            int rX = pnlRightMain.Location.X;
            int rY = (pnlRightOptions.Height - pnlRightMain.Height) / 2;
            pnlRightMain.Location = new Point(rX, rY);
        }
       
        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void pnlRightMain_Paint(object sender, PaintEventArgs e)
        {
       

        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbExitApplication_MouseHover(object sender, EventArgs e)
        {
        }

        private void pbExitApplication_MouseEnter(object sender, EventArgs e)
        {
            pbExitApplication.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\close-red.png";
        }

        private void pbExitApplication_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pbMinimize_MouseEnter(object sender, EventArgs e)
        {
            pbMinimize.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\minimize-blue.png";
        }

        private void pbMinimize_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login(object sender, EventArgs e)
        {
            LoginAuth login = new LoginAuth();
            login.Username = txtLogin_Username.Text;
            login.Password = txtLogin_Password.Text;
            bool s = login.validate();
            if (s)
            {
                login_successful();

            }
            else
            {
                login_failed();
            }
        }

        private void login_successful()
        {
            frmMain main = new frmMain(speechAllowed);
            main.Show();
            this.Hide();
        }

        private void login_failed()
        {
            pnlErrorPane.Visible = true;
            if (speechAllowed)
            {
                speechObject.speakText("Your Login Data Were Invalid.");
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pnlErrorPane.Visible = false;
        }

        private void txtLogin_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogin_Username_Click(object sender, EventArgs e)
        {
            if (txtLogin_Username.Text == "Username")
            {
                txtLogin_Username.ForeColor = new Color();
                txtLogin_Username.Text = "";
            }
        }

        private void txtLogin_Password_Click(object sender, EventArgs e)
        {
            if (txtLogin_Password.Text == "Password")
            {
                txtLogin_Password.ForeColor = new Color();
                txtLogin_Password.Text = "";
                txtLogin_Password.PasswordChar = Convert.ToChar("*");
            }
        }

        private void txtLogin_Username_Leave(object sender, EventArgs e)
        {
            if (txtLogin_Username.Text == "")
            {
                txtLogin_Username.ForeColor = System.Drawing.Color.Gray;
                txtLogin_Username.Text = "Username";
            }
        }

        private void txtLogin_Password_Leave(object sender, EventArgs e)
        {
            if (txtLogin_Password.Text == "")
            {
                txtLogin_Password.Text = "Password";
                txtLogin_Password.PasswordChar = '\0';
                txtLogin_Password.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtLogin_Password_Enter(object sender, EventArgs e)
        {
            if (txtLogin_Password.Text == "Password")
            {
                txtLogin_Password.ForeColor = new Color();
                txtLogin_Password.Text = "";
                txtLogin_Password.PasswordChar = Convert.ToChar("*");
            }
        }
        
        private void toggleSpeech(object sender, EventArgs e)
        {
            if (speechAllowed)
            {
                speechAllowed = false;
                speechObject.speakText("Speech Has Been Turned Off");
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\no-microphone.png";
            }
            else
            {
                speechAllowed = true;
                speechObject.speakText("Speech Is Now On");
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\microphone.png";
            }
        }

        private void pbToggleSpeech_MouseEnter(object sender, EventArgs e)
        {
            if (speechAllowed)
            {
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\microphone-red.png";
            }
            else
            {
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\no-microphone-red.png";
            }
        }

        private void pbToggleSpeech_MouseLeave(object sender, EventArgs e)
        {
            if (speechAllowed)
            {
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\microphone.png";
            }
            else
            {
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\no-microphone.png";
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            AboutUs abu = new AboutUs();
            abu.Show();
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\about-blue.png";
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\abut-white.png";
        }
    }
}
