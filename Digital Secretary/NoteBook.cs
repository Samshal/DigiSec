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
using DigitalSpeech;

namespace Digital_Secretary
{
    public partial class frmNoteBook : Form
    {
        public DigitalSpeech.Speech speechObject;
        public frmNoteBook(bool speech)
        {
            InitializeComponent();
            speechAllowed = speech;
            speechObject = new DigitalSpeech.Speech();
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
            getNotes();
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

        public void getNotes()
        {
            ArrayList notes = new ArrayList();
            Note notebook = new Note();
            notes = notebook.notes();
            ListViewItem itm;
            Assemblies.Stringify stringify = new Assemblies.Stringify();
            foreach (ArrayList note in notes)
            {
                try
                {
                    string[] arr = new string[3];
                    arr[0] = note[0].ToString();
                    arr[1] = note[1].ToString();
                    arr[2] = notes[2].ToString();
                    char[] delim = { Convert.ToChar(".") };
                    arr[0] = stringify.getArray(arr[0], delim)[0];
                    itm = new ListViewItem(arr);
                    lstviewAllNotes.Items.Add(itm);
                }
                catch
                {

                }
            }
        }

        private void listBoxAdv1_ItemClick(object sender, EventArgs e)
        {
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\delete-dark.png";
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\delete.png";
        }

        private void lstviewAllNotes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
        }

        private void lstviewAllNotes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        }

        private void lstviewAllNotes_Click(object sender, EventArgs e)
        {
            string selected = lstviewAllNotes.SelectedItems[0].SubItems[0].Text;
            Note note = new Note();
            note.name = selected;
            note.notecontent();
            rtxtNote.Text = note.note;
            txtName.Text = note.unclean(note.name);
        }

        private void pbLogout_MouseEnter(object sender, EventArgs e)
        {
            pbLogout.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\username-f.png";
        }

        private void pbLogout_MouseLeave(object sender, EventArgs e)
        {
            pbLogout.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\appbar.user.png";
        }

        private void pbHome_MouseEnter(object sender, EventArgs e)
        {
            pbHome.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\home-green.png";
        }

        private void pbHome_MouseLeave(object sender, EventArgs e)
        {
            pbHome.ImageLocation = @"C:\Users\SamshalTechs\Desktop\Assets\icons\metro\home.png";
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain(speechAllowed);
            frm.Show();
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

    }
}
