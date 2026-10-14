# TurnStileController

A Windows desktop application that connects to **IDS ID Model** turnstile / access controllers and keeps them in sync with the IDS Access database.

## Features

- Connects to multiple IDS ID Model controllers over TCP and shows live status (Online / Offline)
- Uploads **users and cards** from the database to each controller
- **Blocks and revokes** cards on the controller when they are blocked or revoked in the system
- Downloads **entry / exit logs** and real-time transactions from the controllers
- Updates controller status and logs in the database
- Manual tools: open door, get user, bulk upload users from Excel

## Auto Sync

| Task | Frequency |
|---|---|
| New users and cards upload | Every 1 minute |
| Block / revoke list upload | Every 30 minutes |
| Full access file upload and log download | Every 12 hours |

Each controller is matched by its own IP and channel, so several controllers can run at the same time without mixing up data.

## Tech Stack

- C# Windows Forms, .NET Framework 4.8
- SQL Server (IDS Access database)
- TCP communication with IDS ID Model controllers

## Setup

1. Clone the repo and open `Demo_CSharp.sln` in Visual Studio.
2. Update the `constr` connection string in `app.config` with your SQL Server details.
3. Add your controllers (IP, port, type) in the reader table of the database.
4. Build and run. The app listens for controller connections on port **2000**.

## Logs

Errors are saved to `Logs\AppLog_yyyyMMdd.txt` next to the exe.

## Note

Do not commit real database passwords to GitHub. Keep them only in your local `app.config`.

## Author

**Prashant Pawar** - [@prashantpawarids-dot](https://github.com/prashantpawarids-dot)
