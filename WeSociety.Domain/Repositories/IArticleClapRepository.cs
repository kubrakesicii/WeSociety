using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Repository;

namespace WeSociety.Domain.Repositories
{
    public interface IArticleClapRepository : IGenericRepository<ArticleClap>
    {
        Task<List<ArticleClap>> GetAllByArticleWithUser(int articleId);
    }
}
