using Bram.EnEllerEtt.Core.Interface.Adapters;
using NUnit.Framework;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.UnitTests
{
    public class WiktionaryParserUnitTests
    {
        private IWiktionaryParser _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new WiktionaryParser();
        }
    }
}
