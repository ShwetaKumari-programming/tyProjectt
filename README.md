# ElmechProject

ASP.NET MVC 5 + Web API 2 application with an AngularJS 1.x SPA front-end and an admin portal. Includes a separate `Data` class library using Entity Framework 6.x for data access against SQL Server.

> Built for .NET Framework 4.6; ideal for Hacktoberfest contributions.

## Tech stack
- Backend: ASP.NET MVC 5, Web API 2, OWIN, ASP.NET Identity 2.2.1
- Data: Entity Framework 6.x, SQL Server (LocalDB/SQL Express/SQL Server)
- Frontend: AngularJS 1.6, UI-Router 0.4, Bootstrap 3, jQuery 1.x
- Build: Visual Studio 2017+ (or MSBuild), NuGet

## Repository layout
```
./
├─ ElmechProject/           # ASP.NET MVC/Web API web app (IIS/IIS Express)
│  ├─ App/                  # Public SPA (AngularJS) area
│  │  ├─ core/              # Angular app bootstrapping & routing
│  │  └─ views/             # Feature views & controllers (home, catalog, etc.)
│  ├─ App_Admin/            # Admin SPA (AngularJS) area
│  │  ├─ core/
│  │  └─ view/
│  ├─ Controllers/          # MVC + API controllers
│  ├─ Models/               # View models and Identity models
│  ├─ Views/                # Razor views and shared layout
│  ├─ Web.config            # App configuration (connection strings, redirects)
│  └─ packages.config       # NuGet packages for the web app
├─ Data/                    # Class library for EF models & DbContext
│  ├─ *.cs                  # POCO entities (Order, Product, Catalog, etc.)
│  ├─ ElmechContext.cs      # EF6 DbContext
│  ├─ App.config            # EF provider configuration
│  └─ packages.config       # NuGet packages for the data project
└─ Views/                   # Ancillary project (not used at runtime)
```

## Prerequisites
- Windows 10/11
- Visual Studio 2017 or newer (Community is fine) with:
  - .NET Framework 4.6 targeting pack
  - Web development workload
- SQL Server (LocalDB or SQL Express/SQL Server)
- NuGet (bundled with Visual Studio)

## Quick start (Visual Studio)
1. Open `ElmechProject/ElmechProject.csproj` in Visual Studio.
2. Restore NuGet packages when prompted (or right click Solution → Restore).
3. Update connection strings in `ElmechProject/Web.config` to point to your SQL instance:
   - `DefaultConnection`
   - `ElmechContext`
4. Press F5 to run with IIS Express.

The AngularJS SPA is served from `ElmechProject/App` and the admin portal from `ElmechProject/App_Admin` under the same site.

## Quick start (command line)
```powershell
# From repo root
nuget restore .\ElmechProject\ElmechProject.csproj
nuget restore .\Data\Data.csproj

# Build (Debug)
"%ProgramFiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe" .\ElmechProject\ElmechProject.csproj /p:Configuration=Debug
```

To run locally, prefer Visual Studio + IIS Express. Self-hosting via OWIN is not configured for production use.

## Configuration
Key settings live in `ElmechProject/Web.config`:
- `connectionStrings` → update `DefaultConnection` and `ElmechContext` for your SQL server. Example:
  ```xml
  <add name="ElmechContext" connectionString="data source=.\\SQLEXPRESS;initial catalog=MotorProject;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
  ```
- `compilation`/`httpRuntime` target .NET Framework 4.6.
- Binding redirects for OWIN, JSON.NET, MVC, etc. are already included.

Environment transforms: `Web.Debug.config` and `Web.Release.config` are present. Adjust or add transforms as needed.

## Database
- EF6 is used with `ElmechContext`. Ensure your database exists and the configured user can connect.
- If starting fresh, create an empty database matching the `initial catalog` and let the app create tables if migrations/initializer are enabled. Otherwise, restore a backup that matches the expected schema.

## Common features (high level)
- Public site: home, catalog, product details, view cart, checkout, login/registration, account, contact, inquiries, etc.
- Admin: catalog/category management, product management, order and inquiry management, user management, dashboard.

## Contributing (Hacktoberfest-friendly)
We welcome contributions! Suggested steps:
1. Fork the repo and create a feature branch (e.g., `feat/catalog-filters`).
2. Make focused changes with descriptive commit messages.
3. Test locally (build succeeds; run basic flows).
4. Open a Pull Request to `master` with a clear description and screenshots where relevant.

Guidelines:
- Keep C# code readable and consistent; prefer clear names and simple control flow.
- For AngularJS, keep controllers lean; prefer services/factories for shared logic; avoid global scope.
- UI changes should remain Bootstrap 3 compatible.
- Avoid introducing breaking changes without discussion in an issue first.

Good first contribution ideas:
- Improve client-side validation on forms.
- Add loading/error states to Angular views.
- Strengthen server-side null/empty checks in controllers.
- Replace hardcoded strings with constants/resources.

## Troubleshooting
- Build fails with missing packages: run `nuget restore` for both `ElmechProject` and `Data` projects.
- Version conflicts (binding redirects): clean and rebuild; verify `Web.config` redirects; delete `bin/` and `obj/` if needed.
- SQL connection errors: verify server name, authentication mode, and firewall; try LocalDB/SQL Express.
- 404s for SPA routes: ensure IIS Express is used and `ExtensionlessUrlHandler-Integrated-4.0` is configured (present in `Web.config`).

## License
No explicit license is included. If you plan to use this code beyond Hacktoberfest, please open an issue to discuss licensing.
