using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlagDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> Logger;
        private readonly IFeatureManagerSnapshot FeatureManager;

        public string Title { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IFeatureManagerSnapshot featureManager)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            FeatureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
        }

        public async Task OnGet()
        {
            if (await FeatureManager.IsEnabledAsync("beta"))
                Title = "Beta Version";
            else
                Title = "Production Version";
        }
        
    }
}
