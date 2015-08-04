using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Secretary
{
    public partial class frmNewReminder : Form
    {
        public DigitalSpeech.Speech speechObject;
        public frmNewReminder(bool speech)
        {
            InitializeComponent();
            speechAllowed = speech;
            speechObject = new DigitalSpeech.Speech();
            //hover
            pnlDiscard.MouseEnter += new EventHandler(discard_Enter);
            pnlDiscard.MouseLeave += new EventHandler(discard_Leave);
            pbDiscard.MouseEnter += new EventHandler(discard_Enter);
            pbDiscard.MouseLeave += new EventHandler(discard_Leave);
            lblDiscard.MouseEnter += new EventHandler(discard_Enter);
            lblDiscard.MouseLeave += new EventHandler(discard_Leave);
            pnlCreate.MouseEnter += new EventHandler(save_Enter);
            pbCreate.MouseEnter += new EventHandler(save_Enter);
            lblCreate.MouseEnter += new EventHandler(save_Enter);
            pnlCreate.MouseLeave += new EventHandler(save_Leave);
            pbCreate.MouseLeave += new EventHandler(save_Leave);
            lblCreate.MouseLeave += new EventHandler(save_Leave);


            //click
            pbToggleSpeech.Click += new EventHandler(toggleSpeech);
            pnlDiscard.Click += new EventHandler(discard_Click);
            pbDiscard.Click += new EventHandler(discard_Click);
            lblDiscard.Click += new EventHandler(discard_Click);
            pnlCreate.Click += new EventHandler(save_Click);
            pbCreate.Click += new EventHandler(save_Click);
            lblCreate.Click += new EventHandler(save_Click);
            
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
            if (speechAllowed)
            {
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\microphone.png";
            }
            else
            {
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\no-microphone.png";
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

        private void discard_Enter(object sender, EventArgs e)
        {
            pnlDiscard.BackColor = Color.DimGray;
            pnlDiscard.BorderStyle = BorderStyle.Fixed3D;
        }
        private void discard_Leave(object sender, EventArgs e)
        {
            pnlDiscard.BackColor = Color.WhiteSmoke;
            pnlDiscard.BorderStyle = BorderStyle.None;
        }

        private void discard_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" && rtxtNote.Text == "")
            {

            }
            else
            {
                if (speechAllowed)
                {
                    speechObject.speakText("You are about to discard an unsaved note");
                }
                if (MessageBox.Show("Do You Really Want To Delete This Unsaved Note?", "Discard Unsaved Note", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    txtTitle.Text = "";
                    rtxtNote.Text = "";
                }
            }
        }

        private void save_Enter(object sender, EventArgs e)
        {
            pnlCreate.BackColor = Color.DimGray;
            pnlCreate.BorderStyle = BorderStyle.Fixed3D;
        }

        private void save_Leave(object sender, EventArgs e)
        {
            pnlCreate.BackColor = Color.WhiteSmoke;
            pnlCreate.BorderStyle = BorderStyle.None;
        }
        private void save_Click(object sender, EventArgs e)
        {
            Reminder svn = new Reminder();
            svn.name = txtTitle.Text;
            svn.note = rtxtNote.Text;
            svn.date = dtDateTime.Value;
            svn.time = tmTime.Value;
            if (svn.save())
            {
                if (speechAllowed)
                {
                    speechObject.speakText(txtTitle.Text + " was saved successfully");
                }
                MessageBox.Show(txtTitle.Text + " was saved successfully");
            }
            else
            {
                if (speechAllowed)
                {
                    speechObject.speakText("It seems some fields were left blank");
                }
                MessageBox.Show("An Error Occurred, Please Try Again");
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
            if (!speechAllowed)
            {
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\no-microphone.png";
            }
            else
            {
                pbToggleSpeech.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\microphone.png";
            }
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain(speechAllowed);
            main.Show();
            this.Hide();
        }

        private void pbHome_MouseEnter(object sender, EventArgs e)
        {
            pbHome.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\home-green.png";
        }

        private void pbHome_MouseLeave(object sender, EventArgs e)
        {
            pbHome.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\home.png";
        }
    }
}
