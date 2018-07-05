using System;
using Persons3.ViewModels;
using Persons3.API;
using Persons3.Implementation;
using Persons3.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Persons3
{
	public partial class App : PrismApplication
	{
	    public App(IPlatformInitializer initializer) : base(initializer)
	    {
	        
	    }

	    protected override void RegisterTypes(IContainerRegistry containerRegistry)
	    {
	        containerRegistry.RegisterForNavigation<PersonsView>();
            containerRegistry.RegisterSingleton<IPersonHandler, PersonHandler>();
	    }

	    protected override async void OnInitialized()
	    {
            InitializeComponent();

	        await this.NavigationService.NavigateAsync("PersonsView");
	    }
	}
}
