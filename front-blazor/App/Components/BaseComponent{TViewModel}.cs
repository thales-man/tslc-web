using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Front.Services.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Front.Components
{
    public abstract class BaseComponent<TViewModel> :
        ComponentBase,
        IDisposable
        where TViewModel : class, IComposable, INotifyPropertyChanged
    {
        [Inject]
        public TViewModel ViewModel { get; set; }

        [Inject]
        public NavigationManager Navigator { get; set; }

        public void Dispose()
        {
            Navigator.LocationChanged -= OnLocationChanged;
            ViewModel.PropertyChanged -= OnPropertyChanged;
        }

        public Uri GetLocation() =>
            new Uri(Navigator.Uri ?? "/");

        protected override async Task OnInitializedAsync()
        {
            Navigator.LocationChanged += OnLocationChanged;
            ViewModel.PropertyChanged += OnPropertyChanged;

            await ViewModel.Compose();
        }

        protected virtual async Task OnRouteChanged(Uri newRoute)=>
            await Task.CompletedTask;

        private async void OnLocationChanged(object sender, LocationChangedEventArgs e)=>
            await OnRouteChanged(new Uri(e.Location));

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e) =>
            StateHasChanged();
    }
}
