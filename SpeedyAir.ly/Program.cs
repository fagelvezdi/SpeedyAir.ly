using SpeedyAir.ly;

// USER STORY #1

// Created a Dictionary to keep the flights info.
Dictionary<int, string> dicFlights = new()
{
    { 1, "YYZ" },
    { 2, "YYC" },
    { 3, "YVR" },
    { 4, "YYZ" },
    { 5, "YYC" },
    { 6, "YVR" }
};

Console.WriteLine("USER STORY #1:");

int day = 1;
foreach (var flight in dicFlights)
{
    day = 1;
    // flights 4,5,6 are scheduled to fly on day 2
    if (flight.Key > 3)
    {
        day = 2;
    }

    Console.WriteLine($"Flight: {flight.Key}, departure: YUL, arrival: {flight.Value}, day: {day}");
    Console.WriteLine($"Flight: {flight.Key}, departure: {flight.Value}, arrival: YUL, day: {day + 1}");
}

Console.WriteLine();
Console.WriteLine();

// USER STORY #2
// Loading the orders from the json file.
var dicOrders = ReadOrders.GetOrders();

// initialize counters
day = 1;
int boxesToYYZ = 0, boxesToYYC = 0, boxesToYVR = 0;
int currentBoxesInFlight1 = 0, currentBoxesInFlight2 = 0, currentBoxesInFlight3 = 0;
int currentBoxesInFlight4 = 0, currentBoxesInFlight5 = 0, currentBoxesInFlight6 = 0;

// Iterate through the 99 orders
for (int i = 1; i <= 99; i++)
{
    // Parse the order number to search in the dictionary
    var orderNumber = $"order-{i.ToString().PadLeft(3, '0')}";

    // If the order is not contained in the dictionary, is not scheduled.
    if (dicOrders.ContainsKey(orderNumber))
    {
        // Verify the destination to load the airplane with the order.

        int flightNumber = 1;
        switch (dicOrders[orderNumber])
        {
            case "YYZ":
                boxesToYYZ++;
                // A plane can't be loaded with more than 20 boxes, in that case the order is not scheduled.
                if (boxesToYYZ <= 20)
                {
                    day = 1;
                    flightNumber = 1;
                    currentBoxesInFlight1++;
                }
                else
                {
                    day = 2;
                    flightNumber = 4;
                    currentBoxesInFlight4++;
                    if (currentBoxesInFlight4 > 20)
                    {
                        Console.WriteLine($"order: {orderNumber}, flightNumber: not scheduled");
                        break;
                    }
                }
                Console.WriteLine($"order: {orderNumber}, flightNumber: {flightNumber}, departure: YUL, arrival: {dicOrders[orderNumber]}, day: {day}");
                
                break;
            case "YYC":
                boxesToYYC++;
                if (boxesToYYC <= 20)
                {
                    day = 1;
                    flightNumber = 2;
                    currentBoxesInFlight2++;
                }
                else
                {
                    day = 2;
                    flightNumber = 5;
                    currentBoxesInFlight5++;
                    if (currentBoxesInFlight5 > 20)
                    {
                        Console.WriteLine($"order: {orderNumber}, flightNumber: not scheduled");
                        break;
                    }
                }
                Console.WriteLine($"order: {orderNumber}, flightNumber: {flightNumber}, departure: YUL, arrival: {dicOrders[orderNumber]}, day: {day}");
                
                break;
            case "YVR":
                boxesToYVR++;

                if (boxesToYVR <= 20)
                {
                    day = 1;
                    flightNumber = 3;
                    currentBoxesInFlight3++;
                }
                else
                {
                    day = 2;
                    flightNumber = 6;
                    currentBoxesInFlight6++;
                    if (currentBoxesInFlight6 > 20)
                    {
                        Console.WriteLine($"order: {orderNumber}, flightNumber: not scheduled");
                        break;
                    }
                    
                }
                Console.WriteLine($"order: {orderNumber}, flightNumber: {flightNumber}, departure: YUL, arrival: {dicOrders[orderNumber]}, day: {day}");
                
                break;

            default:
                Console.WriteLine($"order: {orderNumber}, flightNumber: not scheduled");
                break;
        }
    }
    else
    {
        Console.WriteLine($"order: {orderNumber}, flightNumber: not scheduled");
    }
}

Console.ReadKey();
