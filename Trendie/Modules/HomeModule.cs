using System;
using Nancy;
using Trendie.Core.Builders;
using Trendie.Core.Models;

namespace Trendie.Modules
{
    public class HomeModule : NancyModule
    {
        private readonly IViewModelBuilder _viewModelBuilder;

        public HomeModule(IViewModelBuilder viewModelBuilder)
        {
            _viewModelBuilder = viewModelBuilder;

            Get["/"] = render => Response.AsRedirect("/aus");

            Get["/{country}"] = render =>
            {
                try
                {
                    var viewModel = _viewModelBuilder.Build(render.country);
                    return View["index", viewModel];
                }
                catch (Exception)
                {
                    return View["error"];
                }

            };
        }
    }
}
