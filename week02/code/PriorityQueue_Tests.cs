using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority first.
    // Defect(s) Found:
    // 1. Loop condition "index < _queue.Count - 1" skips the last element. Should be "index < _queue.Count".
    // 2. Dequeued item is never removed from the queue (missing RemoveAt call).
    // 3. Using ">=" in priority comparison violates FIFO for items with same priority.
    public void TestPriorityQueue_DequeuePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority and dequeue them.
    // Expected Result: Items with same priority should follow FIFO - first one in is first one out.
    // Defect(s) Found: Using ">=" instead of ">" causes LIFO behavior for same priority items.
    // The comparison should be ">" so that only strictly higher priorities replace the current best.
    public void TestPriorityQueue_FIFOSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - this test passes. Empty queue handling is correctly implemented.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue items and verify the highest priority item at the end is correctly found.
    // Expected Result: Should return the item with highest priority even if it's the last item.
    // Defect(s) Found: Loop uses "index < _queue.Count - 1" which skips the last item in the queue.
    // This causes the highest priority item at the end to never be considered.
    public void TestPriorityQueue_HighestPriorityAtEnd()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);  // Highest priority is at the end

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priority items where some have the same priority.
    // Expected Result: Higher priority first, then FIFO for same priority items.
    // Defect(s) Found: Items are not removed after dequeue, causing the same item to be returned
    // repeatedly. Also, FIFO is violated due to ">=" comparison.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);

        // B and D have priority 5 (highest), B should come first (FIFO)
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        // A and C have priority 3, A should come first (FIFO)
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }
}