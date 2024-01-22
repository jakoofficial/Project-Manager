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

        //printIncompleteTasksAndTodos();
        
        if(db.Tasks.Count() < 1) {
            seedTasks(db);
        }
        if(db.Teams.Count() < 1) {
            seedWorkers();
        }

        PrintTeamsWithoutTasks();

        Console.ReadLine();
    }

    static void seedWorkers(){
        
        //Todos & Tasks
        Todo fTodo = new(){Name = "Frontend Todo", IsCompleted=true};
        Todo bTodo = new(){Name = "Backend Todo", IsCompleted=false};
        Todo tTodo = new(){Name = "Testere Todo", IsCompleted=false};
        Todo rTodo = new(){Name = "Re Todo", IsCompleted=false};

        Tasks fTask = new(){Name = "Frontend Tasks", Todos = new List<Todo>(){
            fTodo
        }};
        Tasks bTask = new(){Name = "Backend Tasks", Todos = new List<Todo>(){
            bTodo
        }};
        Tasks tTask = new(){Name = "Testere Tasks", Todos = new List<Todo>(){
            tTodo
        }};

        //Frontend
        Worker Steen = new(){Name = "Steen Secher", Current = fTodo};
        Worker Ejvind = new(){Name = "Ejvind Møller", Current = fTodo};
        Worker Konrad = new(){Name = "Konrad Sommer", Current = fTodo};
        
        Team Frontend = new(){ Name="Frontend", Current = fTask };


        //Backend //Including Konrad
        Worker Sofus = new(){Name = "Sofus Lotus", Current = bTodo};
        Worker Remo = new(){Name = "Remo Lademann", Current = bTodo};
        Team Backend = new(){ Name="Backend", Current = bTask };
        
        //Testere //Including Steen
        Worker Ella = new(){Name = "Ella Fanth", Current = tTodo};
        Worker Anne = new(){Name = "Anne Dam", Current = tTodo};
        Team Testere = new(){ Name="Testere", Current = tTask };

        Team noTaskTeam = new(){Name = "NoTaskTeam"};

        using( var ctx = new BloggingContext()){
            ctx.TeamWorkers.Add(new TeamWorker(){Team = Frontend, Worker = Steen});
            ctx.TeamWorkers.Add(new TeamWorker(){Team = Frontend, Worker = Ejvind});
            ctx.TeamWorkers.Add(new TeamWorker(){Team = Frontend, Worker = Konrad});
            
            ctx.TeamWorkers.Add(new TeamWorker(){Team = Backend, Worker = Sofus});
            ctx.TeamWorkers.Add(new TeamWorker(){Team = Backend, Worker = Remo});
            ctx.TeamWorkers.Add(new TeamWorker(){Team = Backend, Worker = Konrad});

            ctx.TeamWorkers.Add(new TeamWorker(){Team = Testere, Worker = Steen});
            ctx.TeamWorkers.Add(new TeamWorker(){Team = Testere, Worker = Ella});
            ctx.TeamWorkers.Add(new TeamWorker(){Team = Testere, Worker = Anne});

            ctx.TeamWorkers.Add(new TeamWorker(){Team = noTaskTeam, Worker = Ejvind});
            ctx.SaveChanges();
        }
    }

    static List<Team> PrintTeamsWithoutTasks(){
        List<Team> noTaskTeams = new();
        using (var ctx = new BloggingContext()) {
            var teamsNoTasks = ctx.Teams
                .Where(t=>t.Current == null);
            
            foreach (var t in teamsNoTasks) {
                noTaskTeams.Add(t);
                Console.WriteLine(t.Name +" | No (current)tasks");
            }
        }

        return new();
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
    static bool checkTaskExistence(BloggingContext db, Tasks t){
        Tasks oTask = db.Tasks.SingleOrDefault(e => e.Name == t.Name);
        
        if(oTask == null) return true;
        else return false;
    }

    static void seedTasks(BloggingContext db)
    {
        Todo to1 = new(){Name = "Write code", IsCompleted=false};
        Todo to2 = new(){Name = "Compile Source", IsCompleted=false};
        Todo to3 = new(){Name = "Test program", IsCompleted=false};

        Todo to4 = new(){Name = "Pour water", IsCompleted=false};
        Todo to5 = new(){Name = "Coffee", IsCompleted=false};
        Todo to6 = new(){Name = "Turn on", IsCompleted=false};

        Tasks t1 = new(){Name = "Produce software", Todos = new List<Todo>(){
            to1, to2, to3
        }};
        
        Tasks t2 = new(){Name = "Brew coffee", Todos = new List<Todo>(){
            to4, to5, to6
        }};
        using (BloggingContext context = new())
        {
            if(checkTaskExistence(db, t1)){
                context.Tasks.Add(t1);
            }
            if(checkTaskExistence(db, t2)){
                context.Tasks.Add(t2);
            }
            context.SaveChanges();
        }

    }
}