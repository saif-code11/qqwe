using Microsoft.EntityFrameworkCore;

namespace Quizone.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<ClassRoom> classRooms { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<ApplacationUser> ApplacationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships

            modelBuilder.Entity<ClassRoom>()
                .HasMany(c => c.students)
                .WithOne(s => s.ClassRoom)
                .HasForeignKey(s => s.CLassRoomId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Teachers)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepatmentId);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Subject)
                .HasForeignKey(e => e.SubjectId);


            // Indexes

            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new
                {
                    e.SubjectId,
                    e.StudentId
                })
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Teacher>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Department>()
                .HasIndex(e => e.Name)
                .IsUnique();


            // Precision

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Salary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Grade)
                .HasPrecision(10, 2);


            // =========================
            // DATA SEEDING
            // =========================

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Computer Science",
                    Description = "Computer Science Department"
                },
                new Department
                {
                    Id = 2,
                    Name = "Mathematics",
                    Description = "Mathematics Department"
                },
                new Department
                {
                    Id = 3,
                    Name = "Physics",
                    Description = "Physics Department"
                }
            );


            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FirstName = "Ahmed",
                    LastName = "Ali",
                    Email = "ahmed.ali@school.com",
                    PhoneNumber = "01011111111",
                    Salary = 15000,
                    DepatmentId = 1
                },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Sara",
                    LastName = "Mohamed",
                    Email = "sara.mohamed@school.com",
                    PhoneNumber = "01022222222",
                    Salary = 14000,
                    DepatmentId = 2
                },
                new Teacher
                {
                    Id = 3,
                    FirstName = "Omar",
                    LastName = "Hassan",
                    Email = "omar.hassan@school.com",
                    PhoneNumber = "01033333333",
                    Salary = 14500,
                    DepatmentId = 3
                }
            );


            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "C# Programming",
                    Description = "Introduction to C# programming",
                    MaxGrade = 100,
                    TeacherId = 1
                },
                new Subject
                {
                    Id = 2,
                    Name = "Database",
                    Description = "SQL Server and Database fundamentals",
                    MaxGrade = 100,
                    TeacherId = 1
                },
                new Subject
                {
                    Id = 3,
                    Name = "Mathematics",
                    Description = "Basic Mathematics",
                    MaxGrade = 100,
                    TeacherId = 2
                },
                new Subject
                {
                    Id = 4,
                    Name = "Physics",
                    Description = "Physics fundamentals",
                    MaxGrade = 100,
                    TeacherId = 3
                }
            );


            modelBuilder.Entity<ClassRoom>().HasData(
                new ClassRoom
                {
                    Id = 1,
                    Name = "Class A",
                    GradeLevel = 10,
                    Capacity = 30
                },
                new ClassRoom
                {
                    Id = 2,
                    Name = "Class B",
                    GradeLevel = 11,
                    Capacity = 25
                },
                new ClassRoom
                {
                    Id = 3,
                    Name = "Class C",
                    GradeLevel = 12,
                    Capacity = 30
                }
            );


            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Mohamed Ahmed",
                    FirstName = "Mohamed",
                    Email = "mohamed@student.com",
                    Phone = "01111111111",
                    Date = new DateTime(2008, 5, 10),
                    CLassRoomId = 1
                },
                new Student
                {
                    Id = 2,
                    Name = "Ali Hassan",
                    FirstName = "Ali",
                    Email = "ali@student.com",
                    Phone = "01122222222",
                    Date = new DateTime(2007, 8, 15),
                    CLassRoomId = 1
                },
                new Student
                {
                    Id = 3,
                    Name = "Mariam Ahmed",
                    FirstName = "Mariam",
                    Email = "mariam@student.com",
                    Phone = "01133333333",
                    Date = new DateTime(2006, 3, 20),
                    CLassRoomId = 2
                },
                new Student
                {
                    Id = 4,
                    Name = "Youssef Mohamed",
                    FirstName = "Youssef",
                    Email = "youssef@student.com",
                    Phone = "01144444444",
                    Date = new DateTime(2006, 11, 2),
                    CLassRoomId = 3
                }
            );


            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = 1,
                    StudentId = 1,
                    SubjectId = 1,
                    EnrollmentTime = new DateTime(2026, 9, 1),
                    Grade = 90
                },
                new Enrollment
                {
                    Id = 2,
                    StudentId = 1,
                    SubjectId = 2,
                    EnrollmentTime = new DateTime(2026, 9, 1),
                    Grade = 85
                },
                new Enrollment
                {
                    Id = 3,
                    StudentId = 2,
                    SubjectId = 1,
                    EnrollmentTime = new DateTime(2026, 9, 2),
                    Grade = 95
                },
                new Enrollment
                {
                    Id = 4,
                    StudentId = 2,
                    SubjectId = 3,
                    EnrollmentTime = new DateTime(2026, 9, 2),
                    Grade = 88
                },
                new Enrollment
                {
                    Id = 5,
                    StudentId = 3,
                    SubjectId = 3,
                    EnrollmentTime = new DateTime(2026, 9, 3),
                    Grade = 92
                },
                new Enrollment
                {
                    Id = 6,
                    StudentId = 4,
                    SubjectId = 4,
                    EnrollmentTime = new DateTime(2026, 9, 3),
                    Grade = 87
                }
            );

            modelBuilder.Entity<ApplacationUser>().HasData(
    new ApplacationUser
    {
        Id = 1,
        Role = "admin",
        Email = "admin@school.com",
        Password = "Admin@123",
        Name = "School Admin"
    },
    new ApplacationUser
    {
        Id = 2,
        Role = "teacher",
        Email = "teacher@school.com",
        Password = "Teacher@123",
        Name = "School Teacher"
    },
    new ApplacationUser
    {
        Id = 3,
        Role = "student",
        Email = "student@school.com",
        Password = "Student@123",
        Name = "School Student"
    }
);


        }
    }
}
