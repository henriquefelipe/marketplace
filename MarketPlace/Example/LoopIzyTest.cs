using LoopIzy.Service;
using System;
using System.Linq;

namespace Example
{
    public class LoopIzyTest
    {
        private const string TOKEN = "YOUR_TEST_TOKEN_HERE";
        private const string CPF = "00000000000";

        public void RunTest()
        {
            try
            {
                var service = new LoopIzyService(TOKEN);
                
                Console.WriteLine("Searching for customer...");
                var customerResult = service.GetCustomers(cpf: CPF);
                if (customerResult.Success && customerResult.Result.Customers != null && customerResult.Result.Customers.Any())
                {
                    var customer = customerResult.Result.Customers.First();
                    Console.WriteLine($"Customer found: {customer.Name}");
                    Console.WriteLine($"Points balance: {customer.PointsBalance}");

                    Console.WriteLine("Fetching cashback credits...");
                    var cashbackResult = service.GetCashback(customerId: customer.Id);
                    if (cashbackResult.Success && cashbackResult.Result.Credits != null)
                    {
                        Console.WriteLine($"Found {cashbackResult.Result.Credits.Count} cashback credits.");
                        foreach (var credit in cashbackResult.Result.Credits)
                        {
                            Console.WriteLine($"- Code: {credit.Code}, Value: {credit.CreditValue}, Status: {credit.Status}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error fetching cashback credits: {cashbackResult.Message}");
                    }

                    Console.WriteLine("Fetching rewards...");
                    var rewardsResult = service.GetRewards(true);
                    if (rewardsResult.Success && rewardsResult.Result.Rewards != null)
                    {
                        Console.WriteLine($"Found {rewardsResult.Result.Rewards.Count} rewards.");
                        foreach (var reward in rewardsResult.Result.Rewards)
                        {
                            Console.WriteLine($"- {reward.Name} ({reward.PointsCost} points)");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error fetching rewards: {rewardsResult.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Customer not found or error: {customerResult.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
