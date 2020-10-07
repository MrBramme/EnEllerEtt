using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Core.Interface
{
    public interface IRestService
    {
        Task<string> GetHtmlForWordAsync(string word, CancellationToken ct);
    }
}
