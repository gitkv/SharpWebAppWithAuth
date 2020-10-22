Для настройки SMTP сервера необходимо отредактировать файл `appsettings.json`

Для указания логина и пароля SMTP необходимо указать секреты `Smtp:Login` и `Smtp:Password`:
```bash
$ dotnet user-secrets set "Smtp:Login" "LOGIN"

$ dotnet user-secrets set "Smtp:Password" "PASSWORD"
```
И для работы погоды необходимо указать секрет `Weather:YandexApiKey` ключ к апи яндекс погоды (https://developer.tech.yandex.ru/services/)
```bash
$ dotnet user-secrets set "Weather:YandexApiKey" "KEY"
```