using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using WMPDXMLib;
using WMPLauncher;
using AxWMPLib;
using System.IO;
/**
 * Jaron Rose 30038674
 * 19/07/2021
 * Music Player
 * 
 * Question 1: You need to make a Music Player for all staff to use. You need to
 * create a program that plays audio tracks, it must have the ability to go to the start,
 * go back one, go forward one and skip to the end. It must have a GUI and must use
 * doubly linked lists. 
 */
namespace MusicPlayer_QuestionOne
{
    public partial class MusicPlayer : Form
    {
        public MusicPlayer()
        {
            InitializeComponent();
        }
        LinkedList<string> MusicList = new LinkedList<string>();

        //Add songs to the LinkedList
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Multi select allows selection and opening of multiple files
                openFileDialog.Multiselect = true;
                openFileDialog.ShowDialog();
                //reads all files
                foreach (string file in openFileDialog.FileNames)
                {
                    MusicList.AddLast(file);
                }
                DisplayLinkedList();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
        //Display linked list into a list box
        private void DisplayLinkedList()
        {
            ListBox.Items.Clear();
            foreach(string song in MusicList)
            {
                ListBox.Items.Add(Path.GetFileName(song));
            }
        }
        //Plays the first song in the linked list
        private void ButtonFirst_Click(object sender, EventArgs e)
        {
            try
            {
                string song = MusicList.First();
                ListBox.SelectedItem = Path.GetFileName(song);
                currentSongTextBox.Text = Path.GetFileName(song);
                PlaySong(song);
                ButtonFirst.Enabled = false;
                ButtonLast.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error no files to play");
            }
        }
        //Takes content of linked list element and plays the song
        private void PlaySong(string song)
        {
            WindowsMusicPlayer.URL = song;
            WindowsMusicPlayer.settings.autoStart = true;
        }
        //Play last element of linked list
        private void ButtonLast_Click(object sender, EventArgs e)
        {
            try
            {
                string song = MusicList.Last();
                ListBox.SelectedItem = Path.GetFileName(song);
                currentSongTextBox.Text = Path.GetFileName(song);
                PlaySong(song);
                ButtonFirst.Enabled = true;
                ButtonLast.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error no files to play");
            }
        }
        //Play the next element in linked list
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            string currentSong = WindowsMusicPlayer.URL;
            try
            {
                //Makes sure the next element is NOT null
                if (MusicList.Find(currentSong).Next != null)
                {
                    string nextSong = MusicList.Find(currentSong).Next.Value;
                    ListBox.SelectedItem = Path.GetFileName(nextSong);
                    currentSongTextBox.Text = Path.GetFileName(nextSong);
                    PlaySong(nextSong);
                    ButtonFirst.Enabled = true;
                    if(nextSong != MusicList.Last())
                    {
                        ButtonLast.Enabled = true;
                    }
                    else
                    {
                        ButtonLast.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("There is no next song to play.");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error no files to play");
            }
        }
        //Play the previous element in the linked list
        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            string currentSong = WindowsMusicPlayer.URL;
            try
            {
                //Makes sure the previous element is NOT null
                if (MusicList.Find(currentSong).Previous != null)
                {
                    string previousSong = MusicList.Find(currentSong).Previous.Value;
                    ListBox.SelectedItem = Path.GetFileName(previousSong);
                    currentSongTextBox.Text = Path.GetFileName(previousSong);
                    PlaySong(previousSong);
                    ButtonLast.Enabled = true;
                    if (previousSong != MusicList.First())
                    {
                        ButtonFirst.Enabled = true;
                    }
                    else
                    {
                        ButtonFirst.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("There is no previous song to play.");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error no files to play");
            }
        }
    }
}