using Bram.EnEllerEtt.Core.Interface.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Core.Interface.Services
{
    public interface IWordLookupService
    {
        Task<WordResult> GetResultForWordAsync(string word, CancellationToken ct);
    }
}
