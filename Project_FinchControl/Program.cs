using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Lovell, James
    // Dated Created: 2/19/2021
    // Last Modified: 2/20/2021
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        ///all methods and calls should be nestled into the menu screen.     


        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch Bobert = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(Bobert);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(Bobert);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(Bobert);
                        break;

                    case "d":
                        AlarmSystemDisplayMenuScreen(Bobert);
                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(Bobert);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(Bobert);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *      method--g-- ^ method--M--  Talent Show Menu            
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch Bobert)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("\tTalent Show Menu");
                Console.WriteLine();
                Console.WriteLine("\tThis module is currently under developoment, sorry about the mess!");
                DisplayContinuePrompt();
                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it up");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(Bobert);
                        break;

                    case "b":
                        TalentShowDisplayDance(Bobert);
                        break;

                    case "c":
                        TalentShowDisplayMixingItUp(Bobert);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *  method--N-- Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="Bobert">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch Bobert)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("\tLight and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            //for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            //{
            //    Bobert.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
            //    Bobert.noteOn(lightSoundLevel * 100);
            //}

            //
            //led flash
            //
           
            Bobert.setLED(255, 0, 0);
            Bobert.wait(2000);
            Bobert.setLED(0, 255, 0);
            Bobert.wait(2000);
            Bobert.setLED(255, 0, 255);
            Bobert.wait(2000);
            Bobert.setLED(0, 0, 0);
            Bobert.setLED(255, 0, 0);
            Bobert.wait(2000);
            Bobert.setLED(0, 255, 0);
            Bobert.wait(2000);
            Bobert.setLED(255, 0, 255);
            Bobert.wait(2000);
            Bobert.setLED(0, 0, 0);

            for (int numberflashes = 0; numberflashes < 10; numberflashes++)
            {
                Bobert.setLED(255, 0, 0);
                Bobert.wait(200);
                Bobert.setLED(0, 0, 0);
                Bobert.wait(200);
            }

            for (int x = 0; x < 255; x=x+15)
            {
                Bobert.setLED(x, 0, x);
                Bobert.wait(100);
            }

            DisplayContinuePrompt();
            Bobert.setLED(0, 0, 0);


            DisplayContinuePrompt();
            DisplayMenuPrompt("\tTalent Show Menu");
        }
        /// <summary>
        /// *****************************************************************
        /// *  method--O-- Talent Show > Display Dance                     *
        /// *****************************************************************
        /// </summary>
        /// <param name="Bobert">finch robot object</param>
        static void TalentShowDisplayDance(Finch Bobert)
        {
            DisplayScreenHeader("\tDance!");

           Console.WriteLine("Bobert will now go through his paces!");
            DisplayContinuePrompt();
           
            Console.WriteLine("\tPut your left wheel in!");
           Bobert.setMotors(250, 0);
           Bobert.wait(750);
            Bobert.setMotors(0, 0);

            DisplayContinuePrompt();

            Console.WriteLine("\tTake your left wheel out!");
           Bobert.setMotors(-250, 0);
            Bobert.wait(750);
            Bobert.setMotors(0, 0);

            DisplayContinuePrompt();

            Console.WriteLine("\tPut both wheels in and shake it all about!");
            Bobert.setMotors(250,250);
            Bobert.wait(1000);
            Bobert.setMotors(-250, 250);
            Bobert.wait(500);
            Bobert.setMotors(250, -250);
            Bobert.wait(500);
            Bobert.setMotors(-250, 250);
            Bobert.wait(500);
            Bobert.setMotors(250, -250);
            Bobert.wait(500);
            Bobert.setMotors(250, -100);
            Bobert.wait(1200);
            Bobert.setMotors(0, 0);
            Console.WriteLine();
            Console.WriteLine("\t*Phweh!*");
            Console.WriteLine();
            Console.WriteLine("\tAnd that's what the hokey-pokey is all about!");
            Console.WriteLine();
            Console.WriteLine("\t... ... ...");
            Console.WriteLine();
            Bobert.setMotors(-250, 250);
            Bobert.wait(100);
            Bobert.setMotors(250, -250);
            Bobert.wait(100);
            Bobert.setMotors(-250, 250);
            Bobert.wait(100);
            Bobert.setMotors(250, -250);
            Bobert.wait(100);
            Bobert.setMotors(0, 0);
            Console.WriteLine("\tDancing is fun, but it gets Bobert dizzy!");

            DisplayContinuePrompt();


        }
        /// <summary>
        /// *****************************************************************
        /// *  method--P-- Talent Show > Mixing it UP                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="Bobert">finch robot object</param>
        static void TalentShowDisplayMixingItUp(Finch Bobert)
        {
            DisplayScreenHeader("\tMixing It Up");
            Console.WriteLine();
            Console.WriteLine("\tmake sound lights, sounds, and movements");
            // code code code
            // ramp noise up to creshendo, then back down,
            // do a circle
            
            //Fix Song, then hit push in the upper right hand corner to finish
            Bobert.noteOn(1244);
            Bobert.setMotors(200, 200);
            Bobert.wait(250);
            Bobert.noteOff();
            Bobert.setMotors(0, 0);

            
            Bobert.noteOn(1244);
            Bobert.setMotors(-200, -200);
            Bobert.wait(250);
            Bobert.setMotors(0, 0);
            Bobert.noteOff();

            Bobert.noteOn(1108);
            Bobert.setLED(100,00,00);
            Bobert.wait(250);
            Bobert.noteOff();
            Bobert.setLED(0,0,0);
            Bobert.noteOn(1244);
            Bobert.setLED(0, 200, 0);
            Bobert.wait(250);
            Bobert.noteOff();
            Bobert.setLED(0, 0, 0);
            Bobert.noteOn(932);
            Bobert.wait(250);
            Bobert.noteOff();
            Bobert.wait(250);
            Bobert.noteOn(932);
            Bobert.wait(500);
            Bobert.noteOff();
            Bobert.noteOn(1244);
            Bobert.wait(500);
            Bobert.noteOff();
            Bobert.noteOn(1661);
            Bobert.wait(500);
            Bobert.noteOff();
            Bobert.noteOn(1568);
            Bobert.wait(500);
            Bobert.noteOff();
            Bobert.noteOn(1244);
            Bobert.wait(500);
            Bobert.noteOff();
            bool validResponse;
            string userResponse;
            int frequency;
            do
            {
                validResponse = true;

                Console.Write($"\tfrequncy:");
                userResponse = Console.ReadLine();

                if (!int.TryParse(userResponse, out frequency))
                {
                    Console.WriteLine("\t\tPlease enter a proper number.");
                    validResponse = false;
                }

            } while (!validResponse);

            Bobert.noteOn(frequency);
            Bobert.wait(500);
            Bobert.noteOff();

            Console.WriteLine("\tWas that your note?");
            DisplayContinuePrompt();

            do
            {
                validResponse = true;

                Console.Write($"\tyes or no?");
                userResponse = Console.ReadLine();

                if ((userResponse != "yes")&&(userResponse != "no"))
                {
                    Console.WriteLine("\t its a yes or no dummy!");
                    validResponse = false;
                }

            } while (!validResponse);

            if (userResponse == "yes")
            {
                Console.WriteLine("\thuzzah!");               
            }

            if (userResponse == "no")
            {
                Console.WriteLine("\tSince that's the note you gave me, im moving on anyway!");
            }          
            
            DisplayContinuePrompt();
        }

        #endregion

        #region DATA RECORDER
        /// <summary>
        /// *****************************************************************
        /// method--H-- Data recorder under dev
        /// *****************************************************************
        /// </summary>
        static void DataRecorderDisplayMenuScreen(Finch Bobert)
        {
            DisplayScreenHeader("\tData recorder");
            Console.WriteLine();
            Console.WriteLine("\tModule is under development");
            Console.WriteLine();
            DisplayContinuePrompt();
        }
        #endregion

        #region ALARM SYSTEM

        /// <summary>
        /// *****************************************************************
        /// Mehtod--I--, ALARM SYSTEM under dev
        /// *****************************************************************
        /// </summary>
        static void AlarmSystemDisplayMenuScreen(Finch Bobert)
        {
            DisplayScreenHeader("Alarm System");
            Console.WriteLine();
            Console.WriteLine("\tModule is under development");
            Console.WriteLine();
            DisplayContinuePrompt();

        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *     Method--F-- Disconnect the Finch Robot                     
        /// *****************************************************************
        /// </summary>
        /// <param name="Bobert">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch Bobert)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("\tDisconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            Bobert.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnected.");

            DisplayMenuPrompt("\tMain Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *     Method--E-- Connect the Finch Robot                      
        /// *****************************************************************
        /// </summary>
        /// <param name="Bobert">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch Bobert)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = Bobert.connect();

            while (robotConnected)
            {
                Console.WriteLine("\twe found the robot!");
                Bobert.noteOn(880);
                Bobert.wait(1000);
                Bobert.noteOff();
                DisplayContinuePrompt();
                break;
            }
            if (!(robotConnected))
            {
                Console.WriteLine("\tThe robot got lost! try again!");
                DisplayContinuePrompt();
            }
            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            Bobert.setLED(0, 0, 0);
            Bobert.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *     Method--C--    Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();
            Console.WriteLine("\tWelcome to the finch robot or whatever. we will do stuff.");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *        Method--D-- Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt Method--A--
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header Method--B--
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
