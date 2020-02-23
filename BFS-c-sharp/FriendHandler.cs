using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp
{
    class FriendHandler
    {
        private readonly List<UserNode> _users;

        public FriendHandler(List<UserNode> users)
        {
            _users = users;
        }

        public void GetMinimumDistance(String userNameA, String userNameB)
        {
            int dist;
            UserNode userA = GetUserByName(userNameA);
            UserNode userB = GetUserByName(userNameB);

            dist = GetDistanceByBreadthSearch(userA, userB);

            Console.WriteLine(dist);
        }

        private int GetDistanceByBreadthSearch(UserNode userA, UserNode userB)
        {
            int depth = 0;

            Queue<UserNode> friends = new Queue<UserNode>();
            HashSet<UserNode> friendsChecked = new HashSet<UserNode>();
            var root = userA;
            int friendsCountOnLevel = 1;
            int friendsCountOnNextLevel = 0;

            while (root != userB)
            {
                if (!friendsChecked.Contains(root))
                {
                    if (friendsCountOnLevel != 0)
                    {
                        friendsCountOnLevel--;
                    }

                    foreach (var friend in root.Friends)
                    {
                        if(friend != root && !friendsChecked.Contains(friend))
                        {
                            friends.Enqueue(friend);
                            friendsCountOnNextLevel++;
                        }
                    }
                    friendsChecked.Add(root);

                    if (friendsCountOnLevel == 0)
                    {
                        depth++;
                        friendsCountOnLevel = friendsCountOnNextLevel;
                        friendsCountOnNextLevel = 0;
                    }
                }
                root = friends.Dequeue();
            }

            return depth;
        }

        public void GetFriendsByDistance(string username, int distance)
        {
            UserNode user = GetUserByName(username);
            int depth = 0;

            Queue<UserNode> friends = new Queue<UserNode>();
            HashSet<UserNode> friendsChecked = new HashSet<UserNode>();
            var root = user;
            int friendsCountOnLevel = 1;
            int friendsCountOnNextLevel = 0;

            while (depth <= distance)
            {
                if (!friendsChecked.Contains(root))
                {
                    if (friendsCountOnLevel != 0)
                    {
                        friendsCountOnLevel--;
                    }

                    foreach (var friend in root.Friends)
                    {
                        if (friend != root && !friendsChecked.Contains(friend))
                        {
                            friends.Enqueue(friend);
                            friendsCountOnNextLevel++;
                        }
                    }
                    friendsChecked.Add(root);

                    if (friendsCountOnLevel == 0)
                    {
                        depth++;
                        friendsCountOnLevel = friendsCountOnNextLevel;
                        friendsCountOnNextLevel = 0;
                    }
                }
                root = friends.Dequeue();
            }

            friendsChecked.Remove(user);

            foreach (var friend in friendsChecked)
            {
                Console.WriteLine(friend);
            }
        }

        public UserNode GetUserByName(String userName)
        {
            string[] name = userName.Split(' ');
            string firstName = name[0];
            string lastName = name[1];

            UserNode user = _users.Find(UserNode => UserNode.FirstName == firstName && UserNode.LastName == lastName);

            return user;
        }
    }
}
