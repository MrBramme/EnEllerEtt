using Bram.EnEllerEtt.Core.Interface.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Core.Interface.Adapters
{
    public interface IWiktionaryParser
    {
        Task<WordResult> ParseFromHtmlAsync(string html, CancellationToken ct);
    }
}
