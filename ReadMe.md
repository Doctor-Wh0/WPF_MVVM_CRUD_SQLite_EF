1) Файл с логами находится в проекте исполнения BellIntegratorTestTask в папке bin -> Debug (or Release)-> netcore3.1 -> в папке в Logs .
Для логирования создан отдельный проект BellIntegratorTestTask.LogService
Логгер записывает Info Warn Error события.

2) Базу данных вынес в главную папку вне проектов.
Для этого нужно сделать config и там прописать путь, но я оставил в виде переменной строки. Путь к базе можно установить самостоятельно.
переменная pathToDb в файле EntitiesDBContext.cs в проекте DAL.

3) Если понадобится сделать что-то заново с БД. Создать файл БД заново:
Необходимо установить проект DAL в качестве запускаемого проекта. Нажать на проект -> свойства -> Назначить в качестве запускаемого проекта.
Далее
В меню Visual (там где Вид, Правка)
Средства -> Диспетчер пакетов NuGet -> Консоль диспетчера пакетов.
Внизу, вместо окна Дебага с выводом вылезет консоль диспетчера пакетов.
В меню этого окна найти тулбар "Проект по умолчанию" и назначить DAL.
Дальше вбить несколько комманд. 
Так как папка с миграциями уже есть, то достаточно команды: Update-Database
Если надо что-то поменять с моделями, то удаляем папку с миграциями или пишем иные миграции и вводим команды:
Add-Migration InitialCreate
Update-Database

Подробнее можно прочитать статью: https://docs.microsoft.com/ru-ru/ef/core/get-started/?tabs=visual-studio


4) Проект BellIntegratorTestTask.DAL реализовано в качестве библиотеки Net Standart 2.0
BellIntegratorTestTask.LogService - Net Standart 2.0
BellIntegratorTestTask.Core - Net Standart 2.0
Основной проект на Core 3.1

5) Все сервисы подключяются в App - файле в Unity Service Locator 
6) Сортировка по колонкам осуществляется по клику на названиию (Header) колонки
