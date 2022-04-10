using System;
using System.Collections.Generic;
using DisplayMe.Controllers;
using Microsoft.Extensions.Localization;

namespace DisplayMe.Models
{
    public class RegionStatus
    {
       
        public bool Status { get; set; }
        public bool? PredictedOn { get; set; }
        public double? PredictedOffMinutes { get; set; }
        public double? ProbabilityOn { get; set; }

        public string GetRowClass()
        {
            if (!Status)
            {
                return PredictedOn.HasValue && PredictedOn.Value ? " yellow" : " green";
            }

            return " red";
        }

        public string GetPrediction(IStringLocalizer<HomeController> localizer)
        {
            return PredictedOn.HasValue
                ? $"{ProbabilityOn * 100:0.0}% - {(PredictedOn.Value ? localizer["готуйсь!"] : localizer["такоє"])}"
                : (PredictedOffMinutes.HasValue ? $"~ {PredictedOffMinutes:0}{localizer["хв ще"].Value}" : string.Empty);
        }
    }

    public class TryvohaPayload
    {
        public DateTime LastUpdateTime { get; set; }
        public Dictionary<string, RegionStatus> Regions { get; set; }
        public List<string> ModelEvaluations { get; set; }
    }
}
