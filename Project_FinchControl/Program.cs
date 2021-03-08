using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;
using System.Linq;

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

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                Bobert.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                Bobert.noteOn(lightSoundLevel * 100);
            }

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

            for (int x = 0; x < 255; x = x + 15)
            {
                Bobert.setLED(x, 0, x);
                Bobert.wait(100);
            }

            DisplayContinuePrompt();
            Bobert.setLED(0, 0, 0);

            Bobert.noteOn(9001);
            Bobert.wait(100);
            Bobert.noteOff();
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
            Bobert.setMotors(250, 250);
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
            Bobert.setLED(100, 00, 00);
            Bobert.wait(250);
            Bobert.noteOff();
            Bobert.setLED(0, 0, 0);
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

                if ((userResponse != "yes") && (userResponse != "no"))
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
            Console.CursorVisible = true;
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;
            double[] Lights = null;
            bool quitDataRecorderMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("\tData recorder Menu");

                DisplayContinuePrompt();
                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of data Points");
                Console.WriteLine("\tb) Frequency of data points");
                Console.WriteLine("\tc) Get Temp Data");
                Console.WriteLine("\td) Show Temp Data");
                Console.WriteLine("\te) Get Light Data");
                Console.WriteLine("\tf) Show Light Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetTempData(numberOfDataPoints, dataPointFrequency, Bobert);
                        break;

                    case "d":
                        DataRecorderDisplayTempData(temperatures);
                        break;

                    case "e":
                        Lights = DataRecorderDisplayGetLight(numberOfDataPoints, dataPointFrequency, Bobert);
                        break;

                    case "f":
                        DataRecorderDisplayLightData(Lights);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);
        }



        static void DataRecorderDisplayDataTable(double[] temperatures)
        {
            Console.WriteLine(
                    "reading #".PadLeft(20) +
                    "Temperature".PadLeft(15)
                    );

            Console.WriteLine(
                "---------".PadLeft(20) +
                "-----------".PadLeft(15)

                );

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString().PadLeft(20) +
                   (temperatures[index]).ToString("n1").PadLeft(15)
                    );
            }

        }
        static void DataRecorderDisplayLightDataTable(double[] Lights)
        {
            Console.WriteLine(
                    "reading #".PadLeft(20) +
                    "Level".PadLeft(15)
                    );

            Console.WriteLine(
                "---------".PadLeft(20) +
                "-----------".PadLeft(15)

                );

            for (int index = 0; index < Lights.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString().PadLeft(20) +
                   (Lights[index]).ToString("n1").PadLeft(15)
                    );
            }

        }



        static int ValidateInteger(string prompt, int minimum, int maximum)
        {
            bool validResponse;
            int numberEntered;

            do
            {
                validResponse = true;

                Console.Write($"\t{prompt} ");

                if (!int.TryParse(Console.ReadLine(), out numberEntered))
                {
                    Console.WriteLine("\tPlease enter a valid number");
                    DisplayContinuePrompt();
                    validResponse = false;
                }
                else if (numberEntered < minimum || numberEntered > maximum)
                {
                    Console.WriteLine($"\tPlease enter a number between {minimum} and {maximum}");
                    DisplayContinuePrompt();
                    validResponse = false;
                }

            } while (!validResponse);

            return numberEntered;
        }

        static void DataRecorderDisplayTempData(double[] temperatures)
        {
            DisplayScreenHeader("ORIGINAL Temperatures");
            DataRecorderDisplayDataTable(temperatures);

            Console.WriteLine("\tsorted temperatures from lowest to highest");
            Array.Sort(temperatures);

            Console.WriteLine();

            Console.WriteLine("\tThe temp values listed in order are:");
            foreach (double index in temperatures)
            {
                Console.Write("\t " + index.ToString("n2") + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"cumulative recorded temperatures:b {temperatures.Sum().ToString("n2")} ");
            Console.WriteLine();
            Console.WriteLine($" average temperature was {temperatures.Average().ToString("n2")}");

            DisplayContinuePrompt();

        }

        static void DataRecorderDisplayLightData(double[] Lights)
        {
            DisplayScreenHeader("Light levels");
            DataRecorderDisplayLightDataTable(Lights);
            Console.WriteLine();
            Console.WriteLine("\tsorted light levels from lowest to highest");
            Array.Sort(Lights);

            Console.WriteLine();

            Console.WriteLine("\tThe light values listed in order are:");
            foreach (double index in Lights)
            {
                Console.Write("\t " + index.ToString("n2") + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"cumulative recorded Light:b {Lights.Sum().ToString("n2")} ");
            Console.WriteLine();
            Console.WriteLine($" average Light was {Lights.Average().ToString("n2")}");

            DisplayContinuePrompt();

        }

        static double[] DataRecorderDisplayGetLight(int numberOfDataPoints, double dataPointFrequency, Finch bobert)
        {
            double[] Lights = new double[numberOfDataPoints];

            int datapointfrequncsMS;
            // convert sec to MS

            datapointfrequncsMS = (int)(dataPointFrequency * 1000);
            DisplayScreenHeader("Light levels");

            //echo values 
            Console.WriteLine($"\t the finch robot will now record {numberOfDataPoints}Lights {dataPointFrequency} seconds apart.");
            Console.WriteLine("press any key to begin");
            Console.ReadKey();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                Lights[index] = bobert.getLeftLightSensor();

                Console.WriteLine($"\t Lights {index + 1}: {Lights[index]:n1}");
                bobert.wait(datapointfrequncsMS);

            }

            //
            //
            //display table of light 
            DataRecorderDisplayLightDataTable(Lights);

            DisplayMenuPrompt("Data Recorder Menu");

            return Lights;
        }

        /// <summary>
        /// get temperatures from robot
        /// </summary>
        /// <param name="numberOfDataPoints">number of data points</param>
        /// <param name="dataPointFrequency">data point frequnecy</param>
        /// <param name="bobert">finch robot object</param>
        /// <returns>Temperatures</returns>
        static double[] DataRecorderDisplayGetTempData(int numberOfDataPoints, double dataPointFrequency, Finch bobert)
        {
            double[] temperatures = new double[numberOfDataPoints];
            int[] conversion = new int[numberOfDataPoints];
            int datapointfrequncsMS;
            // convert sec to MS

            datapointfrequncsMS = (int)(dataPointFrequency * 1000);
            DisplayScreenHeader("temperatures");

            //echo values 
            Console.WriteLine($"\t the finch robot will now record {numberOfDataPoints} temperatures, {dataPointFrequency} seconds apart.");
            Console.WriteLine("\tpress any key to begin");
            Console.ReadKey();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = bobert.getTemperature();


                // echo new temp // F and Celcius**************************

                Console.WriteLine($"\t temperature {index + 1}: {temperatures[index]:n1}");
                bobert.wait(datapointfrequncsMS);
                conversion[index] = ConvertCelciusToFarenheit(temperatures[index]);
                Console.WriteLine($"\t {conversion[index]:n1} degrees farenheit");
            }

            //
            //
            //display table of temp 
            DataRecorderDisplayDataTable(temperatures);

            DisplayMenuPrompt("Data Recorder Menu");

            return temperatures;
        }

        static int ConvertCelciusToFarenheit(double temperatures)
        {
            return (int)(temperatures * 1.8 + 32);
        }

        /// <summary>
        /// get frequncy of data points
        /// </summary>
        /// <returns>frequency of data points</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;

            DisplayScreenHeader("Data Point Frequency");
            Console.WriteLine();

            dataPointFrequency = ValidateInteger("please enter desired frequency of data capture:", 0, 60);
            Console.WriteLine();
            Console.WriteLine($"\t you chose {dataPointFrequency} seconds as the frequency of data points.");
            DisplayMenuPrompt("DataRecoder");

            return dataPointFrequency;
        }

        /// <summary>
        /// get number of data points
        /// </summary>
        /// <returns>number of data points</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;

            DisplayScreenHeader("Number of Data Points");
            Console.Write("\tEnter the desired number of data points:");
            Console.WriteLine();

            numberOfDataPoints = ValidateInteger("\t Desired Number of data points:", 0, 20);
            //Vaalidate the number

            Console.WriteLine();
            Console.WriteLine($"\t you chose {numberOfDataPoints} as the number of data points.");
            DisplayMenuPrompt("DataRecoder");

            return numberOfDataPoints;
        }

        #endregion

        #region ALARM SYSTEM

        /// <summary>
        /// *****************************************************************
        /// Mehtod--I--, ALARM SYSTEM under dev alarm:a
        /// *****************************************************************
        /// </summary>
        static void AlarmSystemDisplayMenuScreen(Finch Bobert)
        {
            //ii
            DisplayScreenHeader("Alarm System");


            Console.CursorVisible = true;
            
            //i
            bool quitAlarmMenu = false;
            string menuChoice;

            string SensorsToMonitor = "";
            string rangetype = "";
            int minMaxThresholdValue = 0;
            int tempMinMaxThresholdValue = 0;
            int timeToMonitor = 0;


            //iii
            do
            {
                DisplayScreenHeader("Alarm Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set range type");
                Console.WriteLine("\tc) Set light min/max threshold value");
                Console.WriteLine("\td) Set temperature threshold");
                Console.WriteLine("\te) Set time to monitor ");
                Console.WriteLine("\tf) Set Alarm");               
                Console.WriteLine("\tq) Quit alarm menu");

                //
                // validate user choice
                //
                Console.WriteLine("\tplease enter menu choice after pressing any key to continue...");
                Console.ReadKey();
                menuChoice = validateStringInput("\t\tEnter Choice:" +
                    "\na) Set Sensors to Monitor," +
                    "\nb) Set range type," +
                    "\nc) Set light min/max threshold value, " +
                    "\nd) Set temperature threshold," +
                    "\ne) Set time to monitor " +
                    "\nf) Set Alarm" +
                    "\nq) Quit alarm menu\t"



                    , "pick a letter: a, b, c, d, e, f, or q.", 
                    new string[] { "a", "b", "c", "d", "e", "f", "q" });
                

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        SensorsToMonitor = AlarmSystemDisplaySetLightSensors();
                        break;

                    case "b":
                        rangetype = AlarmSystemDisplaySetRangeType();
                        break;

                    case "c":
                        minMaxThresholdValue = AlarmSystemDisplayLightThresholdValue(SensorsToMonitor, Bobert);                        
                        break;
                    
                    case "d":
                        tempMinMaxThresholdValue = AlarmSystemDisplayTempThresholdValue(SensorsToMonitor, Bobert);
                      break;

                    case "e":
                        timeToMonitor = AlarmSystemDisplayTimeToMonitor();
                        break;

                    case "f":
                        AlarmSystemDisplaySetAlarm(Bobert, SensorsToMonitor, rangetype, minMaxThresholdValue, tempMinMaxThresholdValue, timeToMonitor);
                        break;                   

                    case "q":
                        quitAlarmMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitAlarmMenu);
        }

        static void AlarmSystemDisplaySetAlarm(
            Finch bobert,
            string sensorsToMonitor,
            string rangetype,
            int minMaxThresholdValue,
            int tempMinMaxThresholdValue,
            int timeToMonitor
            )

        {



            int secondsElapsed = 1;
            bool thresholdExceded = false;
            int leftLightSensortValue;
            int rightLightSensorValue;
            int currentTemperatureValue;
            DisplayScreenHeader("Set Alarm");
            //echo values to user

            Console.WriteLine("\t Press a key to Start");

            //Prompt user to start
            Console.ReadKey();
            

            do
            {
                //
                //get  current light lvl
                //

                leftLightSensortValue = bobert.getLeftLightSensor();
                rightLightSensorValue = bobert.getRightLightSensor();
                currentTemperatureValue = (int)bobert.getTemperature();
                switch (sensorsToMonitor)
                {
                    case "left light":
                        Console.WriteLine($"\tcurrent left light value: {leftLightSensortValue}");
                        break;

                    case "right light":
                        Console.WriteLine($"\tcurrent right light value: {rightLightSensorValue}");
                        break;

                    case "both lights":
                        Console.WriteLine($"\tcurrent left light value: {leftLightSensortValue}");
                        Console.WriteLine($"\tcurrent right light value: {rightLightSensorValue}");
                        break;
                    case "temperature":
                        Console.WriteLine($"\tcurrent temp: {currentTemperatureValue} celcius. ");
                        break;
                    
                    case "all":
                        Console.WriteLine($"\tcurrent temp: {currentTemperatureValue} celcius. ");
                        Console.WriteLine($"\tcurrent left light value: {leftLightSensortValue}");
                        Console.WriteLine($"\tcurrent right light value: {rightLightSensorValue}");
                        break;
                    default:
                        Console.WriteLine("\tUnkown Sensor Reference");
                        break;
                }
                //wait 1
                bobert.wait(1000);
                secondsElapsed++;

                //test for threshold exceeded
                switch (sensorsToMonitor)
                {
                    case "left light":
                        if (rangetype == "minimum")
                        {
                            thresholdExceded = (leftLightSensortValue < minMaxThresholdValue);
                        }
                        else //max
                        {
                            thresholdExceded = (leftLightSensortValue > minMaxThresholdValue);
                        }
                        break;

                    case "right light":
                        if (rangetype == "minimum")
                        {
                            if (rightLightSensorValue < minMaxThresholdValue)
                            {
                                thresholdExceded = true;
                            }

                        }
                        else //max
                        {
                            if (rightLightSensorValue > minMaxThresholdValue)
                            {
                                thresholdExceded = true;
                            }
                        }
                        break;

                    case "both lights":
                        if (rangetype == "minimum")
                        {
                            if ((leftLightSensortValue < minMaxThresholdValue) || (rightLightSensorValue < minMaxThresholdValue))
                            {
                                thresholdExceded = true;
                            }
                        }
                        else //max
                        {
                            if ((leftLightSensortValue > minMaxThresholdValue) || (rightLightSensorValue > minMaxThresholdValue))
                            {
                                thresholdExceded = true;
                            }
                        }
                        break;
                    case "temperature":
                        if (rangetype == "minimum")
                        {
                            if (currentTemperatureValue < tempMinMaxThresholdValue)
                            {
                                thresholdExceded = true;
                            }
                        }

                        else //maximum
                        {
                            if (currentTemperatureValue > tempMinMaxThresholdValue)
                            {
                                thresholdExceded = true;
                            }
                        }
                        break;

                    case "all":
                        if (rangetype == "minimum")
                        {
                            if ((currentTemperatureValue < tempMinMaxThresholdValue) || (leftLightSensortValue < minMaxThresholdValue) || (rightLightSensorValue < minMaxThresholdValue))
                            {
                                thresholdExceded = true;
                            }
                        }

                        else //maximum
                        {
                            if ((currentTemperatureValue > tempMinMaxThresholdValue) || (leftLightSensortValue > minMaxThresholdValue) || (rightLightSensorValue > minMaxThresholdValue))
                            {
                                thresholdExceded = true;
                            }
                        }
                        break;
                    
                    default:
                        Console.WriteLine("\tUnkown Sensor Reference");
                        break;
                }

            } while (!thresholdExceded && (secondsElapsed <= timeToMonitor));

            if (thresholdExceded)
            {
                Console.WriteLine("exceeded");
            }

            else
            {
                Console.WriteLine("threshold not exceeded, time expired");
            }



            DisplayMenuPrompt("Alarm System");

        }

       

        static int AlarmSystemDisplayTimeToMonitor()
        {
            int timeToMonitor = 0;

            DisplayScreenHeader("Time To Monitor");

            Console.Write("\tEnter Time To Monitor");
            //validate and echo
            timeToMonitor = ValidateInteger("\tEnter Time To Monitor", 1, 60);

            Console.WriteLine($"\tTime to monitor {timeToMonitor} seconds. ");

            DisplayMenuPrompt("Alarm System");
            return timeToMonitor;
        }
        static int AlarmSystemDisplayTempThresholdValue(string sensorsToMonitor, Finch Bobert)
        {
            DisplayScreenHeader("Threshold Value");
            int tempThresholdValue = 0;
            int currentTemperatureValue = (int)Bobert.getTemperature();
            switch (sensorsToMonitor.ToLower())
            {
                case "left light":
                    Console.WriteLine("\t Please use the previous menu, case 'c' to set the light threshold value.");
                    break;

                case "right light":
                    Console.WriteLine("\t Please use the previous menu, case 'c' to set the light threshold value.");
                    break;

                case "both lights":
                    Console.WriteLine("\t Please use the previous menu, case 'c' to set the light threshold values.");

                    break;

                case "temperature":
                    Console.WriteLine($"\tCurrent ambient temperature: {currentTemperatureValue} degrees celcius.");
                    break;

                case "all":
                    Console.WriteLine("\t Please use the previous menu, case 'c' to set the temperature threshold value.");
                    Console.WriteLine();
                    Console.WriteLine($"\tCurrent ambient temperature: {currentTemperatureValue} degrees celcius.");
                    break;

                default:
                    Console.WriteLine("\tUnkown Sensor Reference.");
                    break;


            }
            // collect user inpout and validate
            tempThresholdValue = ValidateInteger("\tEnter Threshold value for temperature: ", 0, 40);

            //echo
            Console.WriteLine($"\tUser defined temp threshold: {tempThresholdValue}");

            DisplayMenuPrompt("Alarm System");
            return tempThresholdValue;
        }


        static int AlarmSystemDisplayLightThresholdValue(string sensorsToMonitor, Finch Bobert)
        {
            int lightThresholdValue = 0;
            
            int currentLeftSensorValue = Bobert.getLeftLightSensor();
            int currentRightSensorValue = Bobert.getRightLightSensor();
            int currentTemperatureValue = (int)Bobert.getTemperature();
            
            DisplayScreenHeader("Threshold Value");
            //display ambient, 1 hour 5 minutes or so into lecture

            switch (sensorsToMonitor.ToLower())
            {
                case "left light":
                    Console.WriteLine($"\tCurrent {sensorsToMonitor} sensor value: {currentLeftSensorValue} ");
                    break;

                case "right light":
                    Console.WriteLine($"\tCurrent {sensorsToMonitor} sensor value: {currentRightSensorValue} ");
                    break;

                case "both lights":
                    Console.WriteLine($"\tCurrent left sensor value: {currentLeftSensorValue} ");
                    Console.WriteLine($"\tCurrent right sensor value: {currentRightSensorValue} ");
                    break;

                case "temperature":
                    Console.WriteLine($"\tCurrent ambient temperature: {currentTemperatureValue} degrees celcius.");
                    Console.WriteLine("\t Please use the previous menu, case 'd' to set the temp threshold value");
                    break;

                case "all":
                    Console.WriteLine($"\tCurrent left sensor value: {currentLeftSensorValue} ");
                    Console.WriteLine($"\tCurrent right sensor value: {currentRightSensorValue} ");
                    Console.WriteLine($"\tCurrent ambient temperature: {currentTemperatureValue} degrees celcius.");
                    Console.WriteLine("\t Please use the previous menu, case 'd' to set the temp threshold value");
                    break;

                default:
                    Console.WriteLine("\tUnkown Sensor Reference");
                    break;
            }

            // collect user inpout and validate
            lightThresholdValue = ValidateInteger("\tEnter Threshold value for lights: ", 0, 255);

            //echo
            Console.WriteLine($"\tUser defined light threshold: {lightThresholdValue}" );
            DisplayMenuPrompt("Alarm System");
            return lightThresholdValue;
            
        }

        static string AlarmSystemDisplaySetRangeType()
        {
            string rangeType = "";            
            DisplayScreenHeader("Range Type");
            
            //validate
            DisplayScreenHeader("Set range type");

            rangeType = validateStringInput("\tSet the range type[minimum, maximum]", "minimum or maximum please",
                new string[] { "minimum", "maximum" });

            Console.WriteLine($"You have chosen:{rangeType}");
            DisplayMenuPrompt("Alarm system");
            
            return rangeType;
        }

        static string AlarmSystemDisplaySetLightSensors()
        {
            string SensorsToMonitor = "";
            
            DisplayScreenHeader("\tSensors To Monitor");
            //validate
            SensorsToMonitor = validateStringInput(
                "\tEnter sensors to Monitor[left light, right light, both lights, temperature, all]",
                "left light, right light, temperature, all, or both lights please",
                new string[] { "left light", "right light", "both lights", "all", "temperature" }
                );

            Console.WriteLine($"You have chosen:{SensorsToMonitor}");
            
            DisplayMenuPrompt("Alarm system");

            return SensorsToMonitor;
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

            //validfate connection, play light and sound, or say no connection;

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


        static string validateStringInput(string prompt, string error, string[] validInputs)
        {
            // credit goes to jp from the online class for helping me with this

            bool validInput = false;
            string userinput = "";
            int index = 0;

            while (!validInput)
            {
                //display prompt
                Console.Clear();
                Console.Write(prompt);
                userinput = Console.ReadLine();

                //check if input is valid
                for (index = 0; index < validInputs.Length; index++)
                {
                    if (validInputs[index].ToLower() == userinput.ToLower())
                    {
                        validInput = true;
                        break;
                    }
                }
                //if a valid input is not found display an error message
                if (!validInput)
                {
                    Console.WriteLine("\n{0}", error);
                    Console.WriteLine("press any key to continue");
                    Console.ReadKey();
                }
            }
            return validInputs[index];
        }


        #endregion
    }

}
