# patients_accounting
Система учета пациентов здравоохранительных учреждений

Структура проекта:
**Dependencies** содержит зависимости (подключение к БД и другим сервисам);
**Forms** содержит формы Windows Forms;
**Models** содержит модели БД в виде классов на основе ORM;

**Program.cs** - запуск общего приложения

## Установка
1. Клонирование репозитория 

```git clone https://github.com/moonDevPr/patients_accounting.git```

2. Переход к папке
```cd PatientsAccounting```

3. Установка необходимых пакетов 
```dotnet add package Microsoft.EntityFrameworkCore.Design```
```dotnet add package Microsoft.EntityFrameworkCore.Tools``` 
```dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL```
```dotnet add package DotNetEnv```

4. Для сборки можно использовать команду
```dotnet build```

Перед запуском обязательно создать файл переменных окружения .env

5. Для запуска 
```dotnet run```


