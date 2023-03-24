using Newtonsoft.Json.Linq;

namespace SpeedyAir.ly
{
    public static class ReadOrders
    {
        public static Dictionary<string,string> GetOrders()
        {
            // Read the file
            string fileName = "../../../Resources/coding-assigment-orders.json";
            string jsonStringOrders = File.ReadAllText(fileName);

            // Parse JSON string with the orders and grab it's children to get detailed info. 
            var jsonData = JObject.Parse(jsonStringOrders).Children();
            List<JToken> orders = jsonData.Children().ToList();

            Dictionary<string, string> completeOrders = new();

            // Populate a dictionary with the orders info
            foreach (JToken order in orders)
            {
                string orderName = order.Path.ToString();
                string destination = order.First.First.ToString();
                completeOrders.Add(orderName, destination);
            }

            return completeOrders;
        }
    }
}
