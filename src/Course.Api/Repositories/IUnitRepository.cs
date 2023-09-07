using Course.Api.Context;

namespace Course.Api.Repositories;

public interface IUnitRepository
{
    ICourseRepository Courses { get; }

    IContentRepository Contents { get; }

    IDataRepository Data { get; }
}


public class UnitRepository : IUnitRepository
{
    private readonly CourseDbContext _context;

    public UnitRepository(CourseDbContext context)
    {
        _context = context;
    }

    private ICourseRepository? _courseRepository;
    public ICourseRepository Courses => _courseRepository ??= new CourseRepository(_context);

    private IContentRepository? _contentRepository;
    public IContentRepository Contents => _contentRepository ??= new ContentRepository(_context, Courses);

    private IDataRepository? _dataRepository;
    public IDataRepository Data => _dataRepository ??= new DataRepository(_context, Contents);
}