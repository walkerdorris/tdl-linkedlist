using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedListNode firstNode { get; set; }

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            foreach (var item in values)
            {
                var node = new SinglyLinkedListNode(item.ToString());
                if(firstNode == null)
                {
                    firstNode = node;
                }
                else
                {
                    this.AddLast(node.ToString());
                }
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return this.ElementAt(i); }
            set {
                SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                if(i == 0)
                {
                    newNode.Next = firstNode.Next;
                    firstNode = newNode;
                }
                else
                {
                    var counter = 1;
                    SinglyLinkedListNode node = firstNode;
                    while(i > counter)
                    {
                        node = node.Next;
                        counter++; 
                    }
                    node.Next = newNode;
                }
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            if (firstNode == null)
            {
                throw new ArgumentException();
            }
            if (firstNode != null && firstNode.Next == null)
            {
                if (firstNode.Value == existingValue)
                {
                    firstNode.Next = new SinglyLinkedListNode(value);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            if (firstNode.Value == existingValue)
            {
                var oldnextnode = firstNode.Next;
                firstNode.Next = new SinglyLinkedListNode(value);
                firstNode.Next.Next = oldnextnode;
            }
            else
            {
                while (firstNode != null && firstNode.Next != null)
                {
                    var nextnode = firstNode.Next;
                    while (nextnode != null && nextnode.Value != existingValue)
                    {
                        if (nextnode.Next == null)
                        {
                            throw new ArgumentException();
                        }
                        while (nextnode.Next != null)
                        {
                            if (nextnode.Value == existingValue)
                            {
                                nextnode.Next = new SinglyLinkedListNode(value);
                            }
                            else
                            {
                                nextnode = nextnode.Next;
                            }
                        }

                    }
                    if (firstNode.Value == existingValue)
                    {
                        firstNode.Next = new SinglyLinkedListNode(value);
                    }
                    if (nextnode.Value == existingValue)
                    {
                        nextnode.Next = new SinglyLinkedListNode(value);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }

        public void AddFirst(string value)
        {
            
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
            }
            else
            {
                var oldfirstnode = firstNode;
                firstNode = new SinglyLinkedListNode(value);
                firstNode.Next = oldfirstnode;
            }   
        }

        public void AddLast(string value)
        {
            var node = firstNode;
            if (node == null)
            {
                firstNode = new SinglyLinkedListNode(value);
            }
            else {
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = new SinglyLinkedListNode(value);
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            var counter = 0;
            if(firstNode == null)
            {
                return counter;
            }
            if (firstNode != null && firstNode.Next == null)
            {
                return 1;
            }
            else
            {
                counter = 1;
                while (firstNode.Next != null)
                {
                    firstNode = firstNode.Next;
                    counter++;
                }
                return counter;
            }
        }

        public string ElementAt(int index)
        {
            var list = new SinglyLinkedList();
            int posindex = Math.Abs(index);
            var counter = 0;
            var node = this.firstNode;
            
            if (posindex == 0)
            {
                if(this.firstNode == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return node.ToString();
                }
            }
            else
            {
                while (posindex != counter)
                {
                    counter++;
                    node = node.Next;
                }
                return node.ToString();
            }
        }

        public string First()
        {
            if(firstNode != null)
            {
                return firstNode.ToString();
            }
            else
            {
                return null;
            }
         }

        public int IndexOf(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if(firstNode == null)
            {
                return -1;
            }
            else
            {
                SinglyLinkedListNode flexiNode = firstNode;
                var counter = 0;
                while(flexiNode.Value != value)
                {
                    flexiNode = flexiNode.Next;
                    counter++;
                    if (flexiNode == null)
                    {
                        return -1;
                        break;
                    }
                }
                return counter;
            }
        }

        public bool IsSorted()
        {
            if (firstNode == null || (firstNode != null && firstNode.Next == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        private string LastNode()
        {
            var node = firstNode;
            if (node != null)
            {
                if(node.Next == null)
                {
                    return node.ToString();
                }
                else
                {
                    while (node.Next != null)
                    {
                        node = node.Next;
                    }
                    return node.ToString();
                }
            }
            else
            {
                return null;
            }
        }

        public string Last()
        {
            return this.LastNode();
        }

        public void Remove(string value)
        {
            SinglyLinkedListNode flexiNode = firstNode;
            if (firstNode.Value == value)
            {
                firstNode = firstNode.Next;
            }
            else
            {
                while (flexiNode.Next.Value != value)
                {
                    flexiNode = flexiNode.Next;
                    if (flexiNode.Next == null)
                    {
                        flexiNode = firstNode;
                        flexiNode.Next = firstNode.Next;
                        return;
                    }
                }
                flexiNode.Next = flexiNode.Next.Next;
            }
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            var node = this.firstNode;
            List<string> listarray = new List<string>();
            if (node == null)
            {
                return new string[] { };
            }
            if (node != null && node.Next == null)
            {
                var _node = node.ToString();
                listarray.Add(_node);
                return listarray.ToArray();
            }
            if (node.Next != null)
            {
                var _node = node.ToString();
                listarray.Add(_node);
                while (node.Next != null)
                {
                    node = node.Next;
                    var _nextnode = node.ToString();
                    listarray.Add(_nextnode);
                }
                return listarray.ToArray();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            var _stringbuilder = new StringBuilder();
            var node = firstNode;

            if (node == null)
            {
                return "{ }";
            }
            if (node != null && node.Next == null)
            {
                return _stringbuilder.Append("{").Append(" ").Append("\"").Append(node.Value).Append("\"").Append(" ").Append("}").ToString();
            }
            if (node.Next != null)
            {
                _stringbuilder.Append("{").Append(" ").Append("\"").Append(node.Value).Append("\"");
                var counter = 0;
                while(node.Next != null)
                {
                    counter++;
                    node = node.Next;
                    _stringbuilder.Append(", \"" + node.Value + "\"");
                }
                _stringbuilder.Append(" }");
                return _stringbuilder.ToString();
            }
            else
            {
                return node.ToString();
            }    
            
        }
    }
}
