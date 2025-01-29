using System.Threading.Tasks;

namespace HumPsi.Domain.Abstraction.IRepositories;

public interface IRepositoryWrapper
{ 
    ISectionRepository SectionRepository { get; }
    // IHeadlineRepository headlineRepository { get; }
    // IArticleRepository ArticleRepository { get;  }

    public Task<int> SaveChangeAsync();
}