using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Ziza
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int i)
        {
            data = i;
            next = null;
        }

        public void addSorted(int data)
        {
            if (next == null)
                next = new Node(data);
            else if (data < next.data)
            {
                Node tmp = new Node(data);
                tmp.next = this.next;
                this.next = tmp;
            }
            else
                next.addSorted(data);
        }
        public int countNode()
        {
            int count = 0;
            if (next == null)
            {
                Console.WriteLine("The list is empty");
                return count;
            }

            else
            {
                count++;
                while (next != null)
                {
                    count++;
                    next = next.next;
                }
                return count;
            }
        }
        public void Print()
        {
            Console.Write("|" + data + "|->");
            if (next != null)
                next.Print();
        }
        public void addToEnd(int data)
        {
            if (next == null)
                next = new Node(data);
            else
                next.addToEnd(data);
        }
    }

    public class myList
    {
        public Node headNode;
        public Node tailNode;
        public Node currentNode;
        public Node tmp;

        public myList()
        {
            headNode = null;
        }        

        public void addToEnd(int data)
        {
            if (headNode == null)
                headNode = new Node(data);
            else
                headNode.addToEnd(data);
        }

        public void addSorted(int data)
        {
            if (headNode == null)
                headNode = new Node(data);
            else if (data < headNode.data)
                addToBeginning(data);
            else
                headNode.addSorted(data);
           
        }
        public void printNodeToLast(int data)
        {
            if (headNode == null)
                Console.WriteLine("The list is empty");
            else
            {
                currentNode = headNode;
                while (currentNode != null && currentNode.data != data)
                {
                    tailNode = currentNode;
                    currentNode = currentNode.next;
                }
                if (currentNode.data == data)
                {
                    tmp = currentNode;
                    tmp.Print();
                }
            }
        }

        public void addToBeginning(int data)
        {
            if (headNode == null)
                headNode = new Node(data);
            else
            {
                Node tmp = new Node(data);
                tmp.next = headNode;
                headNode = tmp;
            }
        }
        public void removeNode(int data)
        {
            if (headNode == null)
                Console.WriteLine("The list is empty");
            else
            {
                currentNode = headNode;
                while (currentNode != null && currentNode.data != data)
                {
                    tailNode = currentNode;
                    currentNode = currentNode.next;
                }
                if (currentNode == headNode && currentNode.data == data)
                    headNode = headNode.next;
                
                if (currentNode != null)
                    tailNode.next = currentNode.next;           
            }
        }
        public void removeDuplicates(int data)
        {
            int count = 0;
            
            if (headNode == null)
                Console.WriteLine("The list is empty");

            tmp = headNode;
                       
            for (int i = 0; i < 4; i++)
            {
                if (tmp.data == data)
                {
                    tmp = tmp.next;
                    count++;
                }
                else
                    tmp = tmp.next;
            }
            while (count > 1)
            {
                removeNode(data);
                count--;
            }
        }
       
        public void addNodes()
        {
            if (headNode == null)
                Console.WriteLine("The list is empty");
            else
            {
                Node tmp2 = null;
                tmp2 = headNode;
                int count = 0;

                int[] list1 = new int[3];
                int[] list2 = new int[3];
                while (headNode != null && count <= 2)
                {
                    list1[count] = headNode.data;
                    headNode = headNode.next;
                    count++;
                }

                count = 0;

                while (headNode != null && count <= 2)
                {
                    list2[count] = headNode.data;
                    headNode = headNode.next;
                    count++;
                }

                Array.Reverse(list1);
                Array.Reverse(list2);

                string input1 = "";
                string input2 = "";

                foreach (var l1 in list1)
                {
                    string convert = Convert.ToString(l1);
                    input1 += convert;
                }
                foreach (var l2 in list2)
                {
                    string convert2 = Convert.ToString(l2);
                    input2 += convert2;
                }

                int a = Convert.ToInt16(input1);
                int b = Convert.ToInt16(input2);

                int c = a + b;

                Console.WriteLine("{0} + {1} = {2}", a, b, c);

            }
        }
        public void positionNode(int data)
        {
            if (headNode == null)
                Console.WriteLine("The list is empty.");
            else
            {
                currentNode = headNode;
                tmp = headNode;
                while (currentNode != null && currentNode.data != data)
                {
                    tailNode = currentNode;
                    currentNode = currentNode.next;
                }
                if (currentNode.data == data)
                {
                    while (currentNode.data > headNode.data || headNode != null)
                    {
                        if (currentNode.data > headNode.data)
                        {
                            Console.WriteLine(headNode.data);
                            headNode = headNode.next;
                            if (headNode == null)
                                break;
                        }
                        else
                        {
                            headNode = headNode.next;
                            if (headNode == null)
                                break;
                        }
                                                   
                    }
                    while (currentNode.data <= tmp.data || tmp != null)
                    {
                        if (currentNode.data <= tmp.data)
                        {
                            Console.WriteLine(tmp.data);
                            tmp = tmp.next;
                            if (tmp == null)
                                break;
                        }
                        else
                        {
                            tmp = tmp.next;
                            if (tmp == null)
                                break;
                        }                                                 
                    }
                }
            }
        }
        public void Print()
        {
            if (headNode != null)
                headNode.Print();
        }
    }
    class Program
    {      
        static void Main(string[] args)
        {
            myList list = new myList();
            list.addToBeginning(4);
            list.addToBeginning(7);
            list.addToBeginning(1);
            list.addToBeginning(6);
            list.addToBeginning(8);
            list.addToBeginning(2);
            list.addNodes();
            list.positionNode(6);
            Console.ReadKey();
        }
    }
}
