namespace AirlineReservationConsoleSystem
{
    internal class Program
    {
        // ──────────────────────────────
        // Airline Reservation System Functions
        // ──────────────────────────────
        // 1. Arrays for Flights
        public static int maxFlights = 100;
        public static string[] flightCodes = new string[maxFlights];
        public static string[] fromCities = new string[maxFlights];
        public static string[] toCities = new string[maxFlights];
        public static DateTime[] departureTimes = new DateTime[maxFlights];
        public static int[] durations = new int[maxFlights];
        public static int flightCount = 0; // to track number of added flights
        // ──────────────────────────────
        // 2. Arrays for Bookings
        public static int maxBookings = 200;
        public static string[] passengerNames = new string[maxBookings];
        public static string[] bookingIDs = new string[maxBookings];
        public static int bookingCount = 0; // to track number of bookings
        // ──────────────────────────────


        // 1. Shows a stylized welcome screen
        public static void DisplayWelcomeMessage()
        {
            // Display airline logo or welcome message
            Console.WriteLine("Welcome to the Airline 🛩️ Reservation System!!! 🖐️ ");
        }

        // 2. Displays main menu options and returns user's choice
        public static int ShowMainMenu()
        {
            // Show options (Book, Cancel, View, Exit) and return selected number
            Console.WriteLine("1. Book a Flight");
            Console.WriteLine("2. Cancel a Flight");
            Console.WriteLine("3. View All Flights");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option (1-4): ");
            int choice = int.Parse(Console.ReadLine());
            // Validate choice and return
            if (choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return ShowMainMenu(); // Recursive call for valid input
            }
            else
            {
                Console.WriteLine($"You selected option {choice}.");
            }
            return choice;
        }

        // 3. Ends the program or loop with a thank-you message
        public static void ExitApplication()
        {
            // Print goodbye message and exit the system
            Console.WriteLine("Thank you for using the Airline 🛩️ Reservation System! Goodbye! 👋");
            return; // Exit the application
        }

