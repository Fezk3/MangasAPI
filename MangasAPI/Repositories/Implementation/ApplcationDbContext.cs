namespace MangasAPI.Repositories.Implementation
{
    public class ApplcationDbContext
    {
        public object Categories { get; internal set; }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}