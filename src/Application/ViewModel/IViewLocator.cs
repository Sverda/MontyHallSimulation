namespace Application.ViewModel
{
    public interface IViewLocator
    {
        Type? GetViewForViewModel(Type viewModel);
    }
}