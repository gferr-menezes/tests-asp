using api;

public class RepositoryBase {

    protected readonly ApiDbContext _context;

    public RepositoryBase(ApiDbContext context) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

}
