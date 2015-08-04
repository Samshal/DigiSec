using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Digital_Secretary
{
    public partial class frmMain : Form
    {
        public DigitalSpeech.Speech speechObject;
        public frmMain(bool speech)
        {
            InitializeComponent();
            speechAllowed = speech;
            speechObject = new DigitalSpeech.Speech();
            //click Handlers
            pbToggleSpeech.Click += new EventHandler(toggleSpeech);
            pnlQuickNote.Click += new EventHandler(quickNote_Click);
            pnlNotebook.Click += new EventHandler(noteBook_click);

            //hover Handlers
            pnlRecentNotes.MouseEnter += new EventHandler(recentNote_Enter);
            pnlRecentNotes.MouseLeave += new EventHandler(recentNote_Leave);
            pbRecentNotes.MouseEnter += new EventHandler(recentNote_Enter);
            pbRecentNotes.MouseLeave += new EventHandler(recentNote_Leave);
            lblRecentNotes.MouseEnter += new EventHandler(recentNote_Enter);
            lblRecentNotes.MouseLeave += new EventHandler(recentNote_Leave);
            pnlManageNote.MouseEnter += new EventHandler(manageNote_Enter);
            pnlManageNote.MouseLeave += new EventHandler(manageNote_Leave);
            pbManageNote.MouseEnter += new EventHandler(manageNote_Enter);
            pbManageNote.MouseLeave += new EventHandler(manageNote_Leave);
            lblManageNote.MouseEnter += new EventHandler(manageNote_Enter);
            lblManageNote.MouseLeave += new EventHandler(manageNote_Leave);
            pnlQuickSearch.MouseEnter += new EventHandler(quickSearch_Enter);
            pnlQuickSearch.MouseLeave += new EventHandler(quickSearch_Leave);
            pbQuickSearch.MouseEnter += new EventHandler(quickSearch_Enter);
            pbQuickSearch.MouseLeave += new EventHandler(quickSearch_Leave);
            lblQuickSearch.MouseEnter += new EventHandler(quickSearch_Enter);
            lblQuickSearch.MouseLeave += new EventHandler(quickSearch_Leave);
            pnlNewReminder.MouseEnter += new EventHandler(newReminder_Enter);
            pnlNewReminder.MouseLeave += new EventHandler(newReminder_Leave);
            pbNewReminder.MouseEnter += new EventHandler(newReminder_Enter);
            pbNewReminder.MouseLeave += new EventHandler(newReminder_Leave);
            lblNewReminder.MouseEnter += new EventHandler(newReminder_Enter);
            lblNewReminder.MouseLeave += new EventHandler(newReminder_Leave);

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
            tmReminder_counter = 0;
            tmReminders.Start();
            if (speechAllowed)
            {
                speechObject.speakText("Hi, Welcome To Your Profile");
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
            int y = pnlMain.Height - 130;
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
            pbExitApplication.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\exit.png";
        }

        private void pbMinimize_MouseEnter(object sender, EventArgs e)
        {
            pbMinimize.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\minimize-blue.png";
        }

        private void pbMinimize_MouseLeave(object sender, EventArgs e)
        {
            pbMinimize.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\minimize.png";
        }

        private void pnlQuickNote_MouseEnter(object sender, EventArgs e)
        {
            pbQuickNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\quicknote-red.png";
            pnlQuickNote.BackColor = Color.White;
            lblQuickNote.ForeColor = Color.Crimson;
        }

        private void pnlQuickNote_MouseLeave(object sender, EventArgs e)
        {
            pbQuickNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\quicknote.png";
            pnlQuickNote.BackColor = Color.Crimson;
            lblQuickNote.ForeColor = Color.White;
        }

        private void pnlNotebook_MouseEnter(object sender, EventArgs e)
        {
            pbNotebook.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\onenote-red.png";
            pnlNotebook.BackColor = Color.White;
            lblNotebook.ForeColor = Color.Red;
        }

        private void pnlNotebook_MouseLeave(object sender, EventArgs e)
        {
            pbNotebook.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\onenote.png";
            pnlNotebook.BackColor = Color.Red;
            lblNotebook.ForeColor = Color.White;
        }

        private void noteBook_click(object sender, EventArgs e)
        {
            frmNoteBook fnb = new frmNoteBook(speechAllowed);
            fnb.Show();
            this.Hide();
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
        private void pbQuickNote_MouseEnter(object sender, EventArgs e)
        {
            pbQuickNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\quicknote-red.png";
            pnlQuickNote.BackColor = Color.White;
            lblQuickNote.ForeColor = Color.Crimson;
        }

        private void pbQuickNote_MouseLeave(object sender, EventArgs e)
        {
            pbQuickNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\quicknote.png";
            pnlQuickNote.BackColor = Color.Crimson;
            lblQuickNote.ForeColor = Color.White;
        }

        private void lblQuickNote_MouseEnter(object sender, EventArgs e)
        {
            pbQuickNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\quicknote-red.png";
            pnlQuickNote.BackColor = Color.White;
            lblQuickNote.ForeColor = Color.Crimson;
        }

        private void lblQuickNote_MouseLeave(object sender, EventArgs e)
        {
            pbQuickNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\quicknote.png";
            pnlQuickNote.BackColor = Color.Crimson;
            lblQuickNote.ForeColor = Color.White;
        }

        private void pbNotebook_MouseEnter(object sender, EventArgs e)
        {
            pbNotebook.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\onenote-red.png";
            pnlNotebook.BackColor = Color.White;
            lblNotebook.ForeColor = Color.Red;
        }

        private void quickNote_Click(object sender, EventArgs e)
        {
            frmQuickNote fqn = new frmQuickNote(speechAllowed);
            fqn.Show();
            this.Hide();
        }

        private void lblNotebook_MouseEnter(object sender, EventArgs e)
        {
            pbNotebook.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\onenote-red.png";
            pnlNotebook.BackColor = Color.White;
            lblNotebook.ForeColor = Color.Red;
        }

        private void lblNotebook_MouseLeave(object sender, EventArgs e)
        {
            pbQuickNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\quicknote.png";
            pnlQuickNote.BackColor = Color.Crimson;
            lblQuickNote.ForeColor = Color.White;
        }

        private void pbNotebook_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void recentNote_Enter(object sender, EventArgs e)
        {
            pbRecentNotes.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\notebooks-blue.png";
            pnlRecentNotes.BackColor = Color.White;
            lblRecentNotes.ForeColor = Color.Blue;
        }

        private void recentNote_Leave(object sender, EventArgs e)
        {
            pbRecentNotes.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\notebooks.png";
            pnlRecentNotes.BackColor = Color.Blue;
            lblRecentNotes.ForeColor = Color.White;
        }

        private void manageNote_Enter(object sender, EventArgs e)
        {
            pbManageNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\notemanage-orange.png";
            pnlManageNote.BackColor = Color.White;
            lblManageNote.ForeColor = Color.DarkOrange;
        }

        private void manageNote_Leave(object sender, EventArgs e)
        {
            pbManageNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\notemanager.png";
            pnlManageNote.BackColor = Color.DarkOrange;
            lblManageNote.ForeColor = Color.White;
        }

        private void quickSearch_Enter(object sender, EventArgs e)
        {
            pbQuickSearch.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\search-purple.png";
            pnlQuickSearch.BackColor = Color.White;
            lblQuickSearch.ForeColor = Color.Purple;
        }
        private void quickSearch_Leave(object sender, EventArgs e)
        {
            pbQuickSearch.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\book search.png";
            pnlQuickSearch.BackColor = Color.Purple;
            lblQuickSearch.ForeColor = Color.White;
        }

        private void pbNotebook_MouseLeave(object sender, EventArgs e)
        {
            pbQuickNote.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\quicknote.png";
            pnlQuickNote.BackColor = Color.Crimson;
            lblQuickNote.ForeColor = Color.White;
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            if (speechAllowed)
            {
                speechObject.speakText("Do you really want to log out?");
            }
            if (MessageBox.Show("Are You Sure You Want To Log Out?", "Confirm Log Out", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
            }
        }

        private void pnlQuickNote_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void pnlTransport_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnlTransport_Click(object sender, EventArgs e)
        {
            frmNewReminder fnr = new frmNewReminder(speechAllowed);
            fnr.Show();
            this.Hide();
        }

        private void recentReminders(int index)
        {
            Reminder reminder = new Reminder();
            ArrayList reminders = new ArrayList();
            reminders = reminder.reminders();
            try
            {
                ArrayList remindElem = (ArrayList)reminders[index];
                string name = remindElem[0].ToString();
                lblRecentReminders.Text = name;
                tmReminder_counter = index + 1;

            }
            catch (Exception e)
            {
                tmReminder_counter = 0;
            }
        }

        private void newReminder_Enter(object sender, EventArgs e)
        {
            pnlNewReminder.BackColor = Color.White;
            lblNewReminder.ForeColor = Color.DeepSkyBlue;
            pbNewReminder.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\reminder-blue.png";

        }

        private void newReminder_Leave(object sender, EventArgs e)
        {
            pnlNewReminder.BackColor = Color.DeepSkyBlue;
            lblNewReminder.ForeColor = Color.White;
            pbNewReminder.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\reminder.png";
        }
        private void tmReminders_Tick(object sender, EventArgs e)
        {
            recentReminders(tmReminder_counter);
        }

        private int tmReminder_counter
        {
            get;
            set;
        }

        private void pbHome_MouseEnter(object sender, EventArgs e)
        {
            pbHome.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\home-green.png";
        }

        private void pbHome_MouseLeave(object sender, EventArgs e)
        {
            pbHome.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\home.png";
        }

        private void pbExit_MouseEnter(object sender, EventArgs e)
        {
            pbExit.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\power-off.png";
        }

        private void pbExit_MouseLeave(object sender, EventArgs e)
        {
            pbExit.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\appbar.power.png";
        }

        private void pbLogout_MouseEnter(object sender, EventArgs e)
        {
            pbLogout.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\username-f.png";
        }

        private void pbLogout_MouseLeave(object sender, EventArgs e)
        {
            pbLogout.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\appbar.user.png";
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            if (speechAllowed)
            {
                speechObject.speakText("This Feature Is Under Construction");
            }
            MessageBox.Show("This Featue is still being developed", "Please come back later", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            AboutUs ab = new AboutUs();
            ab.Show();
        }
    }
}
