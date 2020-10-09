using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Core.Interface.Adapters
{
    public interface IRestService
    {
        Task<string> GetHtmlForWordAsync(string word, CancellationToken ct);
    }
}
