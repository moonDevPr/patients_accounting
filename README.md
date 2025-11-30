# Patients Accounting

Система учета пациентов медицинских учреждений

## Описание проекта

Система для управления и учета пациентов в учреждениях здравоохранения. Проект реализован на .NET с использованием Windows Forms и Entity Framework.

## Технологии

- .NET
- Windows Forms
- Entity Framework Core
- PostgreSQL
- DotNetEnv

## Структура проекта
**Dependencies** содержит зависимости (подключение к БД и другим сервисам);

**Forms** содержит формы Windows Forms;

**Models** содержит модели БД в виде классов на основе ORM;

**Program.cs** - запуск общего приложения

## Установка и запуск

### Предварительные требования

- .NET SDK 8.0
- PostgreSQL 12 или выше
- Git

### Установка

1. Клонируйте репозиторий:
```bash
git clone https://github.com/moonDevPr/patients_accounting.git
```

2. Переход к папке
```bash
cd PatientsAccounting
```

3. Установка необходимых пакетов 
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package DotNetEnv
```

4. Для сборки можно использовать команду
```bash
dotnet build
```

Перед запуском обязательно создать файл переменных окружения .env

5. Для запуска
```bash
dotnet run
```

## Новые ветки 

1 вариант создания:
- создание ветки
```bash
git branch <название ветки>
```

- переключение на ветку
```bash
git checkout <название ветки>
```

2 вариант:
```bash
git checkout -b <название_ветки>
```

- переключение между ветками
```bash
git switch <название_ветки>
```
