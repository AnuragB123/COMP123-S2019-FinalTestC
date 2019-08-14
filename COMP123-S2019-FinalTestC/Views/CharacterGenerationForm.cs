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
 * STUDENT NAME: Anurag
 * STUDENT ID: 301050634
 * DESCRIPTION: This is the main form for the application
*/
namespace COMP123_S2019_FinalTestC.Views
{
    public partial class CharacterGenerationForm : COMP123_S2019_FinalTestC.Views.MasterForm
    {
        //string list for first name and last name
        List<string> FirstNameList = new List<string>();
        List<string> LastNameList = new List<string>();

        //string list for the skills
        List<string> SkillsList = new List<string>();
        
        /// <summary>
        /// This is the default constructor of Character Generation Form
        /// </summary>
        public CharacterGenerationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method loads the two text files into the respective lists
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

        /// <summary>
        /// This method chooses a random name in both first name and last name and displays in the respective label
        /// </summary>
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
        /// This is the method that generates random numbers between 1 to 15 for each ability
        /// </summary>
        public void GenerateAbilitiesValues()
        {
            //Random used to generate the random numbers
            Random Value = new Random();
            
            int strengthValueRandomNumber = Value.Next(1, 15);
            StrengthDataLabel.Text = strengthValueRandomNumber.ToString();

            int dexterityValueRandomNumber = Value.Next(1, 15);
            DexterityDataLabel.Text = dexterityValueRandomNumber.ToString();

            int enduranceValueRandomNumber = Value.Next(1, 15);
            EnduranceDataLabel.Text = enduranceValueRandomNumber.ToString();

            int intellectValueRandomNumber = Value.Next(1, 15);
            IntellectDataLabel.Text = intellectValueRandomNumber.ToString();

            int educationValueRandomNumber = Value.Next(1, 15);
            EducationDataLabel.Text = educationValueRandomNumber.ToString();

            int socialStandingValueRandomNumber = Value.Next(1, 15);
            SocailStandingDataLabel.Text = socialStandingValueRandomNumber.ToString();

            //Assigns the Program.character to the respective properties of the class generated
            Program.character.Strength = strengthValueRandomNumber.ToString();
            Program.character.Dexterity = dexterityValueRandomNumber.ToString();
            Program.character.Endurance = enduranceValueRandomNumber.ToString();
            Program.character.Intellect = intellectValueRandomNumber.ToString();
            Program.character.Education = enduranceValueRandomNumber.ToString();
            Program.character.SocialStanding = SocailStandingDataLabel.Text;
        }

        /// <summary>
        /// This is a method that loads skills from text file into Skills List
        /// </summary>
        public void LoadSkills()
        {
            string skillsFileName = "C:/Anurag/" +
                "Centennial College/1st Year/Summer Semester/COMP123- Programming 2/" +
                "COMP123-S2019-FinalTestC/COMP123-S2019-FinalTestC/Data/skills.txt";
            TextReader skillsReader = new StreamReader(skillsFileName);
            string aSkill = skillsReader.ReadLine();
            while (aSkill != null)
            {
                SkillsList.Add(aSkill);
                aSkill = skillsReader.ReadLine();
            }
        }

        public void GenerateRandomSkills()
        {
            Random skillsValue = new Random();

            int randomSkillOne = skillsValue.Next(1, 99);
            SkillsOneLabel.Text = SkillsList[randomSkillOne];

            int randomSkillTwo = skillsValue.Next(1, 99);
            SkillsTwoLabel.Text = SkillsList[randomSkillOne];

            int randomSkillThree = skillsValue.Next(1, 99);
            SkillsThreeLabel.Text = SkillsList[randomSkillOne];

            int randomSkillFour = skillsValue.Next(1, 99);
            SkillsFourLabel.Text = SkillsList[randomSkillOne];

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

        /// <summary>
        /// This is the event handler when Character Generation Form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterGenerationForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();
            LoadSkills();
            if (MainTabControl.SelectedIndex == 3)
            {
                FnDataLabel.Text = Program.character.Identiy.FirstName;
                LnDataLabel.Text = Program.character.Identiy.LastName;
                SoLabel.Text = SkillsOneLabel.Text;
                StLabel.Text = SkillsTwoLabel.Text;
                SthLabel.Text = SkillsThreeLabel.Text;
                SfLabel.Text = SkillsFourLabel.Text;
                SdLabel.Text = Program.character.Strength;
                ddLabel.Text = Program.character.Dexterity;
                edLabel.Text = Program.character.Endurance;
                idLabel.Text = Program.character.Intellect;
                eddLabel.Text = Program.character.Education;
                ssdLabel.Text = Program.character.SocialStanding;

            }
        }

        /// <summary>
        /// This is the event handler when the Generate Abilities Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAbiltiesButton_Click(object sender, EventArgs e)
        {
            GenerateAbilitiesValues();
        }

        /// <summary>
        /// This is the event handler when Generate Skills Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateSkills_Click(object sender, EventArgs e)
        {
            GenerateRandomSkills();
        }

        /// <summary>
        /// This is the event handler when exit menu strip Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This is the event handler when about menu strip Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutInformation.ShowDialog();
        }
    }
}
