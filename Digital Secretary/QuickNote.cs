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
    public partial class frmQuickNote : Form
    {
        public DigitalSpeech.Speech speechObject;
        public frmQuickNote(bool speech)
        {
            InitializeComponent();
            speechAllowed = speech;
            speechObject = new DigitalSpeech.Speech();
            //hover
            pnlDiscardNote.MouseEnter += new EventHandler(discardNote_Enter);
            pnlDiscardNote.MouseLeave += new EventHandler(discardNote_Leave);
            pbDiscardNote.MouseEnter += new EventHandler(discardNote_Enter);
            pbDiscardNote.MouseLeave += new EventHandler(discardNote_Leave);
            lblDiscardNote.MouseEnter += new EventHandler(discardNote_Enter);
            lblDiscardNote.MouseLeave += new EventHandler(discardNote_Leave);
            pnlSaveNote.MouseEnter += new EventHandler(saveNote_Enter);
            pbSaveNote.MouseEnter += new EventHandler(saveNote_Enter);
            lblSaveNote.MouseEnter += new EventHandler(saveNote_Enter);
            pnlSaveNote.MouseLeave += new EventHandler(saveNote_Leave);
            pbSaveNote.MouseLeave += new EventHandler(saveNote_Leave);
            lblSaveNote.MouseLeave += new EventHandler(saveNote_Leave);


            //click
            pbToggleSpeech.Click += new EventHandler(toggleSpeech);
            pnlDiscardNote.Click += new EventHandler(discardNote_Click);
            pbDiscardNote.Click += new EventHandler(discardNote_Click);
            lblDiscardNote.Click += new EventHandler(discardNote_Click);
            pnlSaveNote.Click += new EventHandler(saveNote_Click);
            pbSaveNote.Click += new EventHandler(saveNote_Click);
            lblSaveNote.Click += new EventHandler(saveNote_Click);
            
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

        private void discardNote_Enter(object sender, EventArgs e)
        {
            pnlDiscardNote.BackColor = Color.DimGray;
            pnlDiscardNote.BorderStyle = BorderStyle.Fixed3D;
        }
        private void discardNote_Leave(object sender, EventArgs e)
        {
            pnlDiscardNote.BackColor = Color.WhiteSmoke;
            pnlDiscardNote.BorderStyle = BorderStyle.None;
        }

        private void discardNote_Click(object sender, EventArgs e)
        {
            if (txtNoteTitle.Text == "" && rtxtNote.Text == "")
            {

            }
            else
            {
                if (MessageBox.Show("Do You Really Want To Delete This Unsaved Note?", "Discard Unsaved Note", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    txtNoteTitle.Text = "";
                    rtxtNote.Text = "";
                }
            }
        }

        private void saveNote_Enter(object sender, EventArgs e)
        {
            pnlSaveNote.BackColor = Color.DimGray;
            pnlSaveNote.BorderStyle = BorderStyle.Fixed3D;
        }

        private void saveNote_Leave(object sender, EventArgs e)
        {
            pnlSaveNote.BackColor = Color.WhiteSmoke;
            pnlSaveNote.BorderStyle = BorderStyle.None;
        }
        private void saveNote_Click(object sender, EventArgs e)
        {
            Note svn = new Note();
            svn.name = txtNoteTitle.Text;
            svn.note = rtxtNote.Text;
            if (svn.save())
            {
                MessageBox.Show(txtNoteTitle.Text + " was saved successfully");
            }
            else
            {
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

        private void pbLogout_MouseEnter(object sender, EventArgs e)
        {
            pbLogout.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\username-f.png";
        }

        private void pbLogout_MouseLeave(object sender, EventArgs e)
        {
            pbLogout.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\appbar.user.png";
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\class.png";
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\classroom.png";
        }
    }
}
