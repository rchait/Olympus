using System;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Entities;
using ProjectManagement.Entities.Enums;

namespace ProjectManagement.Shared
{
    public class PMContext : DbContext
    {
        public PMContext(DbContextOptions<PMContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public void SeedInitialData()
        {
            User user1 = new User { ID = 1, FirstName = "Anusha", LastName = "Sharma", Email = "anusha.sharma@gmail.com" };
            User user2 = new User { ID = 2, FirstName = "Amit", LastName = "Gupta", Email = "amit.gupta@gmail.com" };
            User user3 = new User { ID = 3, FirstName = "Dharmendra", LastName = "K", Email = "dharmendra.k@gmail.com" };
            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);

            Task task1 = new Task { ID = 1, ProjectID = 1, Status = TaskStatus.Completed, AssignedToUserID = 1, CreatedOn = DateTime.Now, Detail = "Task 1 detail" };
            Task task2 = new Task { ID = 2, ProjectID = 2, Status = TaskStatus.QA, AssignedToUserID = 2, CreatedOn = DateTime.Now, Detail = "Task 2 detail" };
            Task task3 = new Task { ID = 3, ProjectID = 3, Status = TaskStatus.InProgress, AssignedToUserID = 3, CreatedOn = DateTime.Now, Detail = "Task 3 detail" };
            Tasks.Add(task1);
            Tasks.Add(task2);
            Tasks.Add(task3);

            Project project1 = new Project { ID = 1, Name = "Project 1", CreatedOn = DateTime.Now, Detail = "Project 1 detail" };
            Project project2 = new Project { ID = 2, Name = "Project 2", CreatedOn = DateTime.Now, Detail = "Project 2 detail" };
            Project project3 = new Project { ID = 3, Name = "Project 3", CreatedOn = DateTime.Now, Detail = "Project 3 detail" };
            Projects.Add(project1);
            Projects.Add(project2);
            Projects.Add(project3);
            this.SaveChanges();
        }
    }
}
