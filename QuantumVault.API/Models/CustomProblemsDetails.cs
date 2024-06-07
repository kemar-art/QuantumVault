using Microsoft.AspNetCore.Mvc;

namespace QuantumVault.API.Models
{
    public class CustomProblemsDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
