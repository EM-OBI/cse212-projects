using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        //Create new node
        Node newNode = new(value);

        //If list is empty, point both the head and tail to the added value
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail; //Make the newNode's previous the former tail
            _tail.Next = newNode; //Make the former tail's next the newNode
            _tail = newNode; //Set the tail of the list to the newNode;

        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2

        //check if there is only one item in the list and if there is, you set the head and tail of the list to null.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail!.Prev!.Next = null; //Set the next of the tail's previous (which is the tail to be remove)to null
            _tail = _tail.Prev; //Set the new tail to be the second to last (previous of the tail to be removed)
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        //Start from the head to look for the value
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value) //Check if the data of the current item is the same as value
            {
                if (curr == _head) //Check if it is the first item. If it is, call the RemoveHead() function
                {
                    RemoveHead();
                }
                else if (curr == _tail) //Check if it is the last item. If it is, call the RemoveTail() function
                {
                    RemoveTail();
                }
                else //We are somewhere in the middle
                {
                    curr.Prev!.Next = curr.Next; //Set current previoius's next to the item after the current (the item to be removed)
                    curr.Next!.Prev = curr.Prev; //Set current next's previous to the item before current (the item to be removed)
                }
                return; //Exit the function
            }
            curr = curr.Next; //Move to the next item if the value to be removed doesn't match the data in the current item
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        //Loop through the list starting from the head
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue) //Check if the current value's data is the same as the old value and set it to the new value;
            {
                curr.Data = newValue;
            }
            curr = curr.Next; //Move to the next item.
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        var curr = _tail; //start from the end since this is a reverse iteration. 
        while (curr is not null)
        {
            yield return curr.Data; //Provide the user with each item
            curr = curr.Prev; //Go backward in the linked list
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}