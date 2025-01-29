using System.Threading.Tasks;
using HumPsi.Domain;
using HumPsi.Domain.Abstraction.IRepositories;

namespace HumPsi.Infrastructure.Repositories;

public class RepositoryWrapper(HumPsiDbContext context) : IRepositoryWrapper
{
    private ISectionRepository _sectionRepository;
    private IHeadlineRepository _headlineRepository;
    private IArticleRepository _articleRepository;

    public ISectionRepository SectionRepository
    {
        get
        {
            if (_sectionRepository is null)
            {
                _sectionRepository = new SectionRepository(context);
            }

            return _sectionRepository;
        }
    }

    // public IHeadlineRepository HeadlineRepository
    // {
    //     get
    //     {
    //         if (_headlineRepository is null)
    //         {
    //             _headlineRepository = new HeadlineRepository(context);
    //         }
    //
    //         return _headlineRepository;
    //     }
    // }
    //
    // public IArticleRepository ArticleRepository
    // {
    //     get
    //     {
    //         if (_articleRepository is null)
    //         {
    //             _articleRepository = new ArticleRepository(context);
    //         }
    //
    //         return _articleRepository;
    //     }
    // }
    
    public async Task<int> SaveChangeAsync()
    {
        return await context.SaveChangesAsync();
    }
}