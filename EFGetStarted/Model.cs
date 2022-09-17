using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }
    
    public BloggingContext()
    {
      // Insira aqui o seu caminho raiz para criar o arquivo do banco
      DbPath = "D:\\ArvoreDesenvolvimento\\EFGetStarted\\banco.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Data { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}