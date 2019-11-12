using VumbaSoft.AdventureWorks.Components.Extensions;
using Xunit;

namespace VumbaSoft.AdventureWorks.Objects.Tests
{
    public class RoleViewTests
    {
        [Fact]
        public void RoleView_CreatesEmpty()
        {
            MvcTree actual = new RoleView().Permissions;

            Assert.Empty(actual.SelectedIds);
            Assert.Empty(actual.Nodes);
        }
    }
}
