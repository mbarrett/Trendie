using Trendie.Core.Models;

namespace Trendie.Core.Builders
{
    public interface IViewModelBuilder
    {
        ViewModel Build(string searchterm);
    }
}