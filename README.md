
# Resort API

## What is the use of this Repo
This project is a Web API used to manage Hotels and Reservations.<br>
It allows users to get, post, update, and delete information about hotels and reservations.

## Endpoints

<details>
  <summary>Hotels</summary>
<br>

| Endpoint                    | Description                  | Method |
|-----------------------------|------------------------------|--------|
| /api/hotel                  | Create or edit a hotel       | POST   |
| /api/hotel                  | Update hotel information     | PUT    |
| /api/hotel                  | Delete hotel                 | DELETE |
| /api/hotel                  | Find hotels                  | GET    |

</details>

<details>
  <summary>Reservations</summary>
<br>

| Endpoint                    | Description                      | Method |
|-----------------------------|----------------------------------|--------|
| /api/reservation            | Create or edit a reservation     | POST   |
| /api/reservation            | Update reservation information   | PUT    |
| /api/reservation            | Delete reservation               | DELETE |
| /api/reservation            | Find reservations                | GET    |

</details>

## Used Technologies and Packages

1. .Net Framework
2. Microsoft.EntityFrameworkCore
3. Microsoft.EntityFrameworkCore.Design
5. Microsoft.EntityFrameworkCore.SqlServer
6. Swashbuckle.AspNetCore

## Project Structure
```
├── Controllers
│ └── HotelController.cs
│ └── ReservationController.cs
├── Data
│ └── DataContext.cs
├── Migrations
├── Models
│ └── Hotel.cs
│ └── Reservation.cs
├── Properties
│ └── launchSettings.json
├── appsettings.json
├── Program.cs
├── Startup.cs
```
## Versions

### .Net 8.0

Refer to [https://dotnet.microsoft.com/en-us/](https://dotnet.microsoft.com/en-us/) to install .Net 8.0

## Setting Up

To setup this project, you need to clone the git repo

```sh
$ git clone https://github.com/MFalek/ResortApi.git
$ cd Hotels
```

followed by

```sh
$ dotnet restore
```

in order to connect to database you need to create appsettings.Development.json file with following settings:

```
{
  "ConnectionStrings": {
    "WebApiDatabase": "Host=DBHost; Database=DBName; Username=username; Password=password"
  }
}
```

to migrate database use

```sh
$ dotnet ef migrations add initialMigration
$ dotnet ef database update
```

