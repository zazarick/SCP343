# SCP-343 (Exiled Plugin) / SCP-343 (Exiled Плагин)

---

## English

**Description:**  
A plugin for SCP:SL (Exiled) that adds SCP-343 ("God"). At the start of the round, a random D-CLASS player becomes SCP-343. Any item SCP-343 picks up turns into a medkit, and any weapon turns into a configurable item (for example, SCP-500). Upon spawning, SCP-343 receives medkits, bypass and godmode are enabled, and custominfo is set to "scp343". There is also a command to manually assign the SCP-343 role. Medkits are infinite for SCP-343.

### Features

- Automatic SCP-343 selection at round start (can be disabled in the config).
- **SCP-343 role is always D-CLASS and cannot be changed.**
- **Spawn chance** for SCP-343 is configurable (`SpawnChance`).
- **Minimum player count** for SCP-343 spawning is configurable (`MinPlayers`).
- Number of medkits given at spawn is configurable (`MedkitCount`).
- Option to enable/disable bypass and godmode for SCP-343.
- Any item picked up becomes a medkit, any weapon becomes a configurable item (`WeaponConvertTo`).
- CustomInfo is set to "SCP-343".
- Command `.scp343spawn <id/nickname>` to manually turn a D-CLASS into SCP-343.
- **Infinite medkits** — after using one, a new one is given!
- **Coin teleport** (optional, see config): if enabled, SCP-343 gets a coin and can teleport to a random room except those in the blacklist.
- SCP-343 cannot pick up SCP items or MicroHID.

### Installation

1. Build the project or download the ready-made `.dll`.
2. Place the file into your server's `Exiled/Plugins` folder.
3. Restart your server.

### Configuration Example (Scp343.yml)

```yaml
IsEnabled: true
Debug: false
EnableAutoSpawn: true
SpawnChance: 1.0
MinPlayers: 1
MedkitCount: 8
EnableBypass: true
EnableGodMode: true
WeaponConvertTo: SCP500
SpawnHint: "<color=yellow><b>╔══════════════════════════════════════════════╗\n    Ты — <color=#FFD700>SCP-343 (БОГ)</color>!\n\n  — Все предметы, которые ты подберёшь, <color=#00ff00>становятся аптечками</color>.\n  — Всё оружие, которое ты подберёшь, <color=#ff6666>превращается в SCP-500</color>.\n  — При спавне ты получаешь <color=#00bfff>8 аптечек</color>, <color=#FFA500>bypass</color> и <color=#FFA500>godmode</color>.\n  — CustomInfo: <color=#FFD700>scp343</color>\n╚══════════════════════════════════════════════╝</b></color>"
EnableCoinTeleport: false
TeleportRoomBlacklist:
  - Surface
  - Pocket
  - LczArmory
  - HczArmory
```

> **Notes:**
> - SCP-343's role is always D-CLASS and cannot be changed.
> - If `EnableCoinTeleport` is enabled, SCP-343 receives a coin and 7 medkits (even if `MedkitCount` is higher), and can teleport using the coin.
> - `TeleportRoomBlacklist` lists rooms where SCP-343 cannot teleport (by name or type).

### Requirements

- Exiled API (compatible with the latest version)
- SCP:SL server

### Author

- zazarick

### License

Free to use and modify on your SCP:SL servers.

---

## Русский

**Описание:**  
Плагин для SCP:SL (Exiled), добавляющий SCP-343 ("Бог"). В начале раунда случайный игрок с ролью D-CLASS становится SCP-343. Любой предмет, который берёт SCP-343, становится аптечкой, а любое оружие — выбранным в конфиге (например, SCP-500). При спавне SCP-343 выдаются аптечки, включаются bypass и godmode, а custominfo устанавливается в "scp343". Есть команда для выдачи роли SCP-343 вручную. Аптечки для SCP-343 бесконечны.

### Возможности

- Автоматический выбор SCP-343 при старте раунда (можно выключить в конфиге).
- **Роль SCP-343 всегда D-CLASS и не может быть изменена**.
- **Шанс спавна** SCP-343 настраивается (`SpawnChance`).
- **Минимальное количество игроков на сервере** для спавна SCP-343 настраивается (`MinPlayers`).
- Количество аптечек, выдаваемых при спавне, настраивается (`MedkitCount`).
- Включение/отключение bypass и godmode для SCP-343.
- Любой предмет становится аптечкой, любое оружие — настраиваемым предметом (`WeaponConvertTo`).
- CustomInfo: "SCP-343".
- Команда `.scp343spawn <id/ник>` для ручного превращения D-CLASS в SCP-343.
- **Бесконечные аптечки** — после использования выдаётся новая!
- **Монетка-телепорт** (опционально, см. конфиг): если включено, SCP-343 получает монетку и может телепортироваться в случайную комнату, кроме указанных в blacklist.
- SCP-343 не может поднимать SCP-предметы и микроХИД.

### Установка

1. Скомпилируйте проект или скачайте готовый `.dll`.
2. Поместите файл в папку `Exiled/Plugins` на вашем сервере SCP:SL.
3. Перезапустите сервер.

### Настройки (пример Scp343.yml)

```yaml
IsEnabled: true
Debug: false
EnableAutoSpawn: true
SpawnChance: 1.0
MinPlayers: 1
MedkitCount: 8
EnableBypass: true
EnableGodMode: true
WeaponConvertTo: SCP500
SpawnHint: "<color=yellow><b>╔══════════════════════════════════════════════╗\n    Ты — <color=#FFD700>SCP-343 (БОГ)</color>!\n\n  — Все предметы, которые ты подберёшь, <color=#00ff00>становятся аптечками</color>.\n  — Всё оружие, которое ты подберёшь, <color=#ff6666>превращается в SCP-500</color>.\n  — При спавне ты получаешь <color=#00bfff>8 аптечек</color>, <color=#FFA500>bypass</color> и <color=#FFA500>godmode</color>.\n  — CustomInfo: <color=#FFD700>scp343</color>\n╚══════════════════════════════════════════════╝</b></color>"
EnableCoinTeleport: false
TeleportRoomBlacklist:
  - Surface
  - Pocket
  - LczArmory
  - HczArmory
```

> **Примечания:**
> - Роль SCP-343 всегда D-CLASS и не может быть изменена.
> - Если включён `EnableCoinTeleport`, SCP-343 получает монетку и 7 аптечек (даже если указано больше в `MedkitCount`), и может телепортироваться с помощью монетки.
> - `TeleportRoomBlacklist` — комнаты, в которые SCP-343 не сможет телепортироваться (по имени или типу).

### Требования

- Exiled API (совместимость с последней версией)
- Сервер SCP:SL

### Автор

- zazarick

### Лицензия

Бесплатно для использования и модификации на ваших серверах SCP:SL.
