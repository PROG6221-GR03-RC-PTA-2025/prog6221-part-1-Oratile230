using System;
using System.Collections.Generic;  // Importing for generic collections
using System.Speech.Synthesis;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        private static string userName;
        private static HashSet<string> interests = new HashSet<string>(); // Memory to store user's interests
        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        private static Dictionary<string, List<string>> keywordResponses; // Collection for keyword responses

        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            ConfigureSynthesizer();

            GenerateVoiceGreeting();

            ShowAsciiArt();
            GreetUser();
            InitializeKeywordResponses();
            ChatLoop();
        }

        // Configure SpeechSynthesizer
        static void ConfigureSynthesizer()
        {
            synth.Rate = 0;
            synth.Volume = 100;
        }

        // Generate voice greeting
        static void GenerateVoiceGreeting()
        {
            try
            {
                synth.Speak("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating audio: " + ex.Message);
            }
        }

        // Display ASCII Art
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

        // Greet user and ask for their name
        static void GreetUser()
        {
            Console.Write("\nWhat is your name? ");
            userName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.Write("Please enter a valid name: ");
                userName = Console.ReadLine();
            }

            DisplaySectionHeader("Welcome");
            TypeText($"Hello {userName}, welcome to the Cybersecurity Awareness Bot!");
            TypeText("I'm here to help you stay safe online.");
        }

        // Initialize keyword responses
        static void InitializeKeywordResponses()
        {
            keywordResponses = new Dictionary<string, List<string>>()
            {
                { "password", new List<string>
                    {
                        "Make sure to use strong, unique passwords for each account.",
                        "Avoid using personal information in your passwords.",
                        "Consider using a password manager to keep track of your passwords."
                    }},
                { "scam", new List<string>
                    {
                        "Always verify the source of unexpected messages.",
                        "Be careful of offers that seem too good to be true.",
                        "Report any suspicious emails or messages."
                    }},
                { "privacy", new List<string>
                    {
                        "Review your privacy settings on social media.",
                        "Be mindful of the information you share online.",
                        "Consider anonymizing your online presence."
                    }}
            };
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

                if (keywordResponses.ContainsKey(input))
                {
                    ProvideKeywordResponse(input); // Respond based on keywords
                }
                else
                {
                    HandleGeneralInquiry(input); // Handle general inquiries
                }

            } while (input != "exit");
        }

        // Provide responses based on recognized keywords
        static void ProvideKeywordResponse(string keyword)
        {
            Random rand = new Random();
            int index = rand.Next(keywordResponses[keyword].Count);
            TypeText(keywordResponses[keyword][index]);
        }

        // Handle general inquiries
        static void HandleGeneralInquiry(string input)
        {
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
                case "exit":
                    TypeText("Goodbye! Stay safe online.");
                    break;
                default:
                    TypeText("I didn't quite understand that. Could you rephrase?");
                    break;
            }
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
