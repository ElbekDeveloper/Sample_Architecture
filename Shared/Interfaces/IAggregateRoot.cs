// Apply this marker interface only to aggregate root entities
// Repositories will only work with aggregate roots, not their children
namespace Shared.Interfaces
{
    public interface IAggregateRoot
    {
    }
}
