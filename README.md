# JLOrdaz.TelegramBotMessage

`JLOrdaz.TelegramBotMessage` is a small library for sending notification messages to a Telegram chat from your applications.

This is a `2.0.0` release with breaking changes and a modern multi-target setup.

[![NuGet](https://img.shields.io/nuget/v/JLOrdaz.TelegramBotMessage?style=for-the-badge)](https://www.nuget.org/packages/JLOrdaz.TelegramBotMessage)

## Features

- Simple API for sending Telegram messages
- Built-in helpers for info, warning, and error notifications
- `async`/`await` friendly API
- Cancellation support
- Safe MarkdownV2 escaping for message content
- Compatible with `netstandard2.1` and `net10.0`

## Target Frameworks

- `netstandard2.1`
- `net10.0`

## Installation

Install the package from NuGet:

```powershell
Install-Package JLOrdaz.TelegramBotMessage
```

or with the .NET CLI:

```powershell
dotnet add package JLOrdaz.TelegramBotMessage
```

## Quick Start

```csharp
using JLOrdaz.TelegramBotMessage;

var notifier = new TelegramNotifier("YOUR_BOT_TOKEN", "YOUR_CHAT_ID");

await notifier.SendMessageAsync("Hello from my app!");
await notifier.SendInfoMessageAsync("The deployment finished successfully.");
await notifier.SendWarningMessageAsync("Disk space is running low.");
await notifier.SendErrorMessageAsync("An unexpected error occurred.");
```

## API Overview

### `TelegramNotifier`

Main entry point for sending notifications to a Telegram chat.

#### Constructor

```csharp
new TelegramNotifier(string botToken, string chatId)
```

#### Methods

- `SendMessageAsync(string message, CancellationToken cancellationToken = default)`
- `SendInfoMessageAsync(string message, CancellationToken cancellationToken = default)`
- `SendWarningMessageAsync(string message, CancellationToken cancellationToken = default)`
- `SendErrorMessageAsync(string message, CancellationToken cancellationToken = default)`

## Notes

- The library formats messages using Telegram MarkdownV2 mode.
- Special characters are escaped automatically before sending.
- MarkdownV2 reserved characters are handled for standard notification text and timestamps.
- The public API is intentionally small and simple.
- `TelegramNotifier` implements `IDisposable` and should be disposed when no longer needed.

## Version

- Current version: `2.0.0`
- This version introduces breaking changes from earlier releases

## Package

- Author: Jose Luis Ordaz
- Repository: https://github.com/JLOrdaz/JLOrdaz.TelegramBotMessage
- NuGet: https://www.nuget.org/packages/JLOrdaz.TelegramBotMessage
