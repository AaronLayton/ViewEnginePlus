ViewEnginePlus
==============

#### Hit "Watch" / "Star" to make sure you get updates

An upgraded ViewEngine for MVC that supports skins, language based changes and debug only views

-------

#### Global.asax.cs
```csharp
protected void Application_Start()
{
	AreaRegistration.RegisterAllAreas();

	RegisterGlobalFilters(GlobalFilters.Filters);
	RegisterRoutes(RouteTable.Routes);

	// Clear all old ViewEngines and register our RazorThemeViewEngine
	System.Web.Mvc.ViewEngines.Engines.Clear();
	
	// NOTE: use either view engine as required to avoid performance penalties
	System.Web.Mvc.ViewEngines.Engines.Add(new ViewEnginePlus.ViewEngines.RazorThemeViewEngine());
	//System.Web.Mvc.ViewEngines.Engines.Add(new ViewEnginePlus.ViewEngines.WebFormThemeViewEngine());
}
```