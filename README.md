# 🖥️ SoftSkills Backend — API для управления развитием мягких навыков

![.NET](https://img.shields.io/badge/.NET-6.0%2B-orange)
![API](https://img.shields.io/badge/API-REST-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Swagger](https://img.shields.io/badge/docs-Swagger%20UI-brightgreen)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?logo=postgresql&logoColor=white)

Backend-сервер для приложения **SoftSkills** — RESTful API на ASP.NET Core, который управляет данными пользователей, прогрессом по soft skills, заданиями, дневниками и отчётами. Предназначен для взаимодействия с WPF-клиентом, а также потенциально — с мобильными и веб-приложениями.

---

## 📌 Основные возможности

- 👤 Управление профилями пользователей
- 📈 CRUD операции для навыков, категорий, целей
- 🗓️ Управление заданиями и трекинг прогресса
- 📦 Поддержка миграций EF Core

---

## 🛠️ Технологии

- **Язык**: C#
- **Фреймворк**: ASP.NET Core 6+ Web API
- **ORM**: Entity Framework Core
- **База данных**: PostgreSQL
- **Документация API**: Swagger
- **CI/CD**: GitHub Actions 

---

## 💻 Требования

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- База данных PostgreSQL

---

## 🚀 Запуск проекта

### 1. Клонирование репозитория

```bash
git clone https://github.com/Prak-PO/Backend-PO.git
cd Backend-PO
