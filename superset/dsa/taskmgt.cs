using System;

namespace TaskManagementSystem
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"ID: {TaskId}, Name: {TaskName}, Status: {Status}";
        }
    }

    // Node for linked list
    public class TaskNode
    {
        public Task Data;
        public TaskNode Next;

        public TaskNode(Task task)
        {
            Data = task;
            Next = null;
        }
    }

    public class TaskList
    {
        private TaskNode head;

        // Add task to end - O(n)
        public void AddTask(Task task)
        {
            TaskNode newNode = new TaskNode(task);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                TaskNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Console.WriteLine($"✅ Added: {task.TaskName}");
        }

        // Search by ID - O(n)
        public Task SearchTask(int id)
        {
            TaskNode current = head;
            while (current != null)
            {
                if (current.Data.TaskId == id)
                    return current.Data;
                current = current.Next;
            }
            return null;
        }

        // Traverse - O(n)
        public void TraverseTasks()
        {
            Console.WriteLine("\n🗂️ Task List:");
            if (head == null)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            TaskNode current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        // Delete by ID - O(n)
        public void DeleteTask(int id)
        {
            if (head == null)
            {
                Console.WriteLine("❌ List is empty.");
                return;
            }

            if (head.Data.TaskId == id)
            {
                head = head.Next;
                Console.WriteLine($"🗑️ Deleted task with ID {id}");
                return;
            }

            TaskNode current = head;
            while (current.Next != null && current.Next.Data.TaskId != id)
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                Console.WriteLine($"❌ Task with ID {id} not found.");
            }
            else
            {
                current.Next = current.Next.Next;
                Console.WriteLine($"🗑️ Deleted task with ID {id}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TaskList taskList = new TaskList();

            // Add tasks
            taskList.AddTask(new Task { TaskId = 1, TaskName = "Design Module", Status = "Pending" });
            taskList.AddTask(new Task { TaskId = 2, TaskName = "Implement Feature", Status = "In Progress" });
            taskList.AddTask(new Task { TaskId = 3, TaskName = "Test Code", Status = "Pending" });

            // Traverse
            taskList.TraverseTasks();

            // Search
            Console.WriteLine("\n🔍 Searching for task with ID 2:");
            var found = taskList.SearchTask(2);
            Console.WriteLine(found != null ? $"✅ Found: {found}" : "❌ Not found.");

            // Delete
            Console.WriteLine("\n🗑️ Deleting task with ID 2:");
            taskList.DeleteTask(2);

            // Traverse again
            taskList.TraverseTasks();

            // Time Complexity Summary
            Console.WriteLine("\n📊 Time Complexity:");
            Console.WriteLine("Add (end): O(n)");
            Console.WriteLine("Search: O(n)");
            Console.WriteLine("Traverse: O(n)");
            Console.WriteLine("Delete: O(n)");
            Console.WriteLine("\n✅ Linked lists are better for frequent insertions/deletions compared to arrays.");
            Console.ReadKey();
        }
    }
}
