using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities
    // Expected Result: Item with highest priority is dequeued
    // Defect(s) Found: Dequeue does not remove item and priority comparison is incorrect
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 5);
        pq.Enqueue("Medium", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority
    // Expected Result: First item (FIFO) with highest priority is dequeued
    // Defect(s) Found: FIFO not respected for equal priorities
    public void TestPriorityQueue_FIFOForSamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 5);
        pq.Enqueue("Second", 5);
        pq.Enqueue("Third", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Dequeue removes item from queue
    // Expected Result: Next dequeue returns next highest priority
    // Defect(s) Found: Item was not removed from queue
    public void TestPriorityQueue_Removal()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);

        var first = pq.Dequeue();
        var second = pq.Dequeue();

        Assert.AreEqual("B", first);
        Assert.AreEqual("A", second);
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with correct message
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
