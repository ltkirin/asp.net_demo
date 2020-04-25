using AspDemo.DomainModel.common.entity;

namespace AspDemo.DomainModel.common.command
{
    public class SearchQueryBase<TEntity> where TEntity : EntityBase
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
