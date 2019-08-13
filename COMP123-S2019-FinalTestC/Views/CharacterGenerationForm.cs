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
        /// <summary>
        /// This is the default constructor of Character Generation Form
        /// </summary>
        public CharacterGenerationForm()
        {
            InitializeComponent();
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
            //First Name generator
            string firstNameFileName = "C:/Anurag/" +
                "Centennial College/1st Year/Summer Semester/COMP123- Programming 2/" +
                "COMP123-S2019-FinalTestC/COMP123-S2019-FinalTestC/Data/firstNames.txt";
            List<string> firstNameLines = new List<string>();
            TextReader firstNameReader = new StreamReader(firstNameFileName);
            string aFirstName = firstNameReader.ReadLine();
            while(aFirstName != null)
            {
                firstNameLines.Add(aFirstName);
                aFirstName = firstNameReader.ReadLine();
            }
            Random lastNameNumber = new Random();
            int firstNameRandomNumber = lastNameNumber.Next(1, 5494);
            string firstName = firstNameLines[firstNameRandomNumber];
            FirstNameDataLabel.Text = firstName;

            //Last Name generator
            string lastNameFileName = "C:/Anurag/" +
               "Centennial College/1st Year/Summer Semester/COMP123- Programming 2/" +
               "COMP123-S2019-FinalTestC/COMP123-S2019-FinalTestC/Data/lastNames.txt";
            List<string> lastNameLines = new List<string>();
            TextReader lastNameReader = new StreamReader(lastNameFileName);
            string aLastName = lastNameReader.ReadLine();
            while (aLastName != null)
            {
                lastNameLines.Add(aLastName);
                aLastName = lastNameReader.ReadLine();
            }
            Random firstNameNumber = new Random();
            int lastNameRandomNumber = firstNameNumber.Next(1, 88799);
            string lastName = lastNameLines[lastNameRandomNumber];
            LastNameDataLabel.Text = lastName;
        }
    }
}
