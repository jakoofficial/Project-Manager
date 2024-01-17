using EFGetStarted;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main(string[] args)
    {
        using var db = new BloggingContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        //seedTasks();

        using (BloggingContext context = new())
        {
            var tasks = context.Tasks.Include(task => task.Todos);
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task: {task.Name}");
                foreach (var todo in task.Todos)
                {
                    Console.WriteLine($"- {todo.Name}");
                }
            }
        }

        // Create
        //Console.WriteLine("Inserting a new blog");
        db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
        db.SaveChanges();

        // Read
        //Console.WriteLine("Querying for a blog");
        var blog = db.Blogs
            .OrderBy(b => b.BlogId)
            .First();

        // Update
        //Console.WriteLine("Updating the blog and adding a post");
        blog.Url = "https://devblogs.microsoft.com/dotnet";
        blog.Posts.Add(
            new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
        db.SaveChanges();

        // Delete
        //Console.WriteLine("Delete the blog");
        db.Remove(blog);
        db.SaveChanges();

        printIncompleteTasksAndTodos();

        seedWorkers();

        Console.ReadLine();
    }

    static void printIncompleteTasksAndTodos()
    {
        using (var context = new BloggingContext())
        {
            var tasks = context.Tasks.Include(
                task => task.Todos).Where(
                task => task.Todos.Any(
                todo => !todo.IsCompleted)).ToList();

            foreach (var task in tasks)
            {
                Console.WriteLine($"\ntask: {task.Name}");
                foreach (var todo in task.Todos)
                {
                    Console.WriteLine($"todo: {todo.Name} | status: {todo.IsCompleted}");
                }
            }
        }
    }

    static void seedWorkers()
    {
        using (BloggingContext context = new())
        {
            AddTeamWorker(context, "Steen Secher", "Fronted");
            context.SaveChanges();
            AddTeamWorker(context, "Ejvind Møller", "Fronted");
            context.SaveChanges();
            AddTeamWorker(context, "Konrad Sommer", "Fronted");
            context.SaveChanges();

            AddTeamWorker(context, "Sofus Lotus", "Backend");
            context.SaveChanges();
            AddTeamWorker(context, "Remo Lademann", "Backend");
            context.SaveChanges();
            AddTeamWorker(context, "Konrad Sommer", "Backend");

            AddTeamWorker(context, "Steen Secher", "Testere");
            context.SaveChanges();
            AddTeamWorker(context, "Ella Fanth", "Testere");
            context.SaveChanges();
            AddTeamWorker(context, "Anna Dam", "Testere");
            context.SaveChanges();

            //context.SaveChanges();
        }
    }

    static void AddTeamWorker(BloggingContext context, string workerName, string teamName)
    {
        // Check if the team with the given name already exists
        Team existingTeam = context.Teams.SingleOrDefault(t => t.Name == teamName);
        Worker existingWorker = context.Workers.SingleOrDefault(w => w.Name == workerName);

        if (existingTeam == null)
        {
            // If the team doesn't exist, create a new team and add the team worker
            Team newTeam = new Team { Name = teamName };
            context.Teams.Add(newTeam);

            if (existingWorker == null)
            {
                context.TeamWorkers.Add(new TeamWorker()
                {
                    Worker = new Worker { Name = workerName },
                    Team = newTeam
                });
            }
            else
            {
                context.TeamWorkers.Add(new TeamWorker()
                {
                    Worker = existingWorker,
                    Team = newTeam
                });
            }
        }
        else
        {
            if (existingWorker == null)
            {
                // If the team already exists, add the team worker only
                context.TeamWorkers.Add(new TeamWorker()
                {
                    Worker = new Worker { Name = workerName },
                    Team = existingTeam
                });
            }
            else
            {
                context.TeamWorkers.Add(new TeamWorker()
                {
                    Worker = existingWorker,
                    Team = existingTeam
                });
            }
        }
    }

    static void seedTasks()
    {
        Tasks t1 = new Tasks(1, "Produce software", new List<Todo>()
        {
            new Todo(1,"Write code", false),
            new Todo(2,"Compile source", false),
            new Todo(3,"Test program", false),
        });
        Tasks t2 = new Tasks(2, "Brew coffee,", new List<Todo>()
        {
            new Todo(4,"Pour water", false),
            new Todo(5,"coffee", false),
            new Todo(6,"Turn on", false),
        });

        using (BloggingContext context = new())
        {
            context.Tasks.Add(t1);
            context.Tasks.Add(t2);
            context.SaveChanges();
        }

    }
}