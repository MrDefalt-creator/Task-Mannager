# Task Manager Application

A simple and scalable Task Manager application built with React, Redux, and a C# backend. This project features cookie-based authentication, single-page routing, and CRUD operations for managing tasks. Styled with Tailwind CSS for a modern and responsive user experience.

## 🚀 Features

- **🔐 User Authentication** - Secure cookie-based authentication for user sessions.
- **🔄 Single-Page Routing** - Smooth navigation using React Router.
- **📝 CRUD Operations** - Create, Read, Update, and Delete tasks with an intuitive interface.
- **🗃️ Redux State Management** - Centralized state management for efficient data handling.
- **🐘 PostgreSQL Database** - Scalable and reliable storage for user and task data.
- **🎨 Modern Styling** - Clean and responsive UI powered by Tailwind CSS.

## 🛠️ Technologies Used

### Frontend:
- ⚛️ React
- 🎛️ Redux
- 🚏 React Router
- 🎨 Tailwind CSS

### Backend:
- 🏗️ C#, ASP.NET Core
- 🐘 PostgreSQL
- 🔐 Cookie-based authentication

---

### 📦 Development Notes

> ⚠️ **Important for local development:**
>
> - This application was **tested primarily on Mozilla Firefox**, due to Google Chrome's restrictions on cookie behavior over `http://localhost`. Firefox allows more permissive handling of cookies in non-secure (HTTP) local environments, making development and debugging smoother.
> - When preparing for **production deployment**, make sure to:
>   - Serve the application over **HTTPS**.
>   - Adjust **cookie settings on the backend**:
>     - Set the `Secure` flag to `true` so cookies are only transmitted over HTTPS.
>     - Use appropriate `SameSite` policies (e.g., `Lax` or `Strict` for most cases, `None` with `Secure` for cross-site).
>   - Consider implementing **refresh tokens** for improved authentication security and session management.


## 🚀 Getting Started

### ✅ Prerequisites
Make sure you have the following installed:
- [Node.js](https://nodejs.org/) and npm
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL](https://www.postgresql.org/) (running and configured)
- Basic knowledge of React, Redux, and C#

### 📥 Installation

#### 1️⃣ Clone the repository:
```sh
git clone https://github.com/MrDefalt-creator/Task-Mannager.git
cd Task-Mannager
```

#### 2️⃣ Install frontend dependencies:
```sh
cd Frontend
npm install
```

#### 3️⃣ Set up the backend:
- Navigate to the backend directory.
- Update the database connection string in `appsettings.json`.

#### 4️⃣ Run the database migrations:
```sh
dotnet ef database update
```

### 🚀 Start the development servers

#### Backend (C#):
```sh
cd TMBack
dotnet run
```

#### Frontend (React):
```sh
cd Frontend
npm run dev
```

### 🌍 Access the application
Open your browser and navigate to:  
👉 [http://localhost:5173](http://localhost:5173)

## 🤝 Contributing
Feel free to fork this repository and submit pull requests to improve the project!

## 📜 License
This project is licensed under the MIT License.

---

Happy coding! 🚀

