using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] x = { };
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        x = x.Append(i).ToArray();
                        x = x.Append(j).ToArray();
                        break;
                    }
                }
            }
            return x;
        }

        public class Parent
        {
            public virtual void ShowName()
            {
                Console.WriteLine("Parent");
            }
        }

        public class Child : Parent
        {
            public override void ShowName()
            {
                Console.WriteLine("child");
            }

            public void ShowDisc(string name, string description) {  Console.WriteLine(name, description); }
        }

        static void Main(string[] args)
        {
            Parent parent = new Child();
            parent.ShowName();
            Console.ReadLine();
        }
    }
}
