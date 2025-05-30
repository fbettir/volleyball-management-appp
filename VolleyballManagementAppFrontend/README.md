MŰER – Műegyetemi Röplabda Rendszer

Telepítés fejlesztői környezetben

A rendszer két fő komponensből áll:

- `VolleyballManagementAppFrontend/` – Angular frontend
- `VolleyballAPI/` – ASP.NET Core backend

Az alábbi lépések alapján helyi környezetben elindítható a teljes alkalmazás.

Követelmények

- Node.js (ajánlott: v18+)
- .NET 8 SDK
- Angular CLI:  
  ```bash
  npm install -g @angular/cli

Frontend indítása

 - cd VolleyballManagementAppFrontend
 - npm install
 - ng serve

Backend indítása

 - cd VolleyballAPI

 Ellenőrizd a appsettings.json fájlban a DefaultConnection beállítást.
 Ha szükséges, módosítsd a saját adatbázisodhoz.

 Hozd létre az adatbázist:
 - dotnet ef database update

 Indítsd el az alkalmazást:
 - dotnet run

 Ezután a rendszer ezen a címen érhető el:
 https://localhost:44359/app/admin