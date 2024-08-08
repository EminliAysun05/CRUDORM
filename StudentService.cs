

using Microsoft.EntityFrameworkCore;

namespace Practice2
{
    public class StudentService
    {
       public async Task CreateStudent(Students students) 
        {
            AppDbContext appDbContext = new AppDbContext();
            var student = await appDbContext.AddAsync(students);
            await appDbContext.SaveChangesAsync();

        }
        public async Task<List<Students>> GetStudentsAsync()
        {
            AppDbContext appDbContext = new AppDbContext();
            var students = await appDbContext.Students.Include(s => s.Group).ToListAsync();
            return students;
        }


    }
}
