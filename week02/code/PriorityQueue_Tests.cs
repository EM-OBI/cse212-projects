using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics; 

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: A new list containing items with different priorities is created. The enqueue function is then used to add the items to the list, and then the item with the highest priority is dequeued. If this matches the expected result, then the test passes. The test also fails if no item was enqueued and hence the list is empty.
    // Expected Result: The item on the expectedResult list at an index matches the same item added to the priorityQueue using the enqueue function. The items are accessed using a helper function in the PriorityQueue class - getitemAtIndex(). An error is thrown if the queue is empty. 

    //Test enqueue with the value and property
    // Defect(s) Found: None in enqueue method
    public void TestPriorityQueue_EnqueueInOrder()
    {
        var priorityQueue = new PriorityQueue();

        var items = new List<string>{"beans", "rice", "plantain", "moi-moi", "gizzard"};
        var priorities = new List<int>{4, 6, 15, 6, 9};

        int Length = items.Count;

        //Add items to the queue using the Enqueue function
        for (int i = 0; i < Length; i++) {
            var priorityItem = new PriorityItem(items[i], priorities[i]);
            priorityQueue.Enqueue(priorityItem.Value, priorityItem.Priority);
        }

        //Create a new queue to test against
        var expectedResult = new List<PriorityItem>
        {
            new PriorityItem("beans", 4),
            new PriorityItem("rice", 6),
            new PriorityItem("plantain", 15),
            new PriorityItem("moi-moi", 6),
            new PriorityItem("gizzard", 9)
        };

        var queueLength = priorityQueue.Length;

        Debug.WriteLine(priorityQueue);

        //Throw error if the queue is empty
        if (queueLength == 0) {
            throw new InvalidOperationException("The queue is empty!");
        }

        //Compare enqueued items using helper method with expected results. 
        for (int i = 1; i < expectedResult.Count; i++) {
            var item = priorityQueue.getItemAtIndex(i);
            Assert.AreEqual($"{expectedResult[i].Value}, {expectedResult[i].Priority}", item);
        }
    }

    [TestMethod]
    // Scenario: Add items to queue using Enqueue, then add items to a list to compare. Then, use a loop to find the highest priority item on the list and compare its value with the PriorityQueue list's dequeued item's value. 
    // Expected Result: The item with the highest priority should be returned iwth dequeue and its value should match the list created for comparison. 
    // Defect(s) Found: No defects noted for this specific scenario even though the dequeue function has a defect noted inthe next test method. 
    public void TestPriorityQueue_DequeueHighestPriorityItem()
    {
        var priorityQueue = new PriorityQueue();

        var items = new List<string>{"beans", "rice", "plantain", "moi-moi", "gizzard"};
        var priorities = new List<int>{4, 6, 15, 6, 9};

        int Length = items.Count;

        //Add items to the queue using the Enquue function
        for (int i = 0; i < Length; i++) {
            var priorityItem = new PriorityItem(items[i], priorities[i]);
            priorityQueue.Enqueue(priorityItem.Value, priorityItem.Priority);
        }

        //Create a new queue to test against
        var expectedResult = new List<PriorityItem>
        {
            new PriorityItem("beans", 4),
            new PriorityItem("rice", 6),
            new PriorityItem("plantain", 15),
            new PriorityItem("moi-moi", 6),
            new PriorityItem("gizzard", 9)
        };

        var queueLength = priorityQueue.Length;

        //Throw error if the queue is empty
        if (queueLength == 0) {
            throw new InvalidOperationException("The queue is empty!");
        }
        
        int highestPriIndex = 0;
        for (int i = 1; i < expectedResult.Count; i++) {
            if (expectedResult[i].Priority > expectedResult[highestPriIndex].Priority) {
                highestPriIndex = i;
            }
        }
        var item = priorityQueue.Dequeue();
        Assert.AreEqual(expectedResult[highestPriIndex].Value, item, "The highest priority item should be dequeued following appropriate enqueueing");
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: A list is created where three items contain the highest priority and in this case only the first item out of the three should be returned
    // Expected Result: In a queue where two items have the same priority, only the first item should be returned. 
    // Defect(s) Found: The Dequeue() method returned the last item with the highest priority because it was assigning the index of the highest priority based on whether or not it was greater than or equal to the preceding item's priority. This only works when there is only one highest priority item on the list. 
    public void TestPriorityQueue_DequeueFirstHighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        var items = new List<string>{"beans", "rice", "plantain", "moi-moi", "gizzard"};
        var priorities = new List<int>{4, 6, 6, 6, 3};

        int Length = items.Count;

        //Add items to the queue using the Enquue function
        for (int i = 0; i < Length; i++) {
            var priorityItem = new PriorityItem(items[i], priorities[i]);
            priorityQueue.Enqueue(priorityItem.Value, priorityItem.Priority);
        }

        //Create a new queue to test against
        var expectedResult = new PriorityItem("rice", 6);

        var queueLength = priorityQueue.Length;

        //Throw error if the queue is empty
        if (queueLength == 0) {
            throw new InvalidOperationException("The queue is empty!");
        }

        var item = priorityQueue.Dequeue();
        Assert.AreEqual(expectedResult.Value, item, "The highest priority item should be dequeued following appropriate enqueueing");
    }

    [TestMethod]
    // Scenario: An empty list is created and Dequeue is tried to be applied to the empty queue. Dequeue is supposed to throw and error for empty queues.  
     // Expected Result: An exception is created of the same expected type from Dequeue. They both should match in type for the test to pass. 
    // Defect(s) Found: No defect found regarding this functionality
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        var queueLength = priorityQueue.Length;

        Exception expectedResult = new InvalidOperationException("The queue is empty!");

        //Catch thrown error if the queue is empty and compare with expectedResult
        Exception exception = null; 
        try
        {
            priorityQueue.Dequeue();
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual(expectedResult.GetType(), e.GetType());
        }
    }
}