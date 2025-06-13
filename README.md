# How to setup the app?

1. Run db:
    1. configure db env via creating `db.env`
    2. `docker compose up -d`

2. Setup dotnet user secrets:

```
cd RevenueRecognitionSystem.Api
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<connection_string_according_to_db_env>"
```

3. Run the app
```
cd RevenueRecognitionSystem.Api
dotnet run
```

