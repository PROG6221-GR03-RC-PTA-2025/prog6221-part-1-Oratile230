using System;
using System.Speech.Synthesis; // Added for speech synthesis
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            GenerateVoiceGreeting(); // Directly generate and speak greeting

            ShowAsciiArt();
            GreetUser();
            ChatLoop();
        }

        // Generate voice greeting using SpeechSynthesizer and speak it directly
        static void GenerateVoiceGreeting()
        {
            try
            {
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    // Configure the synthesizer (Optional: Choose voice and rate)
                    synth.Rate = 0; // Set speech rate (normal)
                    synth.Volume = 100; // Set speech volume (100 is the max)

                    // Speak greeting directly without saving it as a .wav file
                    synth.Speak("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating audio: " + ex.Message);
            }
        }

        // ASCII Art
        static void ShowAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string asciiLogo = @"
  ____ _                   _       _                   _            
 / ___| |_   _  ___ _ __ __| | __ _| |_ __ _ _ __   __| | ___ _ __ 
| |   | | | | |/ _ \ '__/ _` |/ _` | __/ _` | '_ \ / _` |/ _ \ '__|
| |___| | |_| |  __/ | | (_| | (_| | || (_| | | | | (_| |  __/ |   
 \____|_|\__,_|\___|_|  \__,_|\__,_|\__\__,_|_| |_|\__,_|\___|_|   
                                                                  
";
            Console.WriteLine(asciiLogo);
            Console.ResetColor();
        }


        // User interaction
        static void GreetUser()
        {
            Console.Write("\nWhat is your name? ");
            string userName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.Write("Please enter a valid name: ");
                userName = Console.ReadLine();
            }

            DisplaySectionHeader("Welcome");
            TypeText($"Hello {userName}, welcome to the Cybersecurity Awareness Bot!");
            TypeText("I'm here to help you stay safe online.");
        }

        // Main chatbot loop
        static void ChatLoop()
        {
            string input;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nAsk me something (type 'exit' to quit): ");
                Console.ResetColor();

                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "how are you?":
                        TypeText("I'm secure and ready to help you stay safe online!");
                        break;
                    case "what's your purpose?":
                        TypeText("I'm here to educate you about cybersecurity.");
                        break;
                    case "what can i ask you about?":
                        TypeText("You can ask about password safety, phishing, and safe browsing.");
                        break;
                    case "password safety":
                        TypeText("Use strong, unique passwords and enable two-factor authentication.");
                        break;
                    case "phishing":
                        TypeText("Be cautious of emails asking for sensitive info. Always verify the source.");
                        break;
                    case "safe browsing":
                        TypeText("Keep your software updated and avoid clicking suspicious links.");
                        break;
                    case "exit":
                        TypeText("Goodbye! Stay safe online.");
                        break;
                    default:
                        TypeText("I didn't quite understand that. Could you rephrase?");
                        break;
                }

            } while (input != "exit");
        }

        // Typing effect
        static void TypeText(string text, int delay = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        // Decorative headers
        static void DisplaySectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===============================");
            Console.WriteLine($"        {title.ToUpper()}");
            Console.WriteLine("===============================");
            Console.ResetColor();
        }
    }
}