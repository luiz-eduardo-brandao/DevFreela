using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;

        public ProjectRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var project = await _context.Projects
               .Include(p => p.Client)
               .Include(p => p.Freelancer)
               .SingleOrDefaultAsync(p => p.Id == id);

            return project;
        }

        public async Task<int> AddAsync(Project project)
        {
            var result = await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            await _context.ProjectComments.AddAsync(projectComment);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
