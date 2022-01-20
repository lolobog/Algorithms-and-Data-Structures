using System;
using System.Collections.Generic;
using System.Collections;
namespace PortfolioNick
{
    //Stack
    public class Stack<T>
    {
        public Node<T> top;  //top of the stack
        public int count = 0; //number of nodes in the stack

        //Adds a new node to the stack
        public void Push(T new_data)
        {
            //We put the new node at the top of the stack and we make it point to the previous top
            Node<T> current = top;
            top = new Node<T>(new_data);
            top.next = current;
            count++;
        }
        //Removes the top node from the stack
        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Stack is empty"); //Error in case the stack is empty
            }
            else
            {  //We return the data of the top node and remove our node by making the next node the new top
                T data = top.data;
                top = top.next;
                count--;
                return data;
            }
        }
        //Prints the data of all the nodes in the stack
        public void print()
        {
            Node<T> current = top;
            //We go through all the nodes in the stack until we reach a null and we stop
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }

        }

    }
    //Queue
    public class Queue<T>
    {
        public Node<T> head; //Head of the queue
        public Node<T> tail; //Tail of the queue
        public int count = 0;  //Number of nodes in the queue

        //Adds a node to the queue
        public void Enqueue(T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            if (count == 0)
            {
                head = new_node;
                tail = new_node;   //If the queue is empty, the first node will become both the head and the tail
                head.next = tail;
            }
            else
            {
                tail.next = new_node; //If the queue is not empty, we add the new node to the tail making the old tail point at it
                tail = new_node;
            }
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException("Queue is empty."); //Error in case the queue is empty
            else
            {
                T data = head.data;
                head = head.next;  //We return the data of the current head and we make the next node after the current head the new head
                return data;



            }
        }






        //Prints the data of all the nodes in the queue
        public void print()
        {
            Node<T> current = head;
            //We go through all the nodes in the stack until we reach a null and we stop
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }

        }


    }

    //Linked List
    public class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T d)
        {
            data = d;
            next = null;
        }
    }


    public class SingleLinkedList<T>
    {
        public Node<T> head;  //Head of the linked list
        private int count = 0;//Number of nodes in the linked list

        //Adds a new node to the linked list
        public void add(T new_data)
        {//We initialize a new node with the desired data making it the new head and the next node after it the previous head
            Node<T> new_node = new Node<T>(new_data);
            new_node.next = head;
            head = new_node;
            count++;
        }
        //Inserting a node with the desired data into the linked list
        public void Insert(int position, T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);

            Node<T> temp = head;
            if (position == 0)
            {
                new_node.next = temp;
                new_node.data = new_data; //If we insert at position 0 the new node becomes the head
                head = new_node;
            }
            else
            {
                for (int i = 1; i <= position - 1; i++)  //We navigate to our desired position
                {

                    temp = temp.next;

                }

                new_node.next = temp.next;
                temp.next = new_node;      //We insert our new node at the position, pushing the previous node at that position one place backwards
                new_node.data = new_data;

            }

            count++;

        }

        public void Remove(int position)
        {

            Node<T> temp = head;  //A copy of our head node

            Node<T> prev = null; //An empty node that will hold the previous node while navigating through the list

            if (position == 0)
            {

                head = temp.next;  //If we remove the current head, the next node becomes the new head
                return;

            }
            else
            {
                for (int i = 1; i <= position; i++)
                {
                    prev = temp;
                    temp = temp.next;   //We navigate to the desired position

                }
                prev.next = temp.next; //We remove the node from the list by unlinking it from its previous node

            }


            count--;
        }

        public void RemoveLast()
        {
            Node<T> temp = head;  //A copy of our head node
            Node<T> prev = null;  //An empty node that will hold the previous node while navigating through the list
            for (int i = 1; i <= count - 1; i++)
            {
                prev = temp;
                temp = temp.next;    //We navigate to the position of the last element-1
            }
            temp.next = null;  //We set the next element to be null, deleting the last node
            count--;
        }

        public void MoveUp(int position)
        {
            Node<T> temp = head;
            T tdata;
            Node<T> prev = null; //An empty node that will hold the previous node while navigating through the list

            if (position == 0)
                throw new InvalidOperationException("Can not move any higher"); //Error in case somebody tries to make us lose our head(hehe)
            else
            {
                for (int i = 1; i <= position; i++)
                {
                    prev = temp;
                    temp = temp.next;  //We navigate to the desire position

                }
                tdata = temp.data;
                temp.data = prev.data;  //We move the data around so our desired data goes up
                prev.data = tdata;

            }

        }

        public void MoveDown(int position)
        {
            Node<T> temp = head; //A copy of our head node
            T tdata;
            Node<T> prev = null; //An empty node that will hold the previous node while navigating through the list

            if (position == count-1)
                throw new InvalidOperationException("Can not move any lower");  //Error in case an element is supposed to be moved lower than the current size of the list
            else
            {
                for (int i = 1; i <= position + 1; i++)
                {
                    prev = temp;
                    temp = temp.next;    //We navigate to the desire position

                }
                tdata = temp.data;
                temp.data = prev.data;  //We move the data around so our desired data goes down
                prev.data = tdata;
            }
        }
        //We print all the nodes in the list 
        public void printNodes()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }

        }





    }


    //Doubly Linked List

    public class NodeD<T>
    {
        public T data;
        public NodeD<T> prev;
        public NodeD<T> next;
        public NodeD(T d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }

    public class DoublyLinkedList<T>
    {
        public NodeD<T> head;  //Head of the linked list
        public NodeD<T> tail;  //Tail of the linked list
        int count = 0;         //Number of nodes in the linked list

        //Adding a new element to the list
        public void add(T new_data)
        {
            NodeD<T> new_node = new NodeD<T>(new_data);
            //If the list is empty the new node becomes the head and tail of the list
            if (tail == null)
                head = new_node;
            else
            {
                //Connect the new node to the previous tail
                new_node.prev = tail;
                tail.next = new_node;
            }
            //New node becomes current tail
            new_node.data = new_data;
            tail = new_node;

            count++;


        }
        //Inserting an element in the list at the required position
        public void Insert(int position, T new_data)
        {
            NodeD<T> new_node = new NodeD<T>(new_data);
            NodeD<T> current = head;
            //If the position is 0 we make the new element the head of the list
            if (position == 0)
            {
                head.prev = new_node;
                new_node.next = head;
                head = new_node;
            }
            else

            if (position == count)
            {
                throw new InvalidOperationException("Insertion exceeded the number of elements in the list.");  //Error in case the position does not exist in the list
            }
            else
            {   //We navigate to our desired position
                for (int i = 0; i <= position - 2; i++)
                {
                    current = current.next;
                }
                //Connect the new node to the current one on the position and the next one after it
                new_node.next = current.next;
                new_node.prev = current;
                current.next.prev = new_node;
                current.next = new_node;
                new_node.data = new_data;
            }


            count++;




        }

        public void Remove(int position)
        {

            NodeD<T> current = head;
            //If poistion is 0 we make the next element the new head 
            if (position == 0)
            {
                head.next.prev = null;
                head = head.next;
            }
            else
            { //Navigate to the desired position
                for (int i = 0; i <= position - 1; i++)
                {
                    current = current.next;
                }
                //Connecting the two nodes to the left and to the right of our position together, removing our node
                current.next.prev = current.prev;
                current.prev.next = current.next;
            }


            count--;
        }

        public void RemoveLast()
        {
            //We remove the last element, the previous element becoming the new tail.
            tail.prev.next = null;
            tail = tail.prev;
        }

        public void MoveUp(int position)
        {//We swap around the values of the element from our position with the one above it
            NodeD<T> current = head;
            T tdata;
            if (position == 0)
                throw new InvalidOperationException("Can not move nodes any higher than this."); //Error in case the head is trying to be moved higher than it already is LMAO
            else
            {  //Navigating to the desired position
                for (int i = 0; i <= position - 1; i++)
                {
                    current = current.next;
                }
                //Swapping the values
                tdata = current.prev.data;
                current.prev.data = current.data;
                current.data = tdata;
            }

        }

        public void MoveDown(int position)
        {//We swap around the values of the element from our position with the one below it
            NodeD<T> current = head;
            T tdata;
            if (position == count - 1)
                throw new InvalidOperationException("Can not move nodes any lower than this.");  //Error if trying to move lower than possible
            else
            { //Navigating to the desired position
                for (int i = 0; i <= position - 1; i++)
                {
                    current = current.next;
                }
                //Swapping the values
                tdata = current.next.data;
                current.next.data = current.data;
                current.data = tdata;
            }
        }
        //Prints all the nodes in the list in order
        public void printNodes()
        {
            NodeD<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }

        }

        //Prints all the nodes in the list in reversed order
        public void printNodesReverse()
        {
            NodeD<T> current = tail;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.prev;
            }

        }






    }

    //Min Heap
    public class HeapNode
    {
        public int data;
        public HeapNode parent;
        public HeapNode right;
        public HeapNode left;
        public HeapNode(int data)
        {
            this.data = data;
            parent = null;
            right = null;
            left = null;
        }
    }

    public class MinHeap
    {
        HeapNode root;


        List<HeapNode> AllNodes = new List<HeapNode>();

        public void Add(int data)
        {
            HeapNode NewNode = new HeapNode(data);

            if (root == null)
            {
                root = NewNode;
                AllNodes.Add(root);
                return;
            }


            for (int i = 0; i < AllNodes.Count; i++)
            {
                if (AllNodes[i].left == null)
                {
                    AllNodes[i].left = NewNode;
                    NewNode.parent = AllNodes[i];
                    break;
                }
                else
                if (AllNodes[i].right == null)
                {
                    AllNodes[i].right = NewNode;
                    NewNode.parent = AllNodes[i];
                    break;
                }
            }
            AllNodes.Add(NewNode);
            BubbleUp(NewNode);

        }

        private void BubbleUp(HeapNode startingNode)
        {
            HeapNode currentNode = startingNode;
            HeapNode parentNode = currentNode.parent;

            while (parentNode != null && currentNode.data < parentNode.data)
            {
                //swap data

                int temp = parentNode.data;
                parentNode.data = currentNode.data;
                currentNode.data = temp;

                currentNode = parentNode;
                parentNode = currentNode.parent;
            }

        }



        public void RemoveTop()
        {
            List<HeapNode> Copy = AllNodes;
            //We move all the nodes in the list one place backwards and we make the last place null because we removed a node from the list
            for (int i = 0; i < AllNodes.Count - 1; i++)
            {
                AllNodes[i] = AllNodes[i + 1];
                if (i == AllNodes.Count - 2)
                    AllNodes[i + 1] = null;
            }
            //Our new root becomes the first node from the list
            root = AllNodes[0];
            for (int i = 0; i < AllNodes.Count - 1; i++)
            {



                //the root should have no parent
                if (i == 0)
                {
                    AllNodes[i].parent = null;


                }
                //going through the new array from which we removed the old root we place the elements on the left and right according to the formula
                if (i * 2 + 1 < AllNodes.Count - 1)
                    if (AllNodes[i * 2 + 1] != null)
                        AllNodes[i].left = AllNodes[i * 2 + 1];

                if (i * 2 + 1 < AllNodes.Count - 1)
                    if (AllNodes[i * 2 + 2] != null)
                        AllNodes[i].right = AllNodes[i * 2 + 2];


            }





        }


    }

    public class BinarySearchTree
    {
        HeapNode root;
        List<HeapNode> AllNodes = new List<HeapNode>();


        public void Add(int data)
        {
            HeapNode new_node = new HeapNode(data);
            HeapNode current = root;
            bool placed = false;
            if (root == null)
            {
                root = new_node;
                AllNodes.Add(root);
                return;
            }
            else
            {
                while (placed == false)
                {
                    if (new_node.data <= current.data)
                    {
                        if (current.left == null)
                        {
                            current.left = new_node;
                            new_node.parent = current;
                            placed = true;
                            AllNodes.Add(new_node);
                        }
                        else
                        {
                            current = current.left;
                        }
                    }


                    if (new_node.data > current.data)
                    {
                        if (current.right == null)
                        {
                            current.right = new_node;
                            new_node.parent = current;
                            placed = true;
                            AllNodes.Add(new_node);
                        }
                        else
                        {
                            current = current.right;
                        }
                    }
                }
            }
        }

        public bool  Search(int data)
        {
            HeapNode current = root;
            bool found = false;

            while((found==false)&&(current!=null))
            {
                if(current.data==data)
                {
                    found = true;

                }

                if(data<current.data)
                {
                    current = current.left;
                }

                if(data>current.data)
                {
                    current = current.right;
                }
            }

            return found;
        }


    }





        //Travelling Salesman
        class TravelingSalesman
        {

            class City
            {
                public string Name;
                public List<Connection> Connections;

                public City(String Name)
                {
                    this.Name = Name;
                    Connections = new List<Connection>();
                }

                private City()
                {
                    this.Name = "Name";
                    Connections = new List<Connection>();
                }
            }

            class Connection
            {
                public City connectedCity;
                public float Distance;

                public Connection(City c, float dist)
                {
                    connectedCity = c;
                    Distance = dist;
                }
            }
            List<City> Cities = new List<City>();
            public TravelingSalesman()
            {

                City ACity = new City("A");
                Cities.Add(ACity);
                City BCity = new City("B");
                Cities.Add(BCity);
                City CCity = new City("C");
                Cities.Add(CCity);
                City DCity = new City("D");
                Cities.Add(DCity);

                ACity.Connections.Add(new Connection(BCity, 5));
                ACity.Connections.Add(new Connection(DCity, 10));


                BCity.Connections.Add(new Connection(ACity, 5));
                BCity.Connections.Add(new Connection(CCity, 6));

                CCity.Connections.Add(new Connection(BCity, 6));
                CCity.Connections.Add(new Connection(DCity, 2));

                DCity.Connections.Add(new Connection(CCity, 2));
                DCity.Connections.Add(new Connection(ACity, 10));




            }


            public void FindPath()
            {
                City c = Cities[0];
                List<City> Visited = new List<City>();


                do
                {
                    Visited.Add(c);

                    Connection shortestConnection = new Connection(new City("INF"), float.MaxValue);

                    foreach (Connection connection in c.Connections)
                    {
                        if (!Visited.Contains(connection.connectedCity))
                        {

                            if (connection.Distance < shortestConnection.Distance)
                                shortestConnection = connection;

                        }
                    }

                    c = shortestConnection.connectedCity;

                } while (Visited.Count < Cities.Count);

                foreach (var city in Visited)
                {
                    Console.WriteLine(city.Name);
                }
            }
        }




















        class Program
        {

            //Swap(swaps 2 elements of an array)
            static void Swap(int[] a, int i, int j)
            {
                int temp;
                temp = a[i];
                a[i] = a[j];
                a[j] = temp;
            }

            //Sorts

            //Quick Sort
            static int[] QuickSort(int[] Unsorted)
            {
                List<int> Left = new List<int>();
                List<int> Right = new List<int>();
                int Pivot = Unsorted[(Unsorted.Length - 1) / 2];

                //Dividing the numbers from the array into a Left(<pivot) and Right(>pivot)
                foreach (int Value in Unsorted)
                {
                    if (Value < Pivot)
                        Left.Add(Value);
                    else
                        if (Value > Pivot)
                        Right.Add(Value);
                }
                //Putting the Pivot into the left so it would not be left out
                Left.Add(Pivot);



                //Sorting the Left side
                if (Left.Count > 1)
                {
                    List<int> temp = new List<int>();
                    temp.AddRange(QuickSort(Left.ToArray()));
                    Left = temp;
                }
                //Sorting the Right side
                if (Right.Count > 1)
                {
                    List<int> temp = new List<int>();
                    temp.AddRange(QuickSort(Right.ToArray()));
                    Right = temp;

                }
                //Putting the sorted Right and Left together
                List<int> SortedData = new List<int>();
                SortedData.AddRange(Left);
                SortedData.AddRange(Right);

                return SortedData.ToArray();

            }

            //Bubble Sort
            static int[] BubbleSort(int[] Unsorted)
            {
                //We navigate through the array of integers
                for (int i = 0; i < Unsorted.Length - 1; i++)
                    //For each element the array we enter the for loop
                    for (int j = 0; j < Unsorted.Length - (1 + i); j++)
                    { //If 2 elements are not in the right order we swap their position
                        if (Unsorted[j] > Unsorted[j + 1])
                        {
                            Swap(Unsorted, j, j + 1);
                        }
                    }
                return Unsorted;
            }

            //Insertion Sort

            static int[] InsertionSort(int[] Unsorted)
            {

                //We go to the last but one element with i starting from 0
                for (int i = 0; i < Unsorted.Length - 1; i++)
                    //Start from i+1, going to 0 , swapping the positions of the elements that are not in order
                    for (int j = i + 1; j > 0; j--)
                    {
                        if (Unsorted[j - 1] > Unsorted[j])
                        {
                            Swap(Unsorted, j - 1, j);
                        }
                    }
                return Unsorted;

            }



            //Radix Sort

            //Get a digit at a certain place in our number
            static int GetPlaces(int value, int places)
            {
                return ((value % (places * 10)) - (value % places)) / places;
            }


            static int[] RadixSort(int[] Unsorted)
            {
                int place = 1;  //The place of the digits that we are working with
                List<int> SemiSortedData = new List<int>(); //We create an empty list
                SemiSortedData.AddRange(Unsorted); //We add our elements to the list
                List<int>[] Buckets = new List<int>[10]; //We create the buckets list array for our number's digits
                do
                {

                    //We fill the List Array with empty lists in which we will place our numbers
                    for (int i = 0; i < Buckets.Length; i++)
                        Buckets[i] = new List<int>();

                    //We place the values in the Buckets list according to the place of the digit we are looking at(ones,tens,hundreds,etc)
                    foreach (int value in SemiSortedData)
                    {
                        int indexOfBuckets = GetPlaces(value, place);
                        Buckets[indexOfBuckets].Add(value);
                    }
                    SemiSortedData.Clear(); //We get rid the original data so we can replace it with the new data sorted according to the digit at which we are looking

                    foreach (List<int> bucket in Buckets)
                    {
                        SemiSortedData.AddRange(bucket); //We add the elemts sorted according to their digits and the place to the List
                    }

                    place *= 10; //We multiply the place by 10 so we go to the next digit in our numbers
                } while (SemiSortedData.Count != Buckets[0].Count); //We continue doing this until there are no numbers on the place where we are searching
                return SemiSortedData.ToArray(); //We convert the list to an array and return it
            }

            static void BinarySearch(int[] arr, int target)
            {
                arr = QuickSort(arr); //Binary search works with only a sorted array

                int left = 0;  //Leftmost point from which we start the search
                int right = arr.Length - 1;  //Rightmost point that is the end point for the search
                int middle;  //The middle point between right and left
                while (left <= right)
                {
                    middle = (left + right) / 2;

                    if (arr[middle] == target) //If the target is found at the middle point between the current right and left
                    {
                        Console.WriteLine(target + " found at index " + middle);
                        break;
                    }
                    else
                        if (target < arr[middle]) //If our target is in the first half of the array we change our right side to be lower than the middle
                        right = middle - 1;
                    else
                        if (target > arr[middle]) //If our target is in the second half of the array we change our left side to be higher than the middle
                        left = middle + 1;

                }

                if (left > right) //Error check in case our target is not in the array
                {
                    Console.WriteLine("Target not found");
                }




            }


            static void Main(string[] args)
            {

              //Stack test
           /*
             Stack<int> bookStack = new Stack<int>();   

             bookStack.Push(1);
             bookStack.Push(2);
             bookStack.Push(3);
             bookStack.Push(4);

             Console.ReadLine();
             bookStack.Pop();

            Console.ReadLine();
            bookStack.print();


             Console.ReadLine();


            */

            
              

            
            // Queue Test

         
            /*

            Queue<string> Quety = new Queue<string>();

            Quety.Enqueue("buna");
            Quety.Enqueue("ce");
            Quety.Enqueue("mai");
            Quety.Enqueue("faci");
            Quety.Dequeue();

            Quety.print();


            
            
            */


            ///Linked List Test
           /* 
            SingleLinkedList <int>  Listy= new SingleLinkedList<int> { };

            Listy.add(10);
            Listy.add(20);
            Listy.add(30);
            Listy.add(50);
            Listy.MoveUp(0);                              
            Listy.printNodes();

            
                */        


            // Doubly Linked List Test
            /*
            


            DoublyLinkedList<string> books = new DoublyLinkedList<string>();
            books.add("a");
            books.add("b");
            books.add("c");
            books.add("d");
            books.add("e");
           books.MoveDown(3);
            books.printNodes();









            
           */

            /*
            int[] data = { 1, 5, 763, 43, 3, 67, 321, 67,1, 14, 325, 450 };


            foreach(int value in QuickSort(data))

            {
                Console.WriteLine(value + " ");
            }

            BinarySearch(data, 763);

            */

            /*
            MinHeap mini=new MinHeap();

            mini.Add(1);
            mini.Add(2);
            mini.Add(3);
            mini.Add(4);
            mini.Add(5);
            mini.Add(6);
            mini.Add(7);
            mini.RemoveTop();

            */

            /*
            TravelingSalesman TS = new TravelingSalesman();
            TS.FindPath();

            */

            /*
            BinarySearchTree bin = new BinarySearchTree();
            bin.Add(10);
            bin.Add(15);
            bin.Add(9);
            bin.Add(8);
            bin.Add(11);
            bin.Add(16);
            
           Console.WriteLine( bin.Search(16));
            */
            Console.ReadLine();




            }
        }
}