        // 4. Adds a new flight using provided details (uses named parameters)
        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration)
        {
            // Check if flight list is full
            if (flightCount >= maxFlights)
            {
                Console.WriteLine("Cannot add more flights. Maximum capacity reached.");
                return;
            }
            // Add flight details to arrays
            flightCodes[flightCount] = flightCode;
            fromCities[flightCount] = fromCity;
            toCities[flightCount] = toCity;
            departureTimes[flightCount] = departureTime;
            durations[flightCount] = duration;
            flightCount++;
            Console.WriteLine($"Flight {flightCode} added successfully.");
            // Print flight details as a organized table
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"| Flight Code: {flightCodes[flightCount - 1],-10} | From: {fromCities[flightCount - 1],-10} | To: {toCities[flightCount - 1],-10} | Departure: {departureTimes[flightCount - 1].ToString("yyyy-MM-dd HH:mm"),-20} | Duration: {durations[flightCount - 1],-10} minutes |");
            Console.WriteLine("--------------------------------------------------");
            // If flight not added, add another flight or exit
            Console.Write("Do you want to add another flight? (y/n): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.Write("Enter flight code: ");
                string newFlightCode = Console.ReadLine();
                Console.Write("Enter from city: ");
                string newFromCity = Console.ReadLine();
                Console.Write("Enter to city: ");
                string newToCity = Console.ReadLine();
                Console.Write("Enter departure time (yyyy-mm-dd hh:mm): ");
                DateTime newDepartureTime = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter flight duration (in minutes): ");
                int newDuration = int.Parse(Console.ReadLine());
                AddFlight(newFlightCode, newFromCity, newToCity, newDepartureTime, newDuration); // Recursive call to add another flight
                // add the details to the array 
                flightCodes[flightCount] = newFlightCode;
                fromCities[flightCount] = newFromCity;
                toCities[flightCount] = newToCity;
                departureTimes[flightCount] = newDepartureTime;
                durations[flightCount] = newDuration;
                flightCount++;
                // Print flight details as a organized table
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"| Flight Code: {flightCodes[flightCount - 1],-10} | From: {fromCities[flightCount - 1],-10} | To: {toCities[flightCount - 1],-10} | Departure: {departureTimes[flightCount - 1].ToString("yyyy-MM-dd HH:mm"),-20} | Duration: {durations[flightCount - 1],-10} minutes |");
                Console.WriteLine("--------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Exiting flight addition.");
            }
        }

        // ──────────────────────────────
        // Flight and Passenger Management
        // ──────────────────────────────

        // 5. Prints all available flights to the console
        public static void DisplayAllFlights()
        {
            // Loop through flight list and print details
            Console.WriteLine("Available Flights:");
            for (int i = 0; i < flightCount; i++)
            {
                // Console.WriteLine($"Flight Code: {flightCodes[i]}, From: {fromCities[i]}, To: {toCities[i]}, Departure: {departureTimes[i].ToString("yyyy-MM-dd HH:mm")}, Duration: {durations[i]} minutes");
                // Print flight details in a formatted way
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"| Flight Code: {flightCodes[i],-10} | From: {fromCities[i],-10} | To: {toCities[i],-10} | Departure: {departureTimes[i].ToString("yyyy-MM-dd HH:mm"),-20} | Duration: {durations[i],-10} minutes |");
                Console.WriteLine("--------------------------------------------------");
            }
            // If no flights available, show message
            if (flightCount == 0)
            {
                Console.WriteLine("No flights available.");
            }
        }

        // 6. Searches for a flight by code and returns whether it exists
        public static bool FindFlightByCode(string code)
        {
            // Search flight list for match
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == code)
                {
                    Console.WriteLine($"Flight {code} found.");
                    return true; // Flight found
                }
            }
            Console.WriteLine($"Flight {code} not found.");
            // If flight not found, ask user to search again or exit
            Console.Write("Do you want to search again? (y/n): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.Write("Enter flight code to search: ");
                string newCode = Console.ReadLine();
                return FindFlightByCode(newCode); // Recursive call to search again
            }
            else
            {
                Console.WriteLine("Exiting flight search.");
                return false; // Exit without searching
            }
        }

        // 7. Updates the departure time of a flight (ref parameter lets us modify original)
        public static void UpdateFlightDeparture(ref DateTime departure)
        {
            // Ask user for new time and assign it to ref parameter
            Console.WriteLine("Enter new departure time (yyyy-mm-dd hh:mm): ");
            string input = DateTime.Parse(Console.ReadLine()).ToString("yyyy-MM-dd HH:mm");

            if ( input != null) // Check if input is not null
            {
                departure = DateTime.Parse(input);
                Console.WriteLine($"Departure time updated to {departure.ToString("yyyy-MM-dd HH:mm")}");
            }
            else
            {
                Console.WriteLine("Invalid input. Departure time not updated.");
            }
            // If input is null, do not update
            // Ask user if they want to search again or exit
            Console.Write("Do you want to search again? (y/n): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.Write("Enter new departure time (yyyy-mm-dd hh:mm): ");
                string newTime = Console.ReadLine();
                UpdateFlightDeparture(ref departure); // Recursive call to update again
            }
            else
            {
                Console.WriteLine("Exiting flight update.");
            }
        }

        // 8. Cancels a flight booking and returns passenger name via out
        public static void CancelFlightBooking(out string passengerName)
        {
            // Ask user for booking ID and find passenger name
            Console.WriteLine("Cancel Flight Booking");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Enter booking ID to cancel: ");
            string bookingID = Console.ReadLine();

            passengerName = ""; // Initialize out parameter

            // Check if booking ID is valid
            if (bookingID == null || bookingID.Length == 0) // Check for null or empty
            {
                Console.WriteLine("Invalid booking ID.");
                return;
            }
            // Loop through bookings to find matching ID
            for (int i = 0; i < bookingCount; i++)
            {
                if (bookingIDs[i] == bookingID)
                {
                    passengerName = passengerNames[i]; // Get passenger name
                    // Remove booking from arrays (shift elements left)
                    for (int j = i; j < bookingCount - 1; j++)
                    {
                        passengerNames[j] = passengerNames[j + 1];
                        bookingIDs[j] = bookingIDs[j + 1];
                    }
                    bookingCount--; // Decrease booking count
                    Console.WriteLine($"Booking {bookingID} canceled successfully.");
                    return;
                }
            }
            Console.WriteLine($"Booking ID {bookingID} not found.");
            // If booking ID not found, ask user to search again or exit
            Console.Write("Do you want to search again? (y/n): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.Write("Enter booking ID to search: ");
                string newID = Console.ReadLine();
                CancelFlightBooking(out passengerName); // Recursive call to search again
            }
            else
            {
                Console.WriteLine("Exiting booking cancellation.");
            }
        }

        // ──────────────────────────────
        // Passenger Booking Functions
        // ──────────────────────────────

        // 9. Books a flight for a passenger (uses optional flightCode)
        public static void BookFlight(string passengerName, string flightCode = "Default001")
        {
            // Check if booking list is full
            if (bookingCount >= maxBookings)
            {
                Console.WriteLine("Cannot book more flights. Maximum capacity reached.");
                return;
            }
            // Add passenger name and booking ID to arrays
            passengerNames[bookingCount] = passengerName;
            bookingIDs[bookingCount] = GenerateBookingID(passengerName);
            bookingCount++;
            Console.WriteLine($"Flight booked successfully for {passengerName} on flight {flightCode}.");

        }

        // 10. Checks if a flight code exists in the system
        public static bool ValidateFlightCode(string flightCode)
        {
            // Loop through flight codes and check for match
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == flightCode)
                {
                    Console.WriteLine($"Flight code {flightCode} is valid.");
                    return true; // Flight code is valid
                }
            }
            Console.WriteLine($"Flight code {flightCode} is invalid.");
            // Flight code is not valid, try again or exit
            Console.Write("Do you want to search again? (y/n): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.Write("Enter flight code to search: ");
                string newCode = Console.ReadLine();
                return ValidateFlightCode(newCode); // Recursive call to search again
            }
            else
            {
                Console.WriteLine("Exiting flight code validation.");
                return false; // Exit without validating
            }
        }

        // 11. Generates booking ID (e.g., Ahmed2025)
        public static string GenerateBookingID(string passengerName)
        {
            // Generate booking ID using passenger name and current year
            string bookingID = $"{passengerName}{DateTime.Now.Year}";
            // Check if booking ID already exists
            for (int i = 0; i < bookingCount; i++)
            {
                if (bookingIDs[i] == bookingID)
                {
                    Console.WriteLine($"Booking ID {bookingID} already exists. Generating a new one.");
                    // Generate a new booking ID by appending a random number
                    Random random = new Random();
                    int randomNumber = random.Next(1, 9999); // Random number between 1000 and 9999
                    bookingID = $"{passengerName}{DateTime.Now.Year}{randomNumber}";
                    break; // Exit loop after generating new ID
                }
            }
            return bookingID; // Return generated booking ID
        }

        // 12. Displays the full details of a flight using its code
        public static void DisplayFlightDetails(string code)
        {
            Console.WriteLine($"Details for flight code {code}:");
            // Loop through flight codes and display details
            for (int i = 0; i < flightCount; i++)
            {
                if (flightCodes[i] == code)
                {
                    // Print flight details as table
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine($"| Flight Code: {flightCodes[i],-10} | From: {fromCities[i],-10} | To: {toCities[i],-10} | Departure: {departureTimes[i].ToString("yyyy-MM-dd HH:mm"),-20} | Duration: {durations[i],-10} minutes |");
                    Console.WriteLine("--------------------------------------------------");
                    return; // Exit after displaying details
                }
            }
            Console.WriteLine($"Flight code {code} not found.");
            // If flight code not found, try again or exit
            Console.Write("Do you want to search again? (y/n): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.Write("Enter flight code to search: ");
                string newCode = Console.ReadLine();
                DisplayFlightDetails(newCode); // Recursive call to search again
            }
            else
            {
                Console.WriteLine("Exiting flight details view.");
            }
        }

        // 13. Filters and displays bookings to a certain destination
        public static void SearchBookingsByDestination(string toCity)
        {
            // Loop bookings and filter by destination
            Console.WriteLine($"Bookings to {toCity}:");
            for (int i = 0; i < bookingCount; i++)
            {
                // Check if booking matches destination
                for (int j = 0; j < flightCount; j++)
                {
                    if (toCities[j] == toCity && passengerNames[i] != null)
                    {
                        Console.WriteLine($"Booking ID: {bookingIDs[i]}, Passenger: {passengerNames[i]}");
                    }
                }
            }
            // If no bookings found, show message
            if (bookingCount == 0)
            {
                Console.WriteLine($"No bookings found to {toCity}.");
            }
            // Ask user if they want to search again or exit
            Console.Write("Do you want to search again? (y/n): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.Write("Enter destination city to search bookings: ");
                string newCity = Console.ReadLine();
                SearchBookingsByDestination(newCity); // Recursive call to search again
            }
            else
            {
                Console.WriteLine("Exiting booking search.");
            }
        }

        // ──────────────────────────────
        // Function Overloading
        // ──────────────────────────────

        // 14. Calculates total fare (basic version: integer price)
        public static int CalculateFare(int basePrice, int numTickets)
        {
            // Multiply base price by number of tickets
            return basePrice * numTickets;
        }

        // 15. Overloaded version using floating point price
        public static double CalculateFare(double basePrice, int numTickets)
        {
            // Multiply base price by number of tickets
            return basePrice * numTickets;
        }

        // 16. Overloaded version with discount applied
        public static int CalculateFare(int basePrice, int numTickets, int discount)
        {
            // Calculate total fare with discount
            int totalFare = basePrice * numTickets;
            int discountedFare = totalFare - (totalFare * discount / 100);
            return discountedFare; // Return discounted fare
        }

        // ──────────────────────────────
        // System Utilities & Final Flow
        // ──────────────────────────────

        // 17. Confirms a user action (e.g., cancel booking)
        public static bool ConfirmAction(string action)
        {
            // Ask user "Are you sure to [action]?" and return true/false
            Console.Write($"Are you sure to {action}? (y/n): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.WriteLine($"Action {action} confirmed.");
                return true; // Action confirmed
            }
            else
            {
                Console.WriteLine($"Action {action} canceled.");
                return false; // Action canceled
            }
        }

        // 18. Main function that runs the entire app loop
        public static void StartSystem()
        {
            // Show welcome, run menu, handle user input, call appropriate functions
            DisplayWelcomeMessage(); // Show welcome message
            while (true)
            {
                int choice = ShowMainMenu(); // Show main menu and get user choice
                switch (choice)
                {
                    case 1:
                        // Book a flight
                        Console.Write("Enter passenger name: ");
                        string passengerName = Console.ReadLine();
                        Console.Write("Enter flight code: ");
                        string flightCode = Console.ReadLine();
                        BookFlight(passengerName, flightCode); // Call book flight function
                        break;
                    case 2:
                        // Cancel a flight
                        CancelFlightBooking(out string canceledPassengerName); // Call cancel booking function
                        break;
                    case 3:
                        // View all flights
                        DisplayAllFlights(); // Call display flights function
                        break;
                    case 4:
                        // Exit the application
                        ExitApplication(); // Call exit function
                        return; // Exit the loop and application
                    default:
                        Console.WriteLine("Invalid choice. Please try again."); // Handle invalid choice
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            // Start the airline reservation system
            StartSystem();

        }
    }
}
