using BlazorPerformance.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorPerformance.Client.Features.Contribtuions
{
    public partial class ContributionRow
    {
        [Parameter] public Contribution Contribution { get; set; }
        [Parameter] public string SearchTerm { get; set; }
        [Parameter] public EventCallback ItemClicked { get; set; }

        private string _currentTitle = string.Empty;
        private bool _shouldRender = false;

        protected override bool ShouldRender() => true;

        protected override void OnParametersSet()
        {
            _shouldRender = _currentTitle != Contribution.Title;
            _currentTitle = Contribution.Title;
            base.OnParametersSet();
        }

        private void OnItemClicked()
        {
            ItemClicked.InvokeAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            Console.WriteLine($"Rendered conribution {Contribution?.Id}");
            base.OnAfterRender(firstRender);
        }
    }
}