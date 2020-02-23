using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();
            FriendHandler friendHandler = new FriendHandler(users);

            friendHandler.GetMinimumDistance("Alec Hillary", "Karleigh Winifred");

            friendHandler.GetFriendsByDistance("Alec Hillary", 3);

            Console.WriteLine("\nDone");
            Console.ReadKey();
        }
    }
}
