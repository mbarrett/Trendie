﻿using Nancy;
using Trendie.Core.Builders;

namespace Trendie.Modules
{
    public class HomeModule : NancyModule
    {
        private readonly IViewModelBuilder _viewModelBuilder;

        public HomeModule(IViewModelBuilder viewModelBuilder)
        {
            _viewModelBuilder = viewModelBuilder;

            Get["/"] = render => Response.AsRedirect("/uk");

            Get["/{country}"] = render =>
            {
                var viewModel = _viewModelBuilder.Build(render.country);
                return View["index", viewModel];
            };
        }
    }
}