using COMP123_S2019_FinalTestC.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
/*
 * STUDENT NAME:
 * STUDENT ID:
 * DESCRIPTION: This is the main form for the application
*/
namespace COMP123_S2019_FinalTestC.Views
{
    public partial class CharacterGenerationForm : COMP123_S2019_FinalTestC.Views.MasterForm
    {
        //two string list
        List<string> FirstNameList = new List<string>();
        List<string> LastNameList = new List<string>();
        
        /// <summary>
        /// This is the default constructor of Character Generation Form
        /// </summary>
        public CharacterGenerationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the two text files into the respective lists
        /// </summary>
        public void LoadNames()
        {
            string firstNameFileName = "C:/Anurag/" +
                "Centennial College/1st Year/Summer Semester/COMP123- Programming 2/" +
                "COMP123-S2019-FinalTestC/COMP123-S2019-FinalTestC/Data/firstNames.txt";
            TextReader firstNameReader = new StreamReader(firstNameFileName);
            string aFirstName = firstNameReader.ReadLine();
            while (aFirstName != null)
            {
                FirstNameList.Add(aFirstName);
                aFirstName = firstNameReader.ReadLine();
            }

            string lastNameFileName = "C:/Anurag/" +
               "Centennial College/1st Year/Summer Semester/COMP123- Programming 2/" +
               "COMP123-S2019-FinalTestC/COMP123-S2019-FinalTestC/Data/lastNames.txt";
            TextReader lastNameReader = new StreamReader(lastNameFileName);
            string aLastName = lastNameReader.ReadLine();
            while (aLastName != null)
            {
                LastNameList.Add(aLastName);
                aLastName = lastNameReader.ReadLine();
            }
        }

        public void GenerateNames()
        {
            //First Name Generator
            Random lastNameNumber = new Random();
            int firstNameRandomNumber = lastNameNumber.Next(1, 5494);
            string firstName = FirstNameList[firstNameRandomNumber];
            FirstNameDataLabel.Text = firstName;

            //Last Name Generator
            Random firstNameNumber = new Random();
            int lastNameRandomNumber = firstNameNumber.Next(1, 88799);
            string lastName = LastNameList[lastNameRandomNumber];
            LastNameDataLabel.Text = lastName;


        }
        /// <summary>
        /// This is the event handler for the BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// This is the event handler for the NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }

        /// <summary>
        /// This is the event handler for Generate Name Button Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            GenerateNames();
            Program.character.Identiy.FirstName = FirstNameDataLabel.Text;
            Program.character.Identiy.LastName = LastNameDataLabel.Text;
        }

        private void CharacterGenerationForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();
        }
    }
}
