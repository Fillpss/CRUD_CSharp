using System;
using System.Linq;

using var database = new BloggingContext();

Console.WriteLine($"Database path: {database.DbPath}");

// Create 
Console.WriteLine("Inserting a new blog");
database.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
database.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = database.Blogs.OrderBy(b => b.BlogId).FirstOrDefault();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
database.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
database.Remove(blog);


// Atualizar os dados do banco
database.SaveChanges();